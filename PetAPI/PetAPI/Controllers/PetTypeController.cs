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

namespace PetAPI.Controllers
{
    [RoutePrefix("api/PetType")]
    public class PetTypeController : ApiController
    {
        //READ
        [HttpGet]
        [Route("GetAllPetTypes")]
        public List<dynamic> getAllPetTypes()
        {
            PetDBEntities db = new PetDBEntities();
            db.Configuration.ProxyCreationEnabled = false;
            return getPetTypeList(db.Pet_Type.ToList());
        }

        private List<dynamic> getPetTypeList(List<Pet_Type> forPetType)
        {
            List<dynamic> dynamicPetTypes = new List<dynamic>();
            foreach (Pet_Type PetType in forPetType)
            {
                dynamic dynamicPetType = new ExpandoObject();
                dynamicPetType.Pet_Type_ID = PetType.Pet_Type_ID;
                dynamicPetType.Pet_Type1 = PetType.Pet_Type1;
                dynamicPetTypes.Add(dynamicPetType);
            }
            return dynamicPetTypes;
        }

        //CREATE LIST
        [HttpPost]
        [Route("CreatePetTypes")]
        public List<dynamic> CreatePetTypes([FromBody] List<Pet_Type> petTypes)
        {
            if (petTypes != null)
            {
                PetDBEntities db = new PetDBEntities();
                db.Configuration.ProxyCreationEnabled = false;
                db.Pet_Type.AddRange(petTypes);
                db.SaveChanges();
                return getAllPetTypes();
            }
            else
            {
                return null;
            }
        }

        //CREATE
        [HttpPost]
        [Route("CreatePetType")]
        public List<dynamic> CreatePetType([FromBody] Pet_Type petType)
        {
            if (petType != null)
            {
                PetDBEntities db = new PetDBEntities();
                db.Configuration.ProxyCreationEnabled = false;
                db.Pet_Type.Add(petType);
                db.SaveChanges();
                return getAllPetTypes();
            }
            else
            {
                return null;
            }
        }

        //UPDATE
        [HttpPut]
        [Route("UpdatePetType")]
        public List<dynamic> UpdatePetType([FromBody] Pet_Type pet_Type)
        {
            if (pet_Type != null)
            {
                PetDBEntities db = new PetDBEntities();
                db.Configuration.ProxyCreationEnabled = false;
                Pet_Type objPrev = db.Pet_Type.Where(p => p.Pet_Type_ID == pet_Type.Pet_Type_ID).FirstOrDefault();
                objPrev.Pet_Type1 = pet_Type.Pet_Type1;
                db.SaveChanges();
                return getAllPetTypes();
            }
            else
            {
                return null;
            }

        }

        //DELETE
        [HttpDelete]
        [Route("DeletePetType")]
        public List<dynamic> DeletePetType([FromBody] Pet_Type pet_Type)
        {
            PetDBEntities db = new PetDBEntities();
            db.Configuration.ProxyCreationEnabled = false;
            Pet_Type objPrev = db.Pet_Type.Where(p => p.Pet_Type_ID == pet_Type.Pet_Type_ID).FirstOrDefault();
            if (objPrev != null)
            {
                db.Pet_Type.Remove(objPrev);
                db.SaveChanges();
                return getAllPetTypes();
            }
            else
            {
                return null;
            }

        }
    }
}
    
