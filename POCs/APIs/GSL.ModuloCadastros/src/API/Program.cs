using API.Configurations;
using API.Helpers;
using Application;
using Infra;
using MassTransit;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var appSettings = new AppSettings();
            builder.Configuration.Bind(appSettings);
            builder.AddOpenTelemetry(appSettings);
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.ConfigureInfra(builder.Configuration);
            builder.Services.ConfigureApplication();

            //builder.Services.AddMassTransit(bus =>
            //{
            //    bus.UsingRabbitMq((ctx, busConfigurator) =>
            //    {
            //        busConfigurator.Host(builder.Configuration.GetConnectionString("RabbitMq"));
            //        busConfigurator.Publish<GSL.SharedModel.Message.AdicionarClienteMessage>(e =>
            //        {
            //            e.ExchangeType = "topic";
            //        });
            //    });
            //});
            builder.Services.AddMassTransit(x =>
            {
                x.UsingActiveMq((context, busConfigurator) =>
                {
                    busConfigurator.Host("localhost", 61616, h =>
                    {
                        h.Username("admin");
                        h.Password("admin");
                    });
                    busConfigurator.EnableArtemisCompatibility();
                });
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}