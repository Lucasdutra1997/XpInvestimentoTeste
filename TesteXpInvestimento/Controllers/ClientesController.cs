using Microsoft.AspNetCore.Mvc;
using TesteXpInvestimento.Models;
using TesteXpInvestimento.Services;

// Agrupa os controladores do projeto.
namespace TesteXpInvestimento.Controllers
{
    // Define um controlador de API e sua rota base.
    [ApiController]
    [Route("[controller]")]
    public class ClientesController : ControllerBase // Gerencia as operações relacionadas a clientes.
    {
        private readonly ClienteService _clienteService; // Instância somente leitura do serviço Cliente

        // Construtor que recebe o serviço de clientes
        public ClientesController()
        {
            _clienteService = new ClienteService(); // Inicializa o serviço
        }

        // Método para inserir um novo cliente
        [HttpPost]
        public ActionResult<Cliente> Inserir([FromBody] Cliente cliente)
        {
            if (!ModelState.IsValid) // Verifica se o modelo é válido
            {
                return BadRequest(ModelState); // Retorna erro se o modelo não for válido
            }

            _clienteService.Inserir(cliente); // Chama o método para inserir cliente
            return CreatedAtAction(nameof(Listar), new { cpf = cliente.CPF }, cliente); // Retorna o cliente inserido
        }

        // Método para listar todos os clientes
        [HttpGet]
        public ActionResult<List<Cliente>> Listar()
        {
            return Ok(_clienteService.Listar()); // Retorna a lista de clientes
        }

        // Método para atualizar um cliente
        [HttpPut("{id}")]
        public ActionResult Atualizar(int id, [FromBody] Cliente clienteAtualizado)
        {
            if (!ModelState.IsValid) // Verifica se o modelo é válido
            {
                return BadRequest(ModelState); // Retorna erro se o modelo não for válido
            }

            var resultado = _clienteService.Atualizar(id, clienteAtualizado); // Chama o método para atualizar cliente

            if (!resultado) // Verifica se a atualização foi bem-sucedida
            {
                return NotFound(); // Retorna 404 se o cliente não foi encontrado
            }

            return NoContent(); // Retorna sucesso
        }

        // Método para deletar um cliente
        [HttpDelete("{id}")]
        public ActionResult Deletar(int id)
        {
            var cliente = _clienteService.Listar().FirstOrDefault(c => c.Id == id); // Busca o cliente pelo Id
            if (cliente == null)
            {
                return NotFound(); // Retorna erro se o cliente não for encontrado
            }

            _clienteService.Deletar(cliente.Id); // Chama o método para deletar cliente
            return NoContent(); // Retorna sucesso
        }
    }
}