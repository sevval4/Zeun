using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using Zeun.Web.Controllers;
using Zeun.Web.Models;

namespace Zeun.Web.Tests.Controllers
{
    [TestFixture]
    public class HomeControllerTests
    {
        [Test]
        public void Index_ReturnsViewResult()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<HomeController>>();
            var controller = new HomeController(loggerMock.Object);

            // Act
            var result = controller.Index();

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
        }

        [Test]
        public void Privacy_ReturnsViewResult()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<HomeController>>();
            var controller = new HomeController(loggerMock.Object);

            // Act
            var result = controller.Privacy();

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
        }

        [Test]
        public void Error_ReturnsViewResultWithModelError()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<HomeController>>();
            var controller = new HomeController(loggerMock.Object);

            // Act
            var result = controller.Error() as ViewResult;
            var model = result.Model as ErrorViewModel;

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
            Assert.IsNotNull(model);
            Assert.IsNotNull(model.RequestId);
        }

        [Test]
        public void Error_ModelNotNull()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<HomeController>>();
            var controller = new HomeController(loggerMock.Object);

            // Act
            var result = controller.Error() as ViewResult;

            // Assert
            Assert.IsNotNull(result.Model);
        }

        [Test]
        public void Error_ModelIsErrorViewModel()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<HomeController>>();
            var controller = new HomeController(loggerMock.Object);

            // Act
            var result = controller.Error() as ViewResult;

            // Assert
            Assert.IsInstanceOf<ErrorViewModel>(result.Model);
        }
    }
}
