using System.Collections.Generic;
using System.Linq;
using Xunit;
using MVCVirtualPetPractice.Controllers;
using MVCVirtualPetPractice.Models;
using Microsoft.AspNetCore.Mvc;
using MVCVirtualPetPractice.Repositories;
using NSubstitute;

namespace MVCVirtualPetPractice.Tests
{
    public class PetControllerTests
    {
        PetController sut;
        private IPetRepository repo;

        public PetControllerTests()
        {
            //sut = new PetController(null);

            // What about the code below?  This tests 3 units not one.  It is not a unit test.
            // How do you test the Controller without testing the database?  Test in isolation.
            // var context = new PetContext();
            // var repo = new PetRepository(context);

            // Use a mock substitute for PetRepo
            repo = Substitute.For<IPetRepository>();
            sut = new PetController(repo);
        }

        [Fact]
        public void Index_Returns_ViewResult()
        {
            var result = sut.Index();

            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Index_Returns_Pet_Model_To_View()
        {
            var result = sut.Index();

            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Index_Model_Has_3_Pets()
        {
            // Refactored this test to use NSubstitute and the IPetRepo
            // Added the repo assignment to NSubstitute and defined what GetAll() returns using the NSubstitute method called Returns()
            // This line was moved to the constructor of the test
            // var repo = Substitute.For<IPetRepository>();
            // Look at the Index() method to see whats required.  Its calls GetAll(), so let's define GetAll() for our substitute
            repo.GetAll().Returns(new List<Pet>
            {
                new Pet(), new Pet(), new Pet()
            });

            // This line was moved to the constructor of the test
            // var sut = new PetController(repo);

            var result = sut.Index(); // the ViewResult knows about the View and the Model
            var model = (IEnumerable<Pet>)result.Model; // We want to verify information about the Model

            Assert.Equal(3, model.Count());
        }

        [Fact]
        public void Index_Model_Returns_Expected_Model()
        {
            // This test is a rewrite of the previous Index_Model_Has_3_Pets to make it more generic.  Do we really care how many pets are returned?  We just want to make sure a List is returned
            var expectedModel = new List<Pet>();
            repo.GetAll().Returns(expectedModel);

            var result = sut.Index();
            var model = (IEnumerable<Pet>)result.Model;

            Assert.Equal(expectedModel, model);
        }

        // This test uses the mock pet repository
        [Fact]
        public void Details_Model_Is_Expected_Model()
        {
            // These 2 lines allow the test to interact with the database through the repository
            // var context = new PetContext();
            // var repo = new PetRepository(context);

            // This line allows the test to interact with a manually created Mock repository
            // var repo = new MockPetRepository();

            // All code below uses NSubstitute
            var expectedId = 2;
            // The properties of the object don't matter anymore, so we rewrote the following line
            // var expectedModel = new Pet() { Id = expectedId };
            var expectedModel = new Pet();

            // This line allows the test to interact with NSubstitute
            // It was moved to the constructor for the test
            // var repo = Substitute.For<IPetRepository>();
            // the following line tells NSubstitute how you want it to behave
            repo.GetById(expectedId).Returns(expectedModel);

            // This line was moved to the constructor for the test
            // var sut = new PetController(repo);

            var result = sut.Details(expectedId);
            var model = (Pet)result.Model;

            // We originally said the ids will be equal and named this test Details_Model_Has_Correct_Id()
            // Assert.Equal(expectedId, model.Id);

            // This assertion shows the models are the same, we don't need to look at the individual properties
            Assert.Equal(expectedModel, model);
        }


    }
}
