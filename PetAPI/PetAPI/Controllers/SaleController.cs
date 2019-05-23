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
    [RoutePrefix("api/Sale")]
    public class SaleController : ApiController
    {
        //READ
        [HttpGet]
        [Route("GetAllSales")]
        public List<dynamic> GetAllSales()
        {
            PetDBEntities db = new PetDBEntities();
            db.Configuration.ProxyCreationEnabled = false;
            return getSaleList(db.Sale_Pet.ToList());
        }

        private List<dynamic> getSaleList(List<Sale_Pet> forSale)
        {
            List<dynamic> dynamicSales = new List<dynamic>();
            foreach (Sale_Pet sale in forSale)
            {
                dynamic dynamicSale = new ExpandoObject();
                dynamicSale.Sale_ID = sale.Sale_ID;
                dynamicSale.Sale_Amount = sale.Sale_Amount;
                dynamicSales.Add(dynamicSale);
            }
            return dynamicSales;
        }

        //READ Sale Line
        [HttpPost]
        [Route("GetAllSalesWithPets")]
        public List<dynamic> GetAllSalesWithPets()
        {
            PetDBEntities db = new PetDBEntities();
            db.Configuration.ProxyCreationEnabled = false;
            List<Sale_Pet> sales = db.Sale_Pet.Include(pp => pp.Sale_Line_Pet).ToList();
            return GetAllSalesWithPets(sales);
        }

        private List<dynamic> GetAllSalesWithPets(List<Sale_Pet> forSale)
        {
            List<dynamic> dynamicsSales = new List<dynamic>();
            foreach (Sale_Pet sale in forSale)
            {
                dynamic dynamicSale = new ExpandoObject();
                dynamicSale.Sale_ID = sale.Sale_ID;
                dynamicSale.Sale_Amount = sale.Sale_Amount;
                dynamicSale.SaleLine = getSaleLine(sale);
                dynamicsSales.Add(dynamicSale);
            }
            return dynamicsSales;
        }

        private List<dynamic> getSaleLine(Sale_Pet sale)
        {
            PetDBEntities db = new PetDBEntities();
            db.Configuration.ProxyCreationEnabled = false;
            return getSaleLineList(db.Sale_Line_Pet.Include(pp => pp.Pet).Include(PP => PP.Pet.Pet_Type).ToList());
        }

        private List<dynamic> getSaleLineList(List<Sale_Line_Pet> forLine)
        {
            List<dynamic> dynamicLines = new List<dynamic>();
            foreach (Sale_Line_Pet sale_Line in forLine)
            {
                dynamic dynamicLine = new ExpandoObject();

                dynamic type = new ExpandoObject();          
                type.Pet_Type1 = sale_Line.Pet.Pet_Type.Pet_Type1;

                dynamic pet = new ExpandoObject();
                pet.Pet_Type1 = type;
                pet.Pet = sale_Line.Pet.Pet_Price;
                pet.Pet_Quantity = sale_Line.Pet.Pet_Quantitiy;

                dynamicLine.Pet = pet;
                dynamicLine.Pet_Sale_Q = sale_Line.Pet_Sale_Q;
                dynamicLines.Add(dynamicLine);
            }
            return dynamicLines;           
        }    
        /*/CREATE LIST
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

        dynamic type = new ExpandoObject();
                type.Pet_Type1 = pet.Pet_Type.Pet_Type1;
                dynamicPet.Pet_Type1 = type;

                dynamicPet.Pet_Price = pet.Pet_Price;
                dynamicPet.Pet_Quantitiy = pet.Pet_Quantitiy;
                dynamicPets.Add(dynamicPet);
        }*/
    }
}

