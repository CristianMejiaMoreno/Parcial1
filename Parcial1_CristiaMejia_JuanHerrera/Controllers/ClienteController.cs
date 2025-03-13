using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Parcial1_CristiaMejia_JuanHerrera.Models;
using Parcial1_CristiaMejia_JuanHerrera.Services;

namespace Parcial1_CristiaMejia_JuanHerrera.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteService _clienteService;

        public ClienteController(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        // GET: api/<ClienteController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteDTO>>> Get()
        {
            var clientes = await _clienteService.ObtenerUsuarios();
            return Ok(clientes);
        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteDTO>> Get(int id)
        {
            var cliente = await _clienteService.ObtenerUsuarioPorId(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }

        // POST api/<ClienteController>
        [HttpPost]
        public async Task<ActionResult<ClienteDTO>> Post([FromBody] ClienteDTO cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdCliente = await _clienteService.CrearCliente(cliente);
            return CreatedAtAction(nameof(Get), new { id = createdCliente.IdCliente }, createdCliente);
        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<ClienteDTO>> Put(int id, [FromBody] ClienteDTO cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cliente.IdCliente)
            {
                return BadRequest("El ID del cliente no coincide con el ID de la URL.");
            }

            var updatedCliente = await _clienteService.ActualizarCliente(cliente);
            if (updatedCliente == null)
            {
                return NotFound();
            }

            return Ok(updatedCliente);
        }

        // PATCH api/<ClienteController>/5
        [HttpPatch("{id}")]
        public async Task<ActionResult<ClienteDTO>> Patch(int id, [FromBody] JsonPatchDocument<ClienteDTO> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest();
            }

            var cliente = await _clienteService.ObtenerUsuarioPorId(id);
            if (cliente == null)
            {
                return NotFound();
            }

            patchDoc.ApplyTo(cliente, (error) => ModelState.AddModelError(error.AffectedObject.ToString(), error.ErrorMessage));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedCliente = await _clienteService.ActualizarCliente(cliente);
            if (updatedCliente == null)
            {
                return NotFound();
            }

            return Ok(updatedCliente);
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ClienteDTO>> Delete(int id)
        {
            var cliente = await _clienteService.EliminarCliente(id);
            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente); // Devolver el cliente eliminado
        }






    }
}
