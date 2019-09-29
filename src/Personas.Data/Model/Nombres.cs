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
    public class Nombres : DatabaseEntity
    {
        public string Nombre { get; set; }
        public Cultura IdCultura { get; set; }
        public int Comun { get; set; }
        public bool NombreCompuesto { get; set; }
        public int Sexo { get; set; }
        public int IdIdioma { get; set; }
        public virtual Idiomas Idiomas { get; set; }
    }

    public class NombreConfiguration : IEntityTypeConfiguration<Nombres>
    {
        public void Configure(EntityTypeBuilder<Nombres> builder)
        {
            builder.Property(x => x.Nombre)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
