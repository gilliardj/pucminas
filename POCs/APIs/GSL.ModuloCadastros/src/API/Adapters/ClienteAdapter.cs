using API.Models.Clientes;
using Domain.Entidades;

namespace API.Adapters
{
    public static class ClienteAdapter
    {
        public static ClienteEntity Map(this CriarClienteRequest criarClienteRequest)
        {
            if (criarClienteRequest == null) return new();

            return new ClienteEntity
            {
                Nome = criarClienteRequest.Nome,
                Documento = criarClienteRequest.Documento,
                Email = criarClienteRequest.Email,
                Endereco = criarClienteRequest.Endereco,
                Telefone = criarClienteRequest.Telefone,
                Id = Guid.NewGuid()
            };
        }

        public static ClienteEntity Map(this AtualizarClienteRequest atualizarClienteRequest, ClienteEntity clienteCliente)
        {
            if (atualizarClienteRequest == null) return clienteCliente;

            clienteCliente.Nome = atualizarClienteRequest.Nome;
            clienteCliente.Documento = atualizarClienteRequest.Documento;
            clienteCliente.Email = atualizarClienteRequest.Email;
            clienteCliente.Endereco = atualizarClienteRequest.Endereco;
            clienteCliente.Telefone = atualizarClienteRequest.Telefone;

            return clienteCliente;
        }

        public static ConsultarClienteResponse Map(this ClienteEntity clienteEntity)
        {
            if (clienteEntity == null) return new();

            return new ConsultarClienteResponse
            {
                Nome = clienteEntity.Nome,
                Documento = clienteEntity.Documento,
                Email = clienteEntity.Email,
                Endereco = clienteEntity.Endereco,
                Telefone = clienteEntity.Telefone
            };
        }

        public static IEnumerable<ConsultarClienteResponse> Map(this IEnumerable<ClienteEntity> clientesEntity)
        {
            return clientesEntity.Select(p => Map(p));
        }
    }
}