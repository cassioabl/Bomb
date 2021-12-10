using Bomb.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;

namespace Bomb.Infra.Data.Context
{
    public class BombContext : DbContext
    {
        public BombContext()
        {

        }

        public BombContext(DbContextOptions<BombContext> options)
            :base(options)
        {

        }

        public DbSet<DisarmAttempt> DisarmAttempts { get; set; }
        public DbSet<CuttedWire> CuttedWires { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<CuttedWire>()
                .Property(e => e.ColorEnum)
                .HasConversion(
                    v => v.ToString(),
                    v => (WireColorEnum)Enum.Parse(typeof(WireColorEnum), v));
        }

        public override int SaveChanges()
        {
            var addedEntries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is Entity && (
                    e.State == EntityState.Added));

            var modifiedEntries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is Entity && (
                    e.State == EntityState.Modified));

            foreach (var entityEntry in modifiedEntries)
            {
                entityEntry.Property("Created").IsModified = false;
            }

            foreach (var entityEntry in addedEntries)
            {
                ((Entity)entityEntry.Entity).Created = DateTime.Now;
            }

            return base.SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("ServerConnection"));
        }
    }
}
