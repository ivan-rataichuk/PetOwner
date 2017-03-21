using PetOwner.Models.Entity;
using SQLite.CodeFirst;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PetOwner.Models.AppDbContext
{
    public class PetOwnerDbContext : DbContext
    {

        public PetOwnerDbContext() : base("sqliteConnection")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<PetOwnerDbContext>());
        }


        public DbSet<Owner> Owners { get; set; }

        public DbSet<Pet> Pets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Owner>()
            .HasMany(o => o.Pets)
            .WithOptional()
            .WillCascadeOnDelete(true);

            var sqliteConnectionInitializer = new PetOwnerDbInitializer(modelBuilder);
            Database.SetInitializer(sqliteConnectionInitializer);
        }
    }
}