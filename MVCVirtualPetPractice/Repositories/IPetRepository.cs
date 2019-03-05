using MVCVirtualPetPractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCVirtualPetPractice.Repositories
{
    public interface IPetRepository
    {
        IEnumerable<Pet> GetAll();
        Pet GetById(int id);
        void Create(Pet pet);
        void Delete(Pet pet);
        void Update(Pet pet);
    }
}
