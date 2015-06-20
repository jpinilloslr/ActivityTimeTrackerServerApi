using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace ATTServerApi.Web.Security
{
    public class BasicAuthenticationMessageHandler : DelegatingHandler
    {
        public const string BasicScheme = "Basic";
        public const string ChallengeAuthenticationHeaderName = "WWW-Authenticate";
        public const char AuthorizationHeaderSeparator = ':';

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.RequestUri.LocalPath.EndsWith("user") || request.RequestUri.LocalPath.EndsWith("activity"))
            {
                var response = await base.SendAsync(request, cancellationToken);
                return response;
            }                

            var authHeader = request.Headers.Authorization;
            if (authHeader == null)
            {
                return await CreateUnauthorizedResponse();
            }
            if (authHeader.Scheme != BasicScheme)
            {
                return await CreateUnauthorizedResponse();
            }

            var encodedCredentials = authHeader.Parameter;
            var credentialBytes = Convert.FromBase64String(encodedCredentials);
            var credentials = Encoding.ASCII.GetString(credentialBytes);
            var credentialParts = credentials.Split(AuthorizationHeaderSeparator);
            if (credentialParts.Length != 2)
            {
                return await CreateUnauthorizedResponse();
            }
            var username = credentialParts[0].Trim();
            var password = credentialParts[1].Trim();

            if (username == "joaquin" && password == "knock123")
            {
                var response = await base.SendAsync(request, cancellationToken);
                return response;              
            }

            return await CreateUnauthorizedResponse();
        }

        private Task<HttpResponseMessage> CreateUnauthorizedResponse()
        {
            var response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            //response.Headers.Add(ChallengeAuthenticationHeaderName, BasicScheme);
            var taskCompletionSource = new TaskCompletionSource<HttpResponseMessage>();
            taskCompletionSource.SetResult(response);
            return taskCompletionSource.Task;
        }
    }
}