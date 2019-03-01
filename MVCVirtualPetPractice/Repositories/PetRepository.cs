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

        // This was moved to seed data in OnModelCreating in the DataContext
        //public List<Pet> pets = new List<Pet>() {
        //    new Pet() {Id = 1, Name = "Fido"},
        //    new Pet() {Id = 2, Name = "Spot"},
        //    new Pet() {Id = 3, Name = "Bella"}
        //};

        // This constructor requires an instance of a PetContext.  The db is then assigned to a private db field.
        PetContext db;
        public PetRepository(PetContext db)
        {
            this.db = db;
        }

        public IEnumerable<Pet> GetAll()
        {
            //return pets;  
            // How do we get this information now?

            return db.Pets.ToList();  // This is the property we defined in our PetContext.  It needs to be converted ToList() so that we are returning a list and not a dbSet
        }

        public Pet GetById(int id)
        {
            //var listIndex = id - 1;
            //var model = pets[listIndex];
            //return model;
            // We're going to replace this with a connection to our data context

            return db.Pets.Single(pet => pet.Id == id);
            // This uses a lambda function and anonymous function to select a single pet where the following criteria exists, where the pet id is equal to the id we pass it
        }

        public void Create(Pet pet)
        {
            db.Pets.Add(pet);
            db.SaveChanges();
        }

        public void Delete(Pet pet)
        {
            db.Pets.Remove(pet);
            db.SaveChanges();
        }

        public void Update(Pet pet)
        {
            db.Pets.Update(pet);
            db.SaveChanges();
        }



    }
}
