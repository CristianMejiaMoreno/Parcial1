using Microsoft.EntityFrameworkCore;
using Parcial1_CristiaMejia_JuanHerrera.Models;

namespace Parcial1_CristiaMejia_JuanHerrera.Services
{
    public class TipoViviendaService
    {
        private readonly Parcial1Context _context;
        public TipoViviendaService(Parcial1Context context)
        {
            _context = context;
        }

        /**
         * Obtiene todos los tipos de vivienda de la tabla de tipos de vivienda
         */
        public async Task<List<TipoViviendaDTO>> ObtenerTiposVivienda()
        {
            return await _context.TipoViviendaDTOs
                .FromSqlRaw("SELECT * FROM TipoVivienda WHERE IsDeleted != 1")
                .ToListAsync();
        }

        public async Task<TipoViviendaDTO> ObtenerTipoViviendaPorId(int id)
        {
            return await _context.TipoViviendaDTOs
                .FromSqlRaw("SELECT * FROM TipoVivienda WHERE IdTipoVivienda = {0}", id)
                .FirstOrDefaultAsync();
        }

        public async Task<TipoViviendaDTO> CrearTipoVivienda(TipoViviendaDTO tipoVivienda)
        {
            var sqlInsert = "INSERT INTO TipoVivienda (Descripcion, CreatedAt, IsDeleted) " +
                            "VALUES (@p0, GETDATE(), 0);";

            await _context.Database.ExecuteSqlRawAsync(sqlInsert, tipoVivienda.Descripcion);

            var sqlSelect = "SELECT * FROM TipoVivienda WHERE Descripcion = @p0";
            var createdTipoVivienda = await _context.TipoViviendaDTOs
                .FromSqlRaw(sqlSelect, tipoVivienda.Descripcion)
                .FirstOrDefaultAsync();

            return createdTipoVivienda;
        }

        public async Task<TipoViviendaDTO> ActualizarTipoVivienda(TipoViviendaDTO tipoVivienda)
        {
            var sqlUpdate = "UPDATE TipoVivienda SET Descripcion = @p0, UpdatedAt = GETDATE() " +
                            "WHERE IdTipoVivienda = @p1";

            await _context.Database.ExecuteSqlRawAsync(sqlUpdate, tipoVivienda.Descripcion, tipoVivienda.IdTipoVivienda);

            var sqlSelect = "SELECT * FROM TipoVivienda WHERE IdTipoVivienda = @p0";
            var updatedTipoVivienda = await _context.TipoViviendaDTOs
                .FromSqlRaw(sqlSelect, tipoVivienda.IdTipoVivienda)
                .FirstOrDefaultAsync();

            return updatedTipoVivienda;
        }

        public async Task<TipoViviendaDTO> EliminarTipoVivienda(int id)
        {
            var tipoVivienda = await _context.TipoViviendaDTOs.FirstOrDefaultAsync(t => t.IdTipoVivienda == id);
            if (tipoVivienda == null)
            {
                return null;
            }

            var sql = "UPDATE TipoVivienda SET IsDeleted = 1, UpdatedAt = GETDATE() WHERE IdTipoVivienda = @p0";
            var result = await _context.Database.ExecuteSqlRawAsync(sql, id);

            return result > 0 ? tipoVivienda : null;
        }
    }
}


