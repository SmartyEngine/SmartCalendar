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
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using SmartCalendar.Models;

namespace SmartCalendar.Tests.Controllers
{
    public partial class EventControllerTest
    {
        [TestMethod]
        public async Task ShowAllEvents_ShouldReturnOk_And_IsNotNull()
        {
            //Arrange
            var mockRepository = new Mock<IRepository>();
            var controller = new EventController(mockRepository.Object);
            controller.Request = new HttpRequestMessage();
            controller.Request.SetConfiguration(new HttpConfiguration());

            //Act
            var response = await controller.ShowAllEvents(DateTime.Now, DateTime.Now.AddDays(1));

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        }
    }
}
