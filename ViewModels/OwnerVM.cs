using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetOwner.ViewModels
{
    public class OwnerVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<PetVM> Pets { get; set; }
    }
}