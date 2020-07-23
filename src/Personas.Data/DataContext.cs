using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Personas.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        internal DbSet<Nombres> Nombres { get; set; }
        internal DbSet<Apellidos> Apellidos { get; set; }
        internal DbSet<Localidades> Localidades { get; set; }
        internal DbSet<Provincias> Provincias { get; set; }
        internal DbSet<Regiones> Regiones { get; set; }
        internal DbSet<Paises> Paises { get; set; }
        internal DbSet<Idiomas> Idiomas { get; set; }

        public DataContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
