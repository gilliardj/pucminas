using Domain.Entidades;
using Domain.Interfaces.Contextos;
using Domain.Interfaces.Repositories;
using Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private CadastroDbContext _context;

        public ClienteRepository(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
                throw new ArgumentNullException("unitOfWork");

            _context = unitOfWork as CadastroDbContext;
        }

        public ClienteEntity Consultar(Guid id)
        {
            return _context.Clientes.Find(id);
        }

        public IQueryable<ClienteEntity> ConsultarTodos()
        {
            return _context.Clientes.AsNoTracking();
        }

        public void Criar(ClienteEntity cliente)
        {
            _context.Clientes.Add(cliente);
        }

        public void Atualizar(ClienteEntity cliente)
        {
            _context.Entry(cliente).State = EntityState.Modified;
        }

        public ClienteEntity Consultar(string documento)
        {
            return _context.Clientes.FirstOrDefault(p => p.Documento == documento);
        }

        public void Excluir(Guid clienteId)
        {
            var cliente = this.Consultar(clienteId);
            _context.Clientes.Remove(cliente);
        }

        public void Persistir()
        {
            _context.Persistir();
        }
    }
}