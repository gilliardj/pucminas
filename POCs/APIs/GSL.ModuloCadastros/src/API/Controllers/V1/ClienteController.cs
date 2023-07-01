using API.Adapters;
using API.Models.Clientes;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.V1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly ILogger<ClienteController> _logger;
        private readonly IClienteService _clienteService;

        public ClienteController(ILogger<ClienteController> logger, IClienteService clienteService)
        {
            _logger = logger;
            _clienteService = clienteService;
        }

        // GET api/clientes
        [HttpGet]
        public IActionResult GetClientes()
        {
            IEnumerable<Domain.Entidades.ClienteEntity> clientes = _clienteService.ConsultarTodos();
            return Ok(clientes.Map());
        }

        // GET api/clientes/{id}
        [HttpGet("{id}")]
        public IActionResult GetCliente(string id)
        {
            try
            {
                Guid clienteId = new Guid(id);
                var cliente = _clienteService.Consultar(clienteId);
                if (cliente == null)
                {
                    _logger.LogInformation("Não encontrado");
                    return NotFound();
                }
                _logger.LogInformation("Consulta realizada com sucesso!");
                return Ok(cliente.Map());
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                return BadRequest();
            }
        }

        // POST api/clientes
        [HttpPost]
        public IActionResult CreateCliente(CriarClienteRequest cliente)
        {
            try
            {
                var clienteEntidy = cliente.Map();
                _clienteService.Criar(clienteEntidy);
                _logger.LogInformation("Cliente cadastrado");
                return CreatedAtAction(nameof(GetCliente), new { id = clienteEntidy.Id.ToString() }, cliente);
            }
            catch (Exception excption)
            {
                _logger.LogError(excption, excption.Message);
                return BadRequest();
            }
        }

        // PUT api/clientes/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateCliente(string id, AtualizarClienteRequest atualizarClienteRequest)
        {
            try
            {
                Guid clienteId = new Guid(id);
                var cliente = _clienteService.Consultar(clienteId);
                if (cliente == null)
                {
                    return NotFound();
                }
                atualizarClienteRequest.Map(cliente);
                _clienteService.Atualizar(cliente);
                _logger.LogInformation("Cliente atualizado com sucesso.");
                return NoContent();
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                return BadRequest();
            }
        }

        // DELETE api/clientes/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteCliente(string id)
        {
            try
            {
                Guid clienteId = new Guid(id);
                var cliente = _clienteService.Consultar(clienteId);
                if (cliente == null)
                {
                    return NotFound();
                }
                _clienteService.Excluir(clienteId);
                return NoContent();
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                return BadRequest();
            }
        }
    }
}