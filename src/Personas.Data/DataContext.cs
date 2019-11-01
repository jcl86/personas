﻿using Microsoft.EntityFrameworkCore;
using System;

namespace Personas.Data
{
    public class DataContext : DbContext
    {
        internal DbSet<Nombres> Nombres { get; set; }
        internal DbSet<Apellidos> Apellidos { get; set; }
        internal DbSet<Localidades> Localidades { get; set; }
        internal DbSet<Provincias> Provincias { get; set; }
        internal DbSet<Regiones> Regiones { get; set; }
        internal DbSet<Paises> Paises { get; set; }
        internal DbSet<Idiomas> Idiomas { get; set; }

        public DataContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new NombreConfiguration());
            modelBuilder.ApplyConfiguration(new ApellidoConfiguration());
            modelBuilder.ApplyConfiguration(new LocalidadConfiguration());
            modelBuilder.ApplyConfiguration(new ProvinciaConfiguration());
            modelBuilder.ApplyConfiguration(new RegionConfiguration());
            modelBuilder.ApplyConfiguration(new PaisConfiguration());
        }
    }
}
