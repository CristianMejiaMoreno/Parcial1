using Microsoft.EntityFrameworkCore;
using Parcial1_CristiaMejia_JuanHerrera.Models;

namespace Parcial1_CristiaMejia_JuanHerrera.Services
{
    public class VentaService
    {
        private readonly Parcial1Context _context;
        public VentaService(Parcial1Context context)
        {
            _context = context;
        }

        /**
         * Obtiene todas las ventas de la tabla de ventas
         */
        public async Task<List<VentaDTO>> ObtenerVentas()
        {
            return await _context.VentaDTOs
                .Include(v => v.Agencia)
                .Include(v => v.Cliente)
                .Include(v => v.Vivienda)
                .Where(v => !v.IsDeleted)
                .ToListAsync();
        }

        public async Task<VentaDTO> ObtenerVentaPorId(int id)
        {
            return await _context.VentaDTOs
                .Include(v => v.Agencia)
                .Include(v => v.Cliente)
                .Include(v => v.Vivienda)
                .FirstOrDefaultAsync(v => v.IdVenta == id && !v.IsDeleted);
        }

        public async Task<VentaDTO> CrearVenta(VentaDTO venta)
        {
            venta.CreatedAt = DateTime.Now;
            venta.IsDeleted = false;

            _context.VentaDTOs.Add(venta);
            await _context.SaveChangesAsync();

            return await ObtenerVentaPorId(venta.IdVenta);
        }

        public async Task<VentaDTO> ActualizarVenta(VentaDTO venta)
        {
            var ventaExistente = await _context.VentaDTOs.FindAsync(venta.IdVenta);
            if (ventaExistente == null || ventaExistente.IsDeleted)
            {
                return null;
            }

            ventaExistente.IdAgencia = venta.IdAgencia;
            ventaExistente.IdCliente = venta.IdCliente;
            ventaExistente.IdVivienda = venta.IdVivienda;
            ventaExistente.FechaVenta = venta.FechaVenta;
            ventaExistente.Precio = venta.Precio;
            ventaExistente.UpdatedAt = DateTime.Now;

            await _context.SaveChangesAsync();

            return await ObtenerVentaPorId(venta.IdVenta);
        }

        public async Task<VentaDTO> EliminarVenta(int id)
        {
            var venta = await _context.VentaDTOs.FindAsync(id);
            if (venta == null || venta.IsDeleted)
            {
                return null;
            }

            venta.IsDeleted = true;
            venta.UpdatedAt = DateTime.Now;

            await _context.SaveChangesAsync();

            return venta;
        }
    }
}





