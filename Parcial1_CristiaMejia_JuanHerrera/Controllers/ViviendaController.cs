using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Parcial1_CristiaMejia_JuanHerrera.Models;
using Parcial1_CristiaMejia_JuanHerrera.Services;

namespace Parcial1_CristiaMejia_JuanHerrera.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViviendaController : ControllerBase
    {
        private readonly ViviendaService _viviendaService;

        public ViviendaController(ViviendaService viviendaService)
        {
            _viviendaService = viviendaService;
        }

        // GET: api/<ViviendaController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ViviendaDTO>>> Get()
        {
            var viviendas = await _viviendaService.ObtenerViviendas();
            return Ok(viviendas);
        }

        // GET api/<ViviendaController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ViviendaDTO>> Get(int id)
        {
            var vivienda = await _viviendaService.ObtenerViviendaPorId(id);
            if (vivienda == null)
            {
                return NotFound();
            }
            return Ok(vivienda);
        }

        // POST api/<ViviendaController>
        [HttpPost]
        public async Task<ActionResult<ViviendaDTO>> Post([FromBody] ViviendaDTO vivienda)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdVivienda = await _viviendaService.CrearVivienda(vivienda);
            return CreatedAtAction(nameof(Get), new { id = createdVivienda.IdVivienda }, createdVivienda);
        }

        // PUT api/<ViviendaController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<ViviendaDTO>> Put(int id, [FromBody] ViviendaDTO vivienda)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vivienda.IdVivienda)
            {
                return BadRequest("El ID de la vivienda no coincide con el ID de la URL.");
            }

            var updatedVivienda = await _viviendaService.ActualizarVivienda(vivienda);
            if (updatedVivienda == null)
            {
                return NotFound();
            }

            return Ok(updatedVivienda);
        }

        // PATCH api/<ViviendaController>/5
        [HttpPatch("{id}")]
        public async Task<ActionResult<ViviendaDTO>> Patch(int id, [FromBody] JsonPatchDocument<ViviendaDTO> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest();
            }

            var vivienda = await _viviendaService.ObtenerViviendaPorId(id);
            if (vivienda == null)
            {
                return NotFound();
            }

            patchDoc.ApplyTo(vivienda, (error) => ModelState.AddModelError(error.AffectedObject.ToString(), error.ErrorMessage));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedVivienda = await _viviendaService.ActualizarVivienda(vivienda);
            if (updatedVivienda == null)
            {
                return NotFound();
            }

            return Ok(updatedVivienda);
        }

        // DELETE api/<ViviendaController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ViviendaDTO>> Delete(int id)
        {
            var vivienda = await _viviendaService.EliminarVivienda(id);
            if (vivienda == null)
            {
                return NotFound();
            }
            return Ok(vivienda);
        }
    }
}


