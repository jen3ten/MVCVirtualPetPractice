using System;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using MVCVirtualPetPractice.Controllers;

namespace MVCVirtualPetPractice.Tests
{
    public class HomeControllerTests
    {
        HomeController sut;

        public HomeControllerTests()
        {
            sut = new HomeController();
        }

        [Fact]
        public void Index_Returns_ViewResult()
        {
            var result = sut.Index();

            Assert.IsType<ViewResult>(result);
        }

    }
}
