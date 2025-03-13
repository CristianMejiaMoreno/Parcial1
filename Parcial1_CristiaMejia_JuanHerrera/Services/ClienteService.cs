using Microsoft.EntityFrameworkCore;
using Parcial1_CristiaMejia_JuanHerrera.Models;

namespace Parcial1_CristiaMejia_JuanHerrera.Services
{
    public class ClienteService
    {
        private readonly Parcial1Context _context;
        public ClienteService(Parcial1Context context)
        {
            _context = context;
        }
        /**
         * Obtiene todos los usuarios de la tabla de clientes
         */
        public async Task<List<ClienteDTO>> ObtenerUsuarios()
        {
            return await _context.ClienteDTOs
                .FromSqlRaw("SELECT * FROM Cliente WHERE IsDeleted != 1")
                .ToListAsync();
        }
        public async Task<ClienteDTO> ObtenerUsuarioPorId(int id)
        {
            return await _context.ClienteDTOs
                .FromSqlRaw("SELECT * FROM Cliente WHERE IdCliente = {0}", id)
                .FirstOrDefaultAsync();
        }
        public async Task<ClienteDTO> CrearCliente(ClienteDTO cliente)
        {
            var sqlInsert = "INSERT INTO Cliente (Nombre, Apellido, Cedula, Telefono, Email, CreatedAt, IsDeleted) " +
                            "VALUES (@p0, @p1, @p2, @p3, @p4, GETDATE(), 0);";

            await _context.Database.ExecuteSqlRawAsync(sqlInsert, cliente.Nombre, cliente.Apellido, cliente.Cedula, cliente.Telefono, cliente.Email);

            var sqlSelect = "SELECT * FROM Cliente WHERE Cedula = @p0";
            var createdCliente = await _context.ClienteDTOs
                .FromSqlRaw(sqlSelect, cliente.Cedula)
                .FirstOrDefaultAsync();

            return createdCliente;
        }
        public async Task<ClienteDTO> ActualizarCliente(ClienteDTO cliente)
        {
            var sqlUpdate = "UPDATE Cliente SET Nombre = @p0, Apellido = @p1, Cedula = @p2, Telefono = @p3, Email = @p4, UpdatedAt = GETDATE() " +
                            "WHERE IdCliente = @p5";

            await _context.Database.ExecuteSqlRawAsync(sqlUpdate, cliente.Nombre, cliente.Apellido, cliente.Cedula, cliente.Telefono, cliente.Email, cliente.IdCliente);

            var sqlSelect = "SELECT * FROM Cliente WHERE IdCliente = @p0";
            var updatedCliente = await _context.ClienteDTOs
                .FromSqlRaw(sqlSelect, cliente.IdCliente)
                .FirstOrDefaultAsync();

            return updatedCliente;
        }

        public async Task<ClienteDTO?> EliminarCliente(int id)
        {
            var cliente = await _context.ClienteDTOs.FirstOrDefaultAsync(c => c.IdCliente == id);
            if (cliente == null)
            {
                return null;
            }

            var sql = "UPDATE Cliente SET IsDeleted = 1, UpdatedAt = GETDATE() WHERE IdCliente = @p0";
            var result = await _context.Database.ExecuteSqlRawAsync(sql, id);

            return result > 0 ? cliente : null;
        }



    }
}
