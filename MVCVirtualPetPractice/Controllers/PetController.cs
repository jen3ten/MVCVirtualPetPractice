using Microsoft.AspNetCore.Mvc;
using MVCVirtualPetPractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCVirtualPetPractice.Controllers
{
    public class PetController : Controller
    {
        public ViewResult Index()
        {
            var pets = new List<Pet>()
            {
                new Pet() {Id = 1, Name = "Fido"},
                new Pet() {Id = 2, Name = "Spot"},
                new Pet() {Id = 3, Name = "Bella"}
            };

            return View(pets);
        }
    }
}
