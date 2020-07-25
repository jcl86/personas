using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Personas.Data
{
    public class IdiomaConfiguration : IEntityTypeConfiguration<Idiomas>
    {
        public void Configure(EntityTypeBuilder<Idiomas> builder)
        {
            builder.HasMany(e => e.Apellidos)
             .WithOne(e => e.Idioma)
             .HasForeignKey(e => e.IdIdioma);

            builder.HasMany(e => e.Nombres)
               .WithOne(e => e.Idioma)
               .HasForeignKey(e => e.IdIdioma);

            builder.HasMany(e => e.RegionesOficial)
               .WithOne(e => e.IdiomaOficial)
               .HasForeignKey(e => e.IdIdiomaOficial);

            builder.HasMany(e => e.RegionesCooficial)
               .WithOne(e => e.IdiomaCooficial)
               .HasForeignKey(e => e.IdIdiomaCooficial);
        }
    }
}
