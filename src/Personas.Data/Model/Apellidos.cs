using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Personas.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personas.Data
{
    public class Apellidos : DatabaseEntity
    {
        public string Apellido { get; set; }
        public Cultura IdCultura { get; set; }
        public int Comun { get; set; }
        public bool ApellidoCompuesto { get; set; }
        public int IdIdioma { get; set; }
        public virtual Idiomas Idioma { get; set; }
    }

    public class ApellidoConfiguration : IEntityTypeConfiguration<Apellidos>
    {
        public void Configure(EntityTypeBuilder<Apellidos> builder)
        {
            builder.Property(x => x.Apellido)
                .IsRequired()
                .HasMaxLength(50);
        }
    }

    public class PaisConfiguration : IEntityTypeConfiguration<Paises>
    {
        public void Configure(EntityTypeBuilder<Paises> builder)
        {
            builder.Property(x => x.NombrePais)
                .IsRequired()
                .HasMaxLength(50);
        }
    }

    public class RegionConfiguration : IEntityTypeConfiguration<Regiones>
    {
        public void Configure(EntityTypeBuilder<Regiones> builder)
        {
            builder.Property(x => x.NombreRegion)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.GentilicioF)
                .HasMaxLength(100);
            builder.Property(x => x.GentilicioM)
                .HasMaxLength(100);
        }
    }

    public class ProvinciaConfiguration : IEntityTypeConfiguration<Provincias>
    {
        public void Configure(EntityTypeBuilder<Provincias> builder)
        {
            builder.Property(x => x.NombreProvincia)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.GentilicioF)
                .HasMaxLength(100);
            builder.Property(x => x.GentilicioM)
                .HasMaxLength(100);
        }
    }

    public class LocalidadConfiguration : IEntityTypeConfiguration<Localidades>
    {
        public void Configure(EntityTypeBuilder<Localidades> builder)
        {
            builder.Property(x => x.NombreLocalidad)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
