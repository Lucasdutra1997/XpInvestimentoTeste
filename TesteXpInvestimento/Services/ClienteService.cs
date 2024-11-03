using TesteXpInvestimento.Data;
using TesteXpInvestimento.Models;

// Agrupar serviços do projeto.
namespace TesteXpInvestimento.Services
{
    // Classe que contém a lógica de negócios para clientes
    public class ClienteService
    {
        // Método para inserir um cliente
        public void Inserir(Cliente cliente)
        {
            cliente.Id = InMemoryDb.GerarNovoId(); // Atribui um novo ID ao cliente
            InMemoryDb.Clientes.Add(cliente); // Adiciona o cliente à lista em memória
        }

        // Método para listar todos os clientes
        public List<Cliente> Listar()
        {
            return InMemoryDb.Clientes; // Retorna a lista de clientes
        }

        // Método para atualizar um cliente
        public bool Atualizar(int id, Cliente clienteAtualizado)
        {
            var cliente = InMemoryDb.Clientes.FirstOrDefault(c => c.Id == id); // Busca o cliente pelo Id
            if (cliente != null)
            {
                // Atualiza os campos apenas se o cliente existir
                cliente.CPF = clienteAtualizado.CPF; // Atualiza o e-mail
                cliente.Email = clienteAtualizado.Email; // Atualiza o e-mail
                cliente.Nome = clienteAtualizado.Nome;   // Atualiza o nome
                return true; // Retorna verdadeiro se a atualização foi bem-sucedida
            }
            return false; // Retorna falso se o cliente não foi encontrado
        }

        // Método para deletar um cliente
        public void Deletar(int id)
        {
            var cliente = InMemoryDb.Clientes.FirstOrDefault(c => c.Id == id); // Busca o cliente pelo Id
            if (cliente != null)
            {
                InMemoryDb.Clientes.Remove(cliente); // Remove o cliente da lista
            }
        }
    }
}