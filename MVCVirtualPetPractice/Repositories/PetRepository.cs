using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCVirtualPetPractice.Models;

namespace MVCVirtualPetPractice.Repositories
{
    public class PetRepository
    {
        // Responsible for retrieving pet data

        public List<Pet> pets = new List<Pet>() {
            new Pet() {Id = 1, Name = "Fido"},
            new Pet() {Id = 2, Name = "Spot"},
            new Pet() {Id = 3, Name = "Bella"}
        };

        public IEnumerable<Pet> GetAll()
        {
            return pets;
        }

        public Pet GetById(int id)
        {
            var listIndex = id - 1;
            var model = pets[listIndex];
            return model;
        }
    }
}
