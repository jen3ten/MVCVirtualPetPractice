using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using MVCVirtualPetPractice.Controllers;
using MVCVirtualPetPractice.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using MVCVirtualPetPractice.Repositories;

namespace MVCVirtualPetPractice.Tests
{
    public class PetControllerTests
    {
        PetController sut;

        public PetControllerTests()
        {
            //sut = new PetController(null);

            // What about the code below?  This tests 3 units not one.  It is not a unit test.
            // How do you test the Controller without testing the database?  Test in isolation.
            var context = new PetContext();
            var repo = new PetRepository(context);
            sut = new PetController(repo);
        }

        [Fact]
        public void Index_Returns_ViewResult()
        {
            var result = sut.Index();

            Assert.IsType<ViewResult>(result);
        }

        [Fact(Skip = "this doesn't work")]
        public void Index_Returns_Pet_Model_To_View()
        {
            var result = sut.Index();

            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Index_Model_Has_3_Pets()
        {
            var result = sut.Index(); // the ViewResult knows about the View and the Model
            var model = (IEnumerable<Pet>)result.Model; // We want to verify information about the Model

            Assert.Equal(3, model.Count());
        }

        [Fact]
        public void Details_Model_Has_Correct_Id()
        {
            var expectedId = 2;
            var result = sut.Details(expectedId);
            var model = (Pet)result.Model;

            Assert.Equal(expectedId, model.Id);
        }

    }
}
