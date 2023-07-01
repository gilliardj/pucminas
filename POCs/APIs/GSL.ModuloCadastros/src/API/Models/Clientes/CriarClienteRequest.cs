using System.ComponentModel.DataAnnotations;

namespace API.Models.Clientes
{
    public class CriarClienteRequest
    {
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [MinLength(2, ErrorMessage = "O campo Nome deve conter no mínimo 2 caracteres.")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo Documento é obrigatório.")]
        public string Documento { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O campo Email deve ser um endereço de email válido.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo Telefone é obrigatório.")]
        [MinLength(8, ErrorMessage = "O campo Telefone deve conter no mínimo 8 caracteres.")]
        public string Telefone { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo Endereco é obrigatório.")]
        [MinLength(5, ErrorMessage = "O campo Endereco deve conter no mínimo 5 caracteres.")]
        public string Endereco { get; set; } = string.Empty;
    }
}