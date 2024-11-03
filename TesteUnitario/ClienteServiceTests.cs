using TesteXpInvestimento.Data;
using TesteXpInvestimento.Models;
using TesteXpInvestimento.Services;

// Agrupa testes automatizados de unidade.
namespace TesteUnitario
{
    public class ClienteServiceTests //  Testa funcionalidades do servi�o Cliente
    {
        private readonly ClienteService _service; // Inst�ncia somente leitura do servi�o Cliente

        public ClienteServiceTests() // Inicializa inst�ncia para testes do servi�o Cliente
        {
            _service = new ClienteService(); // Inicializa o servi�o

            InMemoryDb.Clientes.Clear(); // Limpa a lista de clientes antes de cada teste
        }

        [Fact] //  Indica que o m�todo � um teste unit�rio.
        public void Deve_Inserir_Cliente_Corrretamente() // Testa a inser��o correta de um cliente.
        {
            var cliente = new Cliente { CPF = "12345678901", Email = "teste@teste.com", Nome = "Teste" };
            _service.Inserir(cliente); // Insere o cliente

            var clientes = _service.Listar(); // Lista todos os clientes
            Assert.Single(clientes); // Verifica se h� um cliente na lista
            Assert.Equal(cliente.CPF, clientes.First().CPF); // Verifica se o CPF � o mesmo
            Assert.True(cliente.Id > 0); // Verifica se o ID foi atribu�do
        }

        [Fact]
        public void Deve_Listar_Clientes_Corrretamente() // Testa a listagem correta de clientes.
        {
            var cliente1 = new Cliente { CPF = "12345678901", Email = "teste@teste.com", Nome = "Teste" };
            var cliente2 = new Cliente { CPF = "10987654321", Email = "teste2@teste.com", Nome = "Teste2" };

            _service.Inserir(cliente1); // Insere o primeiro cliente
            _service.Inserir(cliente2); // Insere o segundo cliente

            var clientes = _service.Listar(); // Lista todos os clientes
            Assert.Equal(2, clientes.Count); // Verifica se a contagem de clientes est� correta
        }

        [Fact]
        public void Deve_Atualizar_Cliente_Corrretamente() // Testa a atualiza��o correta de um cliente.
        {
            var cliente = new Cliente { CPF = "12345678901", Email = "teste@teste.com", Nome = "Teste" };
            _service.Inserir(cliente); // Insere o cliente

            var clienteAtualizado = new Cliente { Email = "teste_atualizado@teste.com", Nome = "Teste Atualizado" };
            _service.Atualizar(cliente.Id, clienteAtualizado); // Atualiza o cliente

            var clientes = _service.Listar(); // Lista todos os clientes
            var clienteResultado = clientes.First(c => c.Id == cliente.Id); // Busca o cliente atualizado

            Assert.Equal(clienteAtualizado.Email, clienteResultado.Email); // Verifica se o e-mail foi atualizado
            Assert.Equal(clienteAtualizado.Nome, clienteResultado.Nome); // Verifica se o nome foi atualizado
        }

        [Fact]
        public void Deve_Deletar_Cliente_Corrretamente() // Testa a exclus�o correta de um cliente.
        {
            var cliente = new Cliente { CPF = "12345678901", Email = "teste@teste.com", Nome = "Teste" };
            _service.Inserir(cliente); // Insere o cliente

            _service.Deletar(cliente.Id); // Deleta o cliente

            var clientes = _service.Listar(); // Lista todos os clientes
            Assert.Empty(clientes); // Verifica se a lista de clientes est� vazia
        }
    }
}