using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Parcial1_CristiaMejia_JuanHerrera.Models;
using Parcial1_CristiaMejia_JuanHerrera.Services;

namespace Parcial1_CristiaMejia_JuanHerrera.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoViviendaController : ControllerBase
    {
        private readonly TipoViviendaService _tipoViviendaService;

        public TipoViviendaController(TipoViviendaService tipoViviendaService)
        {
            _tipoViviendaService = tipoViviendaService;
        }

        // GET: api/<TipoViviendaController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoViviendaDTO>>> Get()
        {
            var tiposVivienda = await _tipoViviendaService.ObtenerTiposVivienda();
            return Ok(tiposVivienda);
        }

        // GET api/<TipoViviendaController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoViviendaDTO>> Get(int id)
        {
            var tipoVivienda = await _tipoViviendaService.ObtenerTipoViviendaPorId(id);
            if (tipoVivienda == null)
            {
                return NotFound();
            }
            return Ok(tipoVivienda);
        }

        // POST api/<TipoViviendaController>
        [HttpPost]
        public async Task<ActionResult<TipoViviendaDTO>> Post([FromBody] TipoViviendaDTO tipoVivienda)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdTipoVivienda = await _tipoViviendaService.CrearTipoVivienda(tipoVivienda);
            return CreatedAtAction(nameof(Get), new { id = createdTipoVivienda.IdTipoVivienda }, createdTipoVivienda);
        }

        // PUT api/<TipoViviendaController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<TipoViviendaDTO>> Put(int id, [FromBody] TipoViviendaDTO tipoVivienda)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tipoVivienda.IdTipoVivienda)
            {
                return BadRequest("El ID del tipo de vivienda no coincide con el ID de la URL.");
            }

            var updatedTipoVivienda = await _tipoViviendaService.ActualizarTipoVivienda(tipoVivienda);
            if (updatedTipoVivienda == null)
            {
                return NotFound();
            }

            return Ok(updatedTipoVivienda);
        }

        // PATCH api/<TipoViviendaController>/5
        [HttpPatch("{id}")]
        public async Task<ActionResult<TipoViviendaDTO>> Patch(int id, [FromBody] JsonPatchDocument<TipoViviendaDTO> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest();
            }

            var tipoVivienda = await _tipoViviendaService.ObtenerTipoViviendaPorId(id);
            if (tipoVivienda == null)
            {
                return NotFound();
            }

            patchDoc.ApplyTo(tipoVivienda, (error) => ModelState.AddModelError(error.AffectedObject.ToString(), error.ErrorMessage));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedTipoVivienda = await _tipoViviendaService.ActualizarTipoVivienda(tipoVivienda);
            if (updatedTipoVivienda == null)
            {
                return NotFound();
            }

            return Ok(updatedTipoVivienda);
        }

        // DELETE api/<TipoViviendaController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TipoViviendaDTO>> Delete(int id)
        {
            var tipoVivienda = await _tipoViviendaService.EliminarTipoVivienda(id);
            if (tipoVivienda == null)
            {
                return NotFound();
            }
            return Ok(tipoVivienda);
        }
    }
}


