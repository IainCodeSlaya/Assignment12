using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.IO;
using System.Dynamic;
using PetAPI.Models;
using System.Data.Entity;

namespace PetAPI.Controllers
{
    [RoutePrefix("api/Pet")]
    public class PetController : ApiController
    {
        //READ
        [HttpGet]
        [Route("GetAllPets")]
        public List<dynamic> getAllPets()
        {
            PetDBEntities db = new PetDBEntities();
            db.Configuration.ProxyCreationEnabled = false;
            return getPetList(db.Pets.Include(pp => pp.Pet_Type).ToList());
        }

        private List<dynamic> getPetList(List<Pet> forPet)
        {
            List<dynamic> dynamicPets = new List<dynamic>();
            foreach (Pet pet in forPet)
            {
                dynamic dynamicPet = new ExpandoObject();
                dynamicPet.Pet_ID = pet.Pet_ID;

                dynamic type = new ExpandoObject();
                type.Pet_Type1 = pet.Pet_Type.Pet_Type1;
                dynamicPet.Pet_Type1 = type;

                dynamicPet.Pet_Price = pet.Pet_Price;
                dynamicPet.Pet_Quantitiy = pet.Pet_Quantitiy;
                dynamicPets.Add(dynamicPet);
            }
            return dynamicPets;
        }

        //CREATE LIST
        [HttpPost]
        [Route("CreatePets")]
        public List<dynamic> CreatePets([FromBody] List<Pet> pets)
        {
            if (pets != null)
            {
                PetDBEntities db = new PetDBEntities();
                db.Configuration.ProxyCreationEnabled = false;
                db.Pets.AddRange(pets);
                db.SaveChanges();
                return getAllPets();
            }
            else
            {
                return null;
            }
        }

        //CREATE
        [HttpPost]
        [Route("CreatePet")]
        public List<dynamic> CreatePet([FromBody] Pet pet)
        {
            if (pet != null)
            {
                PetDBEntities db = new PetDBEntities();
                db.Configuration.ProxyCreationEnabled = false;
                db.Pets.Add(pet);
                db.SaveChanges();
                return getAllPets();
            }
            else
            {
                return null;
            }
        }

        //UPDATE
        [HttpPut]
        [Route("UpdatePet")]
        public List<dynamic> UpdatePet([FromBody] Pet pet)
        {
            if (pet != null)
            {
                PetDBEntities db = new PetDBEntities();
                db.Configuration.ProxyCreationEnabled = false;
                Pet objPrev = db.Pets.Where(p => p.Pet_ID == pet.Pet_ID).FirstOrDefault();
                objPrev.Pet_Type_ID = pet.Pet_Type_ID;
                objPrev.Pet_Price = pet.Pet_Price;
                objPrev.Pet_Quantitiy = pet.Pet_Quantitiy;
                db.SaveChanges();
                return getAllPets();
            }
            else
            {
                return null;
            }

        }

        //DELETE
        [HttpDelete]
        [Route("DeletePet")]
        public List<dynamic> DeletePet([FromBody] Pet pet)
        {
            PetDBEntities db = new PetDBEntities();
            db.Configuration.ProxyCreationEnabled = false;
            Pet objPrev = db.Pets.Where(p => p.Pet_ID == pet.Pet_ID).FirstOrDefault();
            if (objPrev != null)
            {
                db.Pets.Remove(objPrev);
                db.SaveChanges();
                return getAllPets();
            }
            else
            {
                return null;
            }

        }
    }
}

