using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ATTServerApi.Web.Models;

namespace ATTServerApi.Web.Controllers
{
    public class UserController : ApiController
    {
        
        // POST api/user
        public HttpResponseMessage Post([FromBody]Login login)
        {
            var response = new HttpResponseMessage();
            if (login.Username == "joaquin" && login.Password == "knock123")
            {
                response.StatusCode = HttpStatusCode.Accepted;
            }
            else
            {
                response.StatusCode = HttpStatusCode.Forbidden;
            }
            return response;
        }
    }
}
