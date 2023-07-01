﻿using Domain.Interfaces.Entidades;

namespace Domain.Entidades
{
    public class ClienteEntity : IBaseEntity
    {
        public string Nome { get; set; } = string.Empty;
        public string Documento { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;
    }
}