using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Parcial1_CristiaMejia_JuanHerrera.Models;
using Parcial1_CristiaMejia_JuanHerrera.Services;

namespace Parcial1_CristiaMejia_JuanHerrera.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly VentaService _ventaService;

        public VentaController(VentaService ventaService)
        {
            _ventaService = ventaService;
        }

        // GET: api/<VentaController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VentaDTO>>> Get()
        {
            var ventas = await _ventaService.ObtenerVentas();
            return Ok(ventas);
        }

        // GET api/<VentaController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VentaDTO>> Get(int id)
        {
            var venta = await _ventaService.ObtenerVentaPorId(id);
            if (venta == null)
            {
                return NotFound();
            }
            return Ok(venta);
        }

        // POST api/<VentaController>
        [HttpPost]
        public async Task<ActionResult<VentaDTO>> Post([FromBody] VentaDTO venta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdVenta = await _ventaService.CrearVenta(venta);
            return CreatedAtAction(nameof(Get), new { id = createdVenta.IdVenta }, createdVenta);
        }

        // PUT api/<VentaController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<VentaDTO>> Put(int id, [FromBody] VentaDTO venta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != venta.IdVenta)
            {
                return BadRequest("El ID de la venta no coincide con el ID de la URL.");
            }

            var updatedVenta = await _ventaService.ActualizarVenta(venta);
            if (updatedVenta == null)
            {
                return NotFound();
            }

            return Ok(updatedVenta);
        }

        // PATCH api/<VentaController>/5
        [HttpPatch("{id}")]
        public async Task<ActionResult<VentaDTO>> Patch(int id, [FromBody] JsonPatchDocument<VentaDTO> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest();
            }

            var venta = await _ventaService.ObtenerVentaPorId(id);
            if (venta == null)
            {
                return NotFound();
            }

            patchDoc.ApplyTo(venta, (error) => ModelState.AddModelError(error.AffectedObject.ToString(), error.ErrorMessage));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedVenta = await _ventaService.ActualizarVenta(venta);
            if (updatedVenta == null)
            {
                return NotFound();
            }

            return Ok(updatedVenta);
        }

        // DELETE api/<VentaController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<VentaDTO>> Delete(int id)
        {
            var venta = await _ventaService.EliminarVenta(id);
            if (venta == null)
            {
                return NotFound();
            }
            return Ok(venta);
        }
    }
}





