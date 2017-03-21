using AutoMapper;
using log4net;
using Newtonsoft.Json;
using PetOwner.Models.AppDbContext;
using PetOwner.Models.Entity;
using PetOwner.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetOwner.Service
{
    public class PetOwnerService
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(PetOwnerService));

        public string GetOwners()
        {
            IEnumerable<OwnerVM> ownersVM;
            string result = string.Empty;

            try
            {
                using (var db = new PetOwnerDbContext())
                {
                    IEnumerable<Owner> owners = db.Owners.ToList();
                    ownersVM = Mapper.Map<IEnumerable<Owner>, IEnumerable<OwnerVM>>(owners);
                }
                result = JsonConvert.SerializeObject(ownersVM, Formatting.Indented);
            }
            catch (Exception ex)
            {
                log.Error("Exception while sending owners data", ex);
            }
            
            return result;
        }

        public void AddOwner(string name)
        {
            try
            {
                using (var db = new PetOwnerDbContext())
                {
                    db.Owners.Add(new Owner() { Name = name });
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                log.Error("Exception while adding new owner", ex);
            }
        }

        public void DeleteOwner(int id)
        {
            try
            {
                using (var db = new PetOwnerDbContext())
                {
                    Owner owner = db.Owners.FirstOrDefault(o => o.Id == id);
                    if (owner != null)
                    {
                        db.Owners.Remove(owner);
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Exception while deleting owner", ex);
            }
        }

        public void AddPet(string name, int ownerId)
        {
            try
            {
                using (var db = new PetOwnerDbContext())
                {
                    Owner owner = db.Owners.FirstOrDefault(o => o.Id == ownerId);
                    if (owner != null)
                    {
                        owner.Pets.Add(new Pet() { Name = name });
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Exception while adding new pet", ex);
            }
        }

        public void DeletePet(int id)
        {
            try
            {
                using (var db = new PetOwnerDbContext())
                {
                    Pet pet = db.Pets.FirstOrDefault(p => p.Id == id);
                    if (pet != null)
                    {
                        db.Pets.Remove(pet);
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Exception while deleting pet", ex);
            }

        }
    }
}