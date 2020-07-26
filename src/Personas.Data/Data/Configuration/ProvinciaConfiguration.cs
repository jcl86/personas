using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Personas.Data
{
    public class ProvinciaConfiguration : IEntityTypeConfiguration<Provincias>
    {
        public void Configure(EntityTypeBuilder<Provincias> builder)
        {
            builder.Property(x => x.NombreProvincia)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.GentilicioFemenino)
                .HasMaxLength(100);
            builder.Property(x => x.GentilicioMasculino)
                .HasMaxLength(100);

            builder.HasMany(e => e.Localidades)
               .WithOne(e => e.Provincias)
               .HasForeignKey(e => e.IdProvincia);
        }
    }
}
