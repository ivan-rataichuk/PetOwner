using PetOwner.Models.Entity;
using SQLite.CodeFirst;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PetOwner.Models.AppDbContext
{

    public class PetOwnerDbInitializer : SqliteCreateDatabaseIfNotExists<PetOwnerDbContext>
    {
        public PetOwnerDbInitializer(DbModelBuilder modelBuilder) : base(modelBuilder) 
        {

        }

        protected override void Seed(PetOwnerDbContext context)
        {
            Pet pet1 = new Pet() { Name = "Alice's cat" };
            Pet pet2 = new Pet() { Name = "Alice's dog" };
            Pet pet3 = new Pet() { Name = "Alice's parrot" };
            Pet pet4 = new Pet() { Name = "Alice's monkey" };
            Pet pet5 = new Pet() { Name = "Bob's dog" };
            Pet pet6 = new Pet() { Name = "Charilie's dog" };
            Pet pet7 = new Pet() { Name = "Erin's dog" };

            Owner alice = new Owner { Name = "Alice" };
            alice.Pets = new List<Pet>();
            alice.Pets.Add(pet1);
            alice.Pets.Add(pet2);
            alice.Pets.Add(pet3);
            alice.Pets.Add(pet4);
            context.Owners.Add(alice);

            Owner bob = new Owner { Name = "Bob" };
            bob.Pets = new List<Pet>();
            bob.Pets.Add(pet5);
            context.Owners.Add(bob);

            Owner charlie = new Owner { Name = "Charlie" };
            charlie.Pets = new List<Pet>();
            charlie.Pets.Add(pet6);
            context.Owners.Add(charlie);

            Owner erin = new Owner { Name = "Erin" };
            erin.Pets = new List<Pet>();
            erin.Pets.Add(pet7);
            context.Owners.Add(erin);

            context.SaveChanges();
        }
    }
}