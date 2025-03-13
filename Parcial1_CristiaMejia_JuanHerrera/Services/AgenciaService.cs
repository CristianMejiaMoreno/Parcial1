using Microsoft.EntityFrameworkCore;
using Parcial1_CristiaMejia_JuanHerrera.Models;

namespace Parcial1_CristiaMejia_JuanHerrera.Services
{
    public class AgenciaService
    {
        private readonly Parcial1Context _context;
        public AgenciaService(Parcial1Context context)
        {
            _context = context;
        }

        /**
         * Obtiene todas las agencias de la tabla de agencias
         */
        public async Task<List<AgenciaDTO>> ObtenerAgencias()
        {
            return await _context.AgenciaDTOs
                .FromSqlRaw("SELECT * FROM Agencia WHERE IsDeleted != 1")
                .ToListAsync();
        }

        public async Task<AgenciaDTO> ObtenerAgenciaPorId(int id)
        {
            return await _context.AgenciaDTOs
                .FromSqlRaw("SELECT * FROM Agencia WHERE IdAgencia = {0}", id)
                .FirstOrDefaultAsync();
        }

        public async Task<AgenciaDTO> CrearAgencia(AgenciaDTO agencia)
        {
            var sqlInsert = "INSERT INTO Agencia (Nombre, Direccion, Telefono, CreatedAt, IsDeleted) " +
                            "VALUES (@p0, @p1, @p2, GETDATE(), 0);";

            await _context.Database.ExecuteSqlRawAsync(sqlInsert, agencia.Nombre, agencia.Direccion, agencia.Telefono);

            var sqlSelect = "SELECT * FROM Agencia WHERE Nombre = @p0 AND Direccion = @p1";
            var createdAgencia = await _context.AgenciaDTOs
                .FromSqlRaw(sqlSelect, agencia.Nombre, agencia.Direccion)
                .FirstOrDefaultAsync();

            return createdAgencia;
        }

        public async Task<AgenciaDTO> ActualizarAgencia(AgenciaDTO agencia)
        {
            var sqlUpdate = "UPDATE Agencia SET Nombre = @p0, Direccion = @p1, Telefono = @p2, UpdatedAt = GETDATE() " +
                            "WHERE IdAgencia = @p3";

            await _context.Database.ExecuteSqlRawAsync(sqlUpdate, agencia.Nombre, agencia.Direccion, agencia.Telefono, agencia.IdAgencia);

            var sqlSelect = "SELECT * FROM Agencia WHERE IdAgencia = @p0";
            var updatedAgencia = await _context.AgenciaDTOs
                .FromSqlRaw(sqlSelect, agencia.IdAgencia)
                .FirstOrDefaultAsync();

            return updatedAgencia;
        }

        public async Task<AgenciaDTO> EliminarAgencia(int id)
        {
            var agencia = await _context.AgenciaDTOs.FirstOrDefaultAsync(a => a.IdAgencia == id);
            if (agencia == null)
            {
                return null;
            }
            
            

            var sql = "UPDATE Agencia SET IsDeleted = 1, UpdatedAt = GETDATE() WHERE IdAgencia = @p0";
            var result = await _context.Database.ExecuteSqlRawAsync(sql, id);

            return result > 0 ? agencia : null;
        }

    }
}

