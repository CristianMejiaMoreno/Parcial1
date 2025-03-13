using Microsoft.EntityFrameworkCore;
using Parcial1_CristiaMejia_JuanHerrera.Models;

namespace Parcial1_CristiaMejia_JuanHerrera.Services
{
    public class ViviendaService
    {
        private readonly Parcial1Context _context;
        public ViviendaService(Parcial1Context context)
        {
            _context = context;
        }

        /**
         * Obtiene todas las viviendas de la tabla de viviendas
         */
        public async Task<List<ViviendaDTO>> ObtenerViviendas()
        {
            return await _context.ViviendaDTOs
                .Include(v => v.Agencia)
                .Include(v => v.TipoVivienda)
                .Where(v => !v.IsDeleted)
                .ToListAsync();
        }

        public async Task<ViviendaDTO> ObtenerViviendaPorId(int id)
        {
            return await _context.ViviendaDTOs
                .Include(v => v.Agencia)
                .Include(v => v.TipoVivienda)
                .FirstOrDefaultAsync(v => v.IdVivienda == id && !v.IsDeleted);
        }

        public async Task<ViviendaDTO> CrearVivienda(ViviendaDTO vivienda)
        {
            vivienda.CreatedAt = DateTime.Now;
            vivienda.IsDeleted = false;

            _context.ViviendaDTOs.Add(vivienda);
            await _context.SaveChangesAsync();

            return await ObtenerViviendaPorId(vivienda.IdVivienda);
        }

        public async Task<ViviendaDTO> ActualizarVivienda(ViviendaDTO vivienda)
        {
            var viviendaExistente = await _context.ViviendaDTOs.FindAsync(vivienda.IdVivienda);
            if (viviendaExistente == null || viviendaExistente.IsDeleted)
            {
                return null;
            }

            viviendaExistente.IdAgencia = vivienda.IdAgencia;
            viviendaExistente.IdTipoVivienda = vivienda.IdTipoVivienda;
            viviendaExistente.NumeroCuartos = vivienda.NumeroCuartos;
            viviendaExistente.NumeroBanos = vivienda.NumeroBanos;
            viviendaExistente.TamanoM2 = vivienda.TamanoM2;
            viviendaExistente.NumeroPisos = vivienda.NumeroPisos;
            viviendaExistente.Accesorios = vivienda.Accesorios;
            viviendaExistente.UpdatedAt = DateTime.Now;

            await _context.SaveChangesAsync();

            return await ObtenerViviendaPorId(vivienda.IdVivienda);
        }

        public async Task<ViviendaDTO> EliminarVivienda(int id)
        {
            var vivienda = await _context.ViviendaDTOs.FindAsync(id);
            if (vivienda == null || vivienda.IsDeleted)
            {
                return null;
            }

            vivienda.IsDeleted = true;
            vivienda.UpdatedAt = DateTime.Now;

            await _context.SaveChangesAsync();

            return vivienda;
        }
    }
}




