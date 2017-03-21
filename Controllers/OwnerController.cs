using PetOwner.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PetOwner.Controllers
{
    public class OwnerController : ApiController
    {
        private PetOwnerService petOwnerService;

        // GET: api/Owner
        public string Get()
        {
            petOwnerService = new PetOwnerService();
            return petOwnerService.GetOwners();
        }

        // POST: api/Owner
        public void Post([FromBody]string name)
        {
            petOwnerService = new PetOwnerService();
            petOwnerService.AddOwner(name);
        }

        // DELETE: api/Owner/5
        public void Delete(int id)
        {
            petOwnerService = new PetOwnerService();
            petOwnerService.DeleteOwner(id);
        }
    }
}
