using PetOwner.Service;
using PetOwner.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PetOwner.Controllers
{
    public class PetController : ApiController
    {
        private PetOwnerService petOwnerService;

        public void Post([FromBody]PostPetRequest request)
        {
            petOwnerService = new PetOwnerService();
            petOwnerService.AddPet(request.Name, request.OwnerId);
        }

        public void Delete(int id)
        {
            petOwnerService = new PetOwnerService();
            petOwnerService.DeletePet(id);
        }
    }
}
