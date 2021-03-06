using System.Net.NetworkInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using pet_hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace pet_hotel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetsController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public PetsController(ApplicationContext context)
        {
            _context = context;
        }

        // This is just a stub for GET / to prevent any weird frontend errors that 
        // occur when the route is missing in this controller
        [HttpGet]
        public IEnumerable<Pet> GetPets()
        {
            return _context.Pets
                .Include(pet => pet.petOwner); //include = join;

            // return new List<Pet>();  ??
        }

        [HttpPost]
        public Pet Post(Pet pet)
        {
            Console.Write(pet);
            _context.Add(pet);
            _context.SaveChanges();
            return pet;
        }

        [HttpPut("{id}/{inOut}")]
        public Pet Put(int id, string inOut)
        {
            Pet pet = _context.Pets.SingleOrDefault(pet => pet.id == id);
            if(inOut.Equals("checkin"))
            {
                pet.checkedInAt = DateTime.Now;
            } 
            else 
            {
                pet.checkedInAt = null;
            }
            _context.SaveChanges();
            return pet;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Console.WriteLine("in delete");
            Pet pet = _context.Pets.SingleOrDefault(pet => pet.id == id);
            _context.Pets.Remove(pet);
            _context.SaveChanges();
        }



        // [HttpGet]
        // [Route("test")]
        // public IEnumerable<Pet> GetPets() {
        //     PetOwner blaine = new PetOwner{
        //         name = "Blaine"
        //     };

        //     Pet newPet1 = new Pet {
        //         name = "Big Dog",
        //         petOwner = blaine,
        //         color = PetColorType.Black,
        //         breed = PetBreedType.Poodle,
        //     };

        //     Pet newPet2 = new Pet {
        //         name = "Little Dog",
        //         petOwner = blaine,
        //         color = PetColorType.Golden,
        //         breed = PetBreedType.Labrador,
        //     };

        //     return new List<Pet>{ newPet1, newPet2};
        // }
    }
}
