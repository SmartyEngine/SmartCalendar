using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartCalendar.Models;
using SmartCalendar.Controllers;
using System.Web.Http;
using System.Net;
using System.Web.Http.Results;
using Moq;
using SmartCalendar.Models.Abstracts;
using System.Threading.Tasks;
using System.Net.Http;
using SmartCalendar.Models.EFRepositories;
using System.Collections.Generic;

namespace SmartCalendar.Tests.Controllers
{
    [TestClass]
    public class EventControllerTest
    {

        [TestMethod]
        public async Task UpdateEventTest_BadRequest()
        {
            //arrange            
            var mockRepository = new Mock<EventRepository>();
            var controller = new EventController(mockRepository.Object);
            controller.Request = new HttpRequestMessage();
            controller.Request.SetConfiguration(new HttpConfiguration());
            
            var testEvent = new Event()
            {
                Id = "1"               
            };
            //act
            controller.ModelState.AddModelError("","");
            var response = await controller.UpdateEvent(testEvent);   
         
            //assert
            Assert.IsNotNull(response);            
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);            
            //Assert.AreEqual(10, contentResult.Content.Id);
        }

        [TestMethod]
        public async Task UpdateEventTest_NotFound()
        {
            //arrange            
            var mockRepository = new Mock<EventRepository>();
            var controller = new EventController(mockRepository.Object);
            controller.Request = new HttpRequestMessage();
            controller.Request.SetConfiguration(new HttpConfiguration());
            
            //act
            var response = await controller.UpdateEvent(null);

            //assert
            Assert.IsNotNull(response);
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);            
        }

        //[TestMethod]
        //public async Task UpdateEventTest_Accept()
        //{
        //    var events = new List<Event>(){
        //        new Event() {
        //            Id = "1",
        //            DateAdd = DateTime.Now,
        //            DateStart = DateTime.Now,
        //            DateEnd = DateTime.Now,
        //            Title = "testTitle",
        //            Description = "testDescription",
        //            Category = Category.Fun,
        //            Location = "testLocation"
        //        }
        //    };
        //    var mockContext = new Mock<ApplicationDbContext>();
           
        //    var mockRepository = new Mock<EventRepository>();
            
        //    var controller = new EventController(mockRepository.Object);
            
        //    controller.Request = new HttpRequestMessage();
        //    controller.Request.SetConfiguration(new HttpConfiguration());
            
        //    //act
        //    controller.ModelState.Clear();
        //    var response = await controller.UpdateEvent(null);
        //    //assert
        //    Assert.IsNotNull(response);
        //    Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        //}        


    }
}
