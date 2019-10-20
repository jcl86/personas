using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Personas.Data
{
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
