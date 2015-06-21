using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ATTServerApi.Services.Contracts;

namespace ATTServerApi.Web.Controllers
{
    public class LogoutController : ApiController
    {
        private readonly IAuthenticatorProvider _authenticatorProvider;

        public LogoutController(IAuthenticatorProvider authenticatorProvider)
        {
            _authenticatorProvider = authenticatorProvider;
        }

        public HttpResponseMessage Post()
        {
           _authenticatorProvider.Logout();
           return new HttpResponseMessage(HttpStatusCode.Accepted);
        }

    }
}
