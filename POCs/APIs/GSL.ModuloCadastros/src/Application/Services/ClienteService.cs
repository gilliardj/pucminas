using Domain.Entidades;
using Domain.Interfaces.Mensageria;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repository;
        private readonly IClienteProducer _clienteProducer;

        public ClienteService(IClienteRepository repository, IClienteProducer clienteProducer)
        {
            _repository = repository;
            _clienteProducer = clienteProducer;
        }

        public void Atualizar(ClienteEntity cliente)
        {
            _repository.Atualizar(cliente);
            _repository.Persistir();
        }

        public ClienteEntity Consultar(Guid clienteId)
        {
            return _repository.Consultar(clienteId);
        }

        public ClienteEntity Consultar(string documento)
        {
            return _repository.Consultar(documento);
        }

        public void Criar(ClienteEntity cliente)
        {
            _repository.Criar(cliente);
            _repository.Persistir();
            _clienteProducer.EnviarCriar(cliente);
        }

        public void Excluir(Guid clienteId)
        {
            _repository.Excluir(clienteId);
            _repository.Persistir();
        }

        public IEnumerable<ClienteEntity> ConsultarTodos()
        {
            return _repository.ConsultarTodos().ToList();
        }
    }
}