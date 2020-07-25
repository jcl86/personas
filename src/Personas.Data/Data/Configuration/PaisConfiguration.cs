using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Personas.Data
{
    public class PaisConfiguration : IEntityTypeConfiguration<Paises>
    {
        public void Configure(EntityTypeBuilder<Paises> builder)
        {
            builder.Property(x => x.Nombre)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasMany(e => e.Regiones)
               .WithOne(e => e.Pais)
               .HasForeignKey(e => e.IdPais);
        }
    }
}
