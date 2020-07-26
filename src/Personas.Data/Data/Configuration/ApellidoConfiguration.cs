using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Personas.Data
{
    public class ApellidoConfiguration : IEntityTypeConfiguration<Apellidos>
    {
        public void Configure(EntityTypeBuilder<Apellidos> builder)
        {
            builder.Property(x => x.Apellido)
                .IsRequired()
                .HasMaxLength(50);

        }
    }
}
