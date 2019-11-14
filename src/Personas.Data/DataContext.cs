using Microsoft.EntityFrameworkCore;
using System;

namespace Personas.Data
{
    public class DataContext : DbContext
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
            //string cs = @"<add name="Model1sdfzg" connectionString="data source=(LocalDB)\MSSQLLocalDB;attachdbfilename=F:\DESARROLLO\Repos\Personas\src\Personas.Data\PersonasDB.mdf;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework" providerName="System.Data.SqlClient" />"
        }
    }
}
