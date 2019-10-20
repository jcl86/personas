using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Personas.Data
{
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
