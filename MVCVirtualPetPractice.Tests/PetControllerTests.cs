using System.Collections.Generic;
using System.Linq;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;

using MVCVirtualPetPractice.Controllers;
using MVCVirtualPetPractice.Models;
using MVCVirtualPetPractice.Repositories;

namespace MVCVirtualPetPractice.Tests
{
    public class PetControllerTests
    {
        PetController sut;
        private IPetRepository repo;

        public PetControllerTests()
        {
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
        public void Index_Model_Is_Expected_Model()
        {
            var expectedModel = new List<Pet>();
            repo.GetAll().Returns(expectedModel);

            var result = sut.Index(); // the ViewResult knows about the View and the Model
            var model = (IEnumerable<Pet>)result.Model; // We want to verify information about the Model

            Assert.Equal(expectedModel, model);
        }

        [Fact]
        public void Details_Model_Is_Expected_Model()
        {
            var expectedId = 2;
            var expectedModel = new Pet();
            repo.GetById(expectedId).Returns(expectedModel);

            var result = sut.Details(expectedId);
            var model = (Pet)result.Model;

            Assert.Equal(expectedModel, model);
        }

    }
}
