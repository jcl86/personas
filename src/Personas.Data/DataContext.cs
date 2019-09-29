using Microsoft.EntityFrameworkCore;
using System;

namespace Personas.Data
{
    public class DataContext : DbContext
    {
        internal DbSet<Nombres> Users { get; set; }
        public DataContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var user = modelBuilder.Entity<User>();

            user.HasKey(u => u.Id);
            user.Property(u => u.Id).ValueGeneratedOnAdd();
            user.Property(u => u.Name).IsRequired().HasMaxLength(200);
        }
    }
}
