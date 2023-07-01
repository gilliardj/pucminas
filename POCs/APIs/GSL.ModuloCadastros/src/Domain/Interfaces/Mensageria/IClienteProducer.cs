using Domain.Entidades;

namespace Domain.Interfaces.Mensageria
{
    public interface IClienteProducer
    {
        Task EnviarCriar(ClienteEntity cliente);
    }
}