using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCVirtualPetPractice.Models;

namespace MVCVirtualPetPractice.Repositories
{
    public class MockPetRepository : IPetRepository
    {
        public void Create(Pet pet)
        {
            throw new NotImplementedException();
        }

        public void Delete(Pet pet)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pet> GetAll()
        {
            throw new NotImplementedException();
        }

        public Pet GetById(int id)
        {
            return new Pet() { Id = id };
        }

        public void Update(Pet pet)
        {
            throw new NotImplementedException();
        }
    }
}
