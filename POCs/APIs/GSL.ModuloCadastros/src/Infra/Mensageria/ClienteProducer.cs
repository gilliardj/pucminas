using Domain.Entidades;
using Domain.Interfaces.Mensageria;
using Infra.Adapters;
using MassTransit;

namespace Infra.Mensageria
{
    public class ClienteProducer : IClienteProducer
    {
        private readonly IBus _publisher;

        public ClienteProducer(IBus publisher)
        {
            _publisher = publisher;
        }

        public async Task EnviarCriar(ClienteEntity cliente)
        {
            var message = cliente.Map();
            Uri uri = new Uri("queue:criarcliente");
            var endPoint = await _publisher.GetSendEndpoint(uri);
            await endPoint.Send(message, CancellationToken.None);
        }
    }
}