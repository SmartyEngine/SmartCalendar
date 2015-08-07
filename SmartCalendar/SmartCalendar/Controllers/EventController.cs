using Microsoft.AspNet.Identity;
using SmartCalendar.Models;
using SmartCalendar.Models.Abstracts;
using SmartCalendar.Models.EFRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SmartCalendar.Controllers
{
    public class EventController : ApiController
    {
        private IRepository repository;

        public EventController(IRepository repos)
        {
            repository = repos;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        [HttpPut]
        public async Task<HttpResponseMessage> UpdateEvent([FromBody]Event item)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
            IdentityResult result = await repository.Update(item);
            HttpResponseMessage errorResult = GetErrorResult(result);

            if (errorResult != null)
            {
                return errorResult;
            }
            return Request.CreateResponse(HttpStatusCode.Accepted, item);
        }        

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }

        #region Helpers
        private HttpResponseMessage GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }

                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }

            return null;
        }
        #endregion
    }
}