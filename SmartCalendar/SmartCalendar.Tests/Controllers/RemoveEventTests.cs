using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SmartCalendar.Controllers;
using SmartCalendar.Models.Abstracts;
using SmartCalendar.Models.EFRepositories;

namespace SmartCalendar.Tests.Controllers
{
    public partial class EventControllerTest
    {
        [TestMethod]
        public async Task RemoveEvent_ShouldReturn_BadRequest_and_NotNullContent()
        {
            //Arrange
            var mockRepository = new Mock<IRepository>();
            var controller = new EventController(mockRepository.Object);
            controller.Request = new HttpRequestMessage();
            controller.Request.SetConfiguration(new HttpConfiguration());

            //Act
            controller.ModelState.AddModelError("", "");
            var response = await controller.RemoveEvent(Int32.Parse(GetDemoEvent().Id));

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public async Task RemoveEvent_ShouldReturn_NotFound_And_NullContent()
        {
            //Arrange
            var mockRepository = new Mock<IRepository>();
            var controller = new EventController(mockRepository.Object);
            controller.Request = new HttpRequestMessage();
            controller.Request.SetConfiguration(new HttpConfiguration());

            //Act
            var response = await controller.RemoveEvent(10);

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
            Assert.IsNull(response.Content);
        }

        [TestMethod]
        public async Task RemoveEvent_ShouldReturnOk()
        {
            //Arrange
            var context = new TestAppContext();
            var item = GetDemoEvent();
            context.Events.Add(item);

            //var mockRepository = new Mock<IRepository>(context);
            var repository = new EventRepository(context);
            var controller = new EventController(repository);
            controller.Request = new HttpRequestMessage();
            controller.Request.SetConfiguration(new HttpConfiguration());
            
            //Act
            var response = await controller.RemoveEvent(Int32.Parse(item.Id));
            
            //Assert
            Assert.IsNotNull(response);
            Assert.IsNull(response.Content);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
