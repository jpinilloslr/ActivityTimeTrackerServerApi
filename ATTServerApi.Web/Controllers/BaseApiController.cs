using System.Web.Http;
using ATTServerApi.Data.Contracts;

namespace ATTServerApi.Web.Controllers
{
    public class BaseApiController : ApiController
    {
        protected IAttUow Uow { get; set; }

        protected override void Dispose(bool disposing)
        {
            if(Uow != null)
                Uow.Dispose();
            base.Dispose(disposing);
        }
    }
}
