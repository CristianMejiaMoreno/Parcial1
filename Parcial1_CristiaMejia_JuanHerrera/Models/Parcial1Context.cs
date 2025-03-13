using Microsoft.EntityFrameworkCore;

namespace Parcial1_CristiaMejia_JuanHerrera.Models
{
    public class Parcial1Context : DbContext
    {
        public Parcial1Context(DbContextOptions<Parcial1Context> options) : base(options)
        {
            
        }

        public DbSet<AgenciaDTO> AgenciaDTOs { get; set; }
        public DbSet<ClienteDTO> ClienteDTOs { get; set; }
        public DbSet<TipoViviendaDTO> TipoViviendaDTOs { get; set; }
        public DbSet<ViviendaDTO> ViviendaDTOs { get; set; }
        public DbSet<VentaDTO> VentaDTOs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AgenciaDTO>().ToTable("Agencia");
            modelBuilder.Entity<ViviendaDTO>().HasQueryFilter(a => !a.IsDeleted);
            modelBuilder.Entity<ViviendaDTO>().Property(a => a.CreatedAt).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<ViviendaDTO>().Property(a => a.UpdatedAt).ValueGeneratedOnUpdate();

            modelBuilder.Entity<ClienteDTO>().ToTable("Cliente");
            modelBuilder.Entity<ViviendaDTO>().HasQueryFilter(c => !c.IsDeleted);
            modelBuilder.Entity<ViviendaDTO>().Property(c => c.CreatedAt).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<ViviendaDTO>().Property(c => c.UpdatedAt).ValueGeneratedOnUpdate();
            modelBuilder.Entity<ClienteDTO>()
                .HasIndex(c => c.Cedula)
                .IsUnique();

            modelBuilder.Entity<TipoViviendaDTO>().ToTable("TipoVivienda");
            modelBuilder.Entity<ViviendaDTO>().HasQueryFilter(tv => !tv.IsDeleted);
            modelBuilder.Entity<ViviendaDTO>().Property(tv => tv.CreatedAt).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<ViviendaDTO>().Property(tv => tv.UpdatedAt).ValueGeneratedOnUpdate();
            modelBuilder.Entity<TipoViviendaDTO>()
                .HasIndex(t => t.Descripcion)
                .IsUnique();

            modelBuilder.Entity<ViviendaDTO>().ToTable("Vivienda");
            modelBuilder.Entity<ViviendaDTO>().HasQueryFilter(vv => !vv.IsDeleted);
            modelBuilder.Entity<ViviendaDTO>().Property(vv => vv.CreatedAt).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<ViviendaDTO>().Property(vv => vv.UpdatedAt).ValueGeneratedOnUpdate();

            modelBuilder.Entity<VentaDTO>().ToTable("Venta");
            modelBuilder.Entity<VentaDTO>().HasQueryFilter(v => !v.IsDeleted);
            modelBuilder.Entity<VentaDTO>().Property(v => v.CreatedAt).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<VentaDTO>().Property(v => v.UpdatedAt).ValueGeneratedOnUpdate();

        }
        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified))
            {
                if (entry.Entity is AgenciaDTO || entry.Entity is ClienteDTO || entry.Entity is TipoViviendaDTO || entry.Entity is ViviendaDTO || entry.Entity is VentaDTO)
                {
                    entry.Property("UpdatedAt").CurrentValue = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }
    }

}
