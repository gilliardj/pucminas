using Domain.Entidades;
using Domain.Interfaces.Contextos;

namespace Domain.Interfaces.Repositories
{
    public interface IClienteRepository : IUnitOfWork
    {
        ClienteEntity Consultar(Guid id);

        ClienteEntity Consultar(string documento);

        IQueryable<ClienteEntity> ConsultarTodos();

        void Criar(ClienteEntity cliente);

        void Excluir(Guid clienteId);

        void Atualizar(ClienteEntity cliente);
    }
}