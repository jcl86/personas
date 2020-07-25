using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Personas.Data
{
    public class RegionConfiguration : IEntityTypeConfiguration<Regiones>
    {
        public void Configure(EntityTypeBuilder<Regiones> builder)
        {
            builder.Property(x => x.Nombre)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.GentilicioFemenino)
                .HasMaxLength(100);
            builder.Property(x => x.GentilicioMasculino)
                .HasMaxLength(100);

            builder.HasMany(e => e.Provincias)
              .WithOne(e => e.Regiones)
              .HasForeignKey(e => e.IdRegion);
        }
    }
}
