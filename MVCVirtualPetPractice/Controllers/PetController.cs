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
        // The was moved to the PetRepository
        //public List<Pet> pets = new List<Pet>()
        //{
        //    new Pet() {Id = 1, Name = "Fido"},
        //    new Pet() {Id = 2, Name = "Spot"},
        //    new Pet() {Id = 3, Name = "Bella"}
        //};

        IPetRepository petRepo;

        public PetController(IPetRepository petRepo)
        {
            // The code below depends on details of a lower level abstraction.  Instead  pass them in through the parameter
            // petRepo = new PetRepository(new PetContext());
            // our PetRespository constructor needs a db parameter.  If we did it this way each petRepo would create a separate connection to a database context.  This isn't the best way to do this.  We only want to create one and use the same one while the project is running.
            // We need a way to use Dependency Inversion Principle.  Too many dependencies here.  Controller -> Repository -> Context -> etc.

            this.petRepo = petRepo;

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

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Pet pet)
        {
            petRepo.Create(pet);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ViewResult Delete(int id)
        {
            var model = petRepo.GetById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(Pet pet)
        {
            petRepo.Delete(pet);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            var model = petRepo.GetById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Pet pet)
        {
            petRepo.Update(pet);
            return RedirectToAction("Details/" + pet.Id);
        }
    }
}
