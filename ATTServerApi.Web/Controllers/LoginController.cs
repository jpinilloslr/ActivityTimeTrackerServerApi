using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ATTServerApi.Services.Contracts;
using ATTServerApi.Web.Models;

namespace ATTServerApi.Web.Controllers
{
    public class LoginController : ApiController
    {
        private readonly IAuthenticatorProvider _authenticatorProvider;

        public LoginController(IAuthenticatorProvider authenticatorProvider)
        {
            _authenticatorProvider = authenticatorProvider;
        }

        public HttpResponseMessage Post([FromBody]Login login)
        {
            var response = new HttpResponseMessage();
            var user = _authenticatorProvider.Login(login.Username, login.Password);

            if (null != user)
            {
                response = Request.CreateResponse(HttpStatusCode.Accepted, user);
            }
            else
            {
                response.StatusCode = HttpStatusCode.Forbidden;
            }

            return response;
        }

    }
}
