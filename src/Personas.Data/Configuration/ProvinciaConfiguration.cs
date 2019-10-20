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

            builder.Property(x => x.GentilicioF)
                .HasMaxLength(100);
            builder.Property(x => x.GentilicioM)
                .HasMaxLength(100);
        }
    }
}
