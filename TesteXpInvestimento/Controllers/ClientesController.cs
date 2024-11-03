using Microsoft.AspNetCore.Mvc;
using TesteXpInvestimento.Models;
using TesteXpInvestimento.Services;

// Agrupa os controladores do projeto.
namespace TesteXpInvestimento.Controllers
{
    // Define um controlador de API e sua rota base.
    [ApiController]
    [Route("[controller]")]
    public class ClientesController : ControllerBase // Gerencia as opera��es relacionadas a clientes.
    {
        private readonly ClienteService _clienteService; // Inst�ncia somente leitura do servi�o Cliente

        // Construtor que recebe o servi�o de clientes
        public ClientesController()
        {
            _clienteService = new ClienteService(); // Inicializa o servi�o
        }

        // M�todo para inserir um novo cliente
        [HttpPost]
        public ActionResult<Cliente> Inserir([FromBody] Cliente cliente)
        {
            if (!ModelState.IsValid) // Verifica se o modelo � v�lido
            {
                return BadRequest(ModelState); // Retorna erro se o modelo n�o for v�lido
            }

            _clienteService.Inserir(cliente); // Chama o m�todo para inserir cliente
            return CreatedAtAction(nameof(Listar), new { cpf = cliente.CPF }, cliente); // Retorna o cliente inserido
        }

        // M�todo para listar todos os clientes
        [HttpGet]
        public ActionResult<List<Cliente>> Listar()
        {
            return Ok(_clienteService.Listar()); // Retorna a lista de clientes
        }

        // M�todo para atualizar um cliente
        [HttpPut("{id}")]
        public ActionResult Atualizar(int id, [FromBody] Cliente clienteAtualizado)
        {
            if (!ModelState.IsValid) // Verifica se o modelo � v�lido
            {
                return BadRequest(ModelState); // Retorna erro se o modelo n�o for v�lido
            }

            var resultado = _clienteService.Atualizar(id, clienteAtualizado); // Chama o m�todo para atualizar cliente

            if (!resultado) // Verifica se a atualiza��o foi bem-sucedida
            {
                return NotFound(); // Retorna 404 se o cliente n�o foi encontrado
            }

            return NoContent(); // Retorna sucesso
        }

        // M�todo para deletar um cliente
        [HttpDelete("{id}")]
        public ActionResult Deletar(int id)
        {
            var cliente = _clienteService.Listar().FirstOrDefault(c => c.Id == id); // Busca o cliente pelo Id
            if (cliente == null)
            {
                return NotFound(); // Retorna erro se o cliente n�o for encontrado
            }

            _clienteService.Deletar(cliente.Id); // Chama o m�todo para deletar cliente
            return NoContent(); // Retorna sucesso
        }
    }
}