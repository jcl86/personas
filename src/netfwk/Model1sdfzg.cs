namespace netfwk
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1sdfzg : DbContext
    {
        public Model1sdfzg()
            : base("name=Model1sdfzg")
        {
        }

        public virtual DbSet<Apellidos> Apellidos { get; set; }
        public virtual DbSet<Culturas> Culturas { get; set; }
        public virtual DbSet<Idiomas> Idiomas { get; set; }
        public virtual DbSet<Localidades> Localidades { get; set; }
        public virtual DbSet<Nombres> Nombres { get; set; }
        public virtual DbSet<Paises> Paises { get; set; }
        public virtual DbSet<Provincias> Provincias { get; set; }
        public virtual DbSet<Regiones> Regiones { get; set; }
        public virtual DbSet<Lugares> Lugares { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Culturas>()
                .HasMany(e => e.Apellidos)
                .WithRequired(e => e.Culturas)
                .HasForeignKey(e => e.IdCultura)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Culturas>()
                .HasMany(e => e.Nombres)
                .WithRequired(e => e.Culturas)
                .HasForeignKey(e => e.IdCultura)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Idiomas>()
                .HasMany(e => e.Apellidos)
                .WithRequired(e => e.Idiomas)
                .HasForeignKey(e => e.IdIdioma)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Idiomas>()
                .HasMany(e => e.Nombres)
                .WithRequired(e => e.Idiomas)
                .HasForeignKey(e => e.IdIdioma)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Idiomas>()
                .HasMany(e => e.Regiones)
                .WithOptional(e => e.Idiomas)
                .HasForeignKey(e => e.IdIdiomaCooficial);

            modelBuilder.Entity<Idiomas>()
                .HasMany(e => e.Regiones1)
                .WithRequired(e => e.Idiomas1)
                .HasForeignKey(e => e.IdIdiomaOficial)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Paises>()
                .HasMany(e => e.Regiones)
                .WithRequired(e => e.Paises)
                .HasForeignKey(e => e.IdPais)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Provincias>()
                .HasMany(e => e.Localidades)
                .WithRequired(e => e.Provincias)
                .HasForeignKey(e => e.IdProvincia)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Regiones>()
                .HasMany(e => e.Provincias)
                .WithRequired(e => e.Regiones)
                .HasForeignKey(e => e.IdRegion)
                .WillCascadeOnDelete(false);
        }
    }
}
