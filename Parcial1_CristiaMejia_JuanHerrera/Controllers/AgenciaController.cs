using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Parcial1_CristiaMejia_JuanHerrera.Models;
using Parcial1_CristiaMejia_JuanHerrera.Services;

namespace Parcial1_CristiaMejia_JuanHerrera.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgenciaController : ControllerBase
    {
        private readonly AgenciaService _agenciaService;

        public AgenciaController(AgenciaService agenciaService)
        {
            _agenciaService = agenciaService;
        }

        // GET: api/<AgenciaController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AgenciaDTO>>> Get()
        {
            var agencias = await _agenciaService.ObtenerAgencias();
            return Ok(agencias);
        }

        // GET api/<AgenciaController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AgenciaDTO>> Get(int id)
        {
            var agencia = await _agenciaService.ObtenerAgenciaPorId(id);
            if (agencia == null)
            {
                return NotFound();
            }
            return Ok(agencia);
        }

        // POST api/<AgenciaController>
        [HttpPost]
        public async Task<ActionResult<AgenciaDTO>> Post([FromBody] AgenciaDTO agencia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdAgencia = await _agenciaService.CrearAgencia(agencia);
            return CreatedAtAction(nameof(Get), new { id = createdAgencia.IdAgencia }, createdAgencia);
        }

        // PUT api/<AgenciaController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<AgenciaDTO>> Put(int id, [FromBody] AgenciaDTO agencia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != agencia.IdAgencia)
            {
                return BadRequest("El ID de la agencia no coincide con el ID de la URL.");
            }

            var updatedAgencia = await _agenciaService.ActualizarAgencia(agencia);
            if (updatedAgencia == null)
            {
                return NotFound();
            }

            return Ok(updatedAgencia);
        }

        // PATCH api/<AgenciaController>/5
        [HttpPatch("{id}")]
        public async Task<ActionResult<AgenciaDTO>> Patch(int id, [FromBody] JsonPatchDocument<AgenciaDTO> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest();
            }

            var agencia = await _agenciaService.ObtenerAgenciaPorId(id);
            if (agencia == null)
            {
                return NotFound();
            }

            patchDoc.ApplyTo(agencia, (error) => ModelState.AddModelError(error.AffectedObject.ToString(), error.ErrorMessage));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedAgencia = await _agenciaService.ActualizarAgencia(agencia);
            if (updatedAgencia == null)
            {
                return NotFound();
            }

            return Ok(updatedAgencia);
        }

        // DELETE api/<AgenciaController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AgenciaDTO>> Delete(int id)
        {
            var agencia = await _agenciaService.EliminarAgencia(id);
            if (agencia == null)
            {
                return NotFound();
            }
            return Ok(agencia);
        }


    }
}

