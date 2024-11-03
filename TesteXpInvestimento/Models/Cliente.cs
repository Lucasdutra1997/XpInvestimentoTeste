using System.ComponentModel.DataAnnotations;

// Agrupar modelos de dados
namespace TesteXpInvestimento.Models
{
    // Classe que representa o modelo de um cliente
    public class Cliente
    {
        public int Id { get; set; } // Propriedade para Id do cliente

        [Required] // Indica que o campo é obrigatório
        [RegularExpression(@"^\d{11}$", ErrorMessage = "O CPF deve ter 11 dígitos.")] // Validação do CPF
        public string? CPF { get; set; } // Campo CPF - //Declarando como anulável

        [Required] // Indica que o campo é obrigatório
        [EmailAddress(ErrorMessage = "Email inválido.")] // Validação do E-mail
        public string? Email { get; set; } // Campo Email - //Declarando como anulável

        [Required] // Indica que o campo é obrigatório
        public string? Nome { get; set; } // Campo Nome - //Declarando como anulável
    }
}






