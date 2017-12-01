using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AppMVC.Models;

namespace AppMVC.Controllers
{
    public class usersController : ApiController
    {
        // GET: api/users
        public HttpResponseMessage Get()
        {

            var fakeReturn = new List<UserEntities>();
            fakeReturn.Add(new UserEntities
            {
                firstName = "yu",
                lastName = "jen",
                username = "ycj",
                Password = "1234",
                Id = 1
            });
            fakeReturn.Add(new UserEntities
            {
                firstName = "KK",
                lastName = "jen2",
                username = "ycj2",
                Password = "1234",
                Id = 2
            });
            return Request.CreateResponse(HttpStatusCode.OK, fakeReturn);

            //return new string[] { "value1", "value2" };
        }

        // GET: api/users/User/5
        [HttpGet]
        [Route("api/users/Account/{id}")]
        public HttpResponseMessage Account(int username)
        {
            var fakeReturn = new UserEntities
            {
                firstName = "KK",
                lastName = "jen2",
                username = "ycj2",
                Password = "1234",
                Id = 2
            };
            return Request.CreateResponse(HttpStatusCode.OK, fakeReturn);
        }

        // POST: api/users
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/users/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/users/5
        public void Delete(int id)
        {
        }
    }
}
