using Microsoft.AspNetCore.Mvc;
using MVCVirtualPetPractice.Models;
using MVCVirtualPetPractice.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCVirtualPetPractice.Controllers
{
    public class PetController : Controller
    {

        //public List<Pet> pets = new List<Pet>()
        //{
        //    new Pet() {Id = 1, Name = "Fido"},
        //    new Pet() {Id = 2, Name = "Spot"},
        //    new Pet() {Id = 3, Name = "Bella"}
        //};

        PetRepository petRepo;

        public PetController()
        {
            petRepo = new PetRepository();
        }

        public ViewResult Index()
        {

            //var petRepo = new PetRepository();
            IEnumerable<Pet> model = petRepo.GetAll();
            return View(model);
        }

        public ViewResult Details(int id)
        {
            // Moved to PetRepository 
            //var listIndex = id - 1;
            //var model = pets[listIndex];
            //return View(model);

            //var petRepo = new PetRepository();
            Pet model = petRepo.GetById(id);
            return View(model);

        }
    }
}
