using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetOwner.Models.Entity
{
    public class Owner
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Pet> Pets { get; set; }
    }
}