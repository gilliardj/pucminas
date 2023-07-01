using Domain.Entidades;

namespace Infra.Adapters
{
    public static class InfraClienteAdapter
    {
        public static GSL.SharedModel.Message.AdicionarClienteMessage Map(this ClienteEntity cliente)
        {
            if (cliente == null) return new();

            return new GSL.SharedModel.Message.AdicionarClienteMessage
            {
                Documento = cliente.Documento,
                Email = cliente.Email,
                Endereco = cliente.Endereco,
                Nome = cliente.Nome,
                Telefone = cliente.Telefone,
                Id = cliente.Id.ToString()
            };
        }
    }
}