using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Personas.Data
{
    public class PaisConfiguration : IEntityTypeConfiguration<Paises>
    {
        public void Configure(EntityTypeBuilder<Paises> builder)
        {
            builder.Property(x => x.NombrePais)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
