using TesteXpInvestimento.Models;

// Contém classes relacionadas a dados e acesso a banco.
namespace TesteXpInvestimento.Data
{
    public class InMemoryDb // Simula um banco de dados em memória para testes.
    {
        public static List<Cliente> Clientes { get; set; } = new List<Cliente>(); // Lista de clientes
        private static int _nextId = 1; // Variável para gerar IDs únicos

        public static int GerarNovoId() // Método para gerar um novo ID
        {
            return _nextId++;
        }
    }
}
