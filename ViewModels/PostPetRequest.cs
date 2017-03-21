using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetOwner.ViewModels
{
    public class PostPetRequest
    {
        public int OwnerId { get; set; }
        public string Name { get; set; }
    }
}