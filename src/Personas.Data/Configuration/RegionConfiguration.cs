using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Personas.Data
{
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
}
