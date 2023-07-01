using GSL.SharedModel.Message;
using MassTransit;
using Worker.Persistence.Clientes;

namespace Worker.Consumers.Clientes
{
    public class CriarClienteConsumer : IConsumer<GSL.SharedModel.Message.AdicionarClienteMessage>
    {
        private readonly IClientesMongoDB _clientesMongoDB;
        private readonly ILogger<CriarClienteConsumer> _logger;

        public CriarClienteConsumer(IClientesMongoDB clientesMongoDB, ILogger<CriarClienteConsumer> logger)
        {
            this._clientesMongoDB = clientesMongoDB;
            this._logger = logger;
        }

        public async Task Consume(ConsumeContext<AdicionarClienteMessage> context)
        {
            try
            {
                _clientesMongoDB.InserirObjeto(context.Message);
                _logger.LogInformation("Cliente cadastrado com sucesso no MongoDB");
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
            }
        }
    }
}