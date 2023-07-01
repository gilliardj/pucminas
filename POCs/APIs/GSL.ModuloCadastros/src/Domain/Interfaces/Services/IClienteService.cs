using Domain.Entidades;

namespace Domain.Interfaces.Services
{
    public interface IClienteService
    {
        void Criar(ClienteEntity cliente);

        void Atualizar(ClienteEntity cliente);

        void Excluir(Guid clienteId);

        ClienteEntity Consultar(Guid clienteId);

        ClienteEntity Consultar(string documento);

        IEnumerable<ClienteEntity> ConsultarTodos();
    }
}