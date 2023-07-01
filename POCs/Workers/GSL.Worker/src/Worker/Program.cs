using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Worker.Consumers.Clientes;
using Worker.Helpers;

using Microsoft.Extensions.DependencyInjection;

using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Worker.Configuration;
using Worker.Persistence.Clientes;

namespace Worker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IHost host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, collection) =>
                {
                    var appSettings = new AppSettings();
                    var activeMqConfiguration = new ActiveMQConfiguration();
                    var connectionString = new ConnectionStringsConfiguration();
                    context.Configuration.Bind(appSettings);
                    context.Configuration.Bind(activeMqConfiguration);
                    context.Configuration.Bind(connectionString);
                    collection.AddSingleton(connectionString);
                    collection.AddScoped<IClientesMongoDB, ClientesMongoDB>();
                    collection.AddOpenTelemetry(appSettings);
                    collection.AddHttpContextAccessor();

                    collection.AddMassTransit(x =>
                  {
                      x.AddConsumer<CriarClienteConsumer>();

                      x.AddBus(provider => Bus.Factory.CreateUsingActiveMq(cfg =>
                      {
                          cfg.Host(activeMqConfiguration.ActiveMq.Server, activeMqConfiguration.ActiveMq.Port, h =>
                           {
                               h.Username(activeMqConfiguration.ActiveMq.User);
                               h.Password(activeMqConfiguration.ActiveMq.Password);
                           });

                          cfg.ReceiveEndpoint("criarcliente", ep =>
                          {
                              ep.PrefetchCount = 10;
                              ep.UseMessageRetry(r => r.Interval(2, 100));
                              ep.ConfigureConsumer<CriarClienteConsumer>(provider);
                          });
                      }));
                  });
                })
                .Build();

            host.Run();
        }
    }
}