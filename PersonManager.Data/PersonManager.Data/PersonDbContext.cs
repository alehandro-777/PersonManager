using Microsoft.EntityFrameworkCore;
using System;

namespace PersonManager.Data
{
    using Microsoft.EntityFrameworkCore;
    using PersonManager.Data.Entities;

    public class PersonDbContext : DbContext
    {
        public PersonDbContext(DbContextOptions<PersonDbContext> options)
            : base(options)
        {
        }

        public DbSet<Person> Persons => Set<Person>();
        public DbSet<Anschrift> Anschriften => Set<Anschrift>();
        public DbSet<Telefonverbindung> Telefonverbindungen => Set<Telefonverbindung>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasMany(p => p.Anschriften)
                .WithOne(a => a.Person)
                .HasForeignKey(a => a.PersonId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Person>()
                .HasMany(p => p.Telefonnummern)
                .WithOne(t => t.Person)
                .HasForeignKey(t => t.PersonId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }


}
