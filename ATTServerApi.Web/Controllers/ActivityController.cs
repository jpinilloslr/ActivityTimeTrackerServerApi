using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using ATTServerApi.Data.Contracts;
using ATTServerApi.Model;

namespace ATTServerApi.Web.Controllers
{
    public class ActivityController : BaseApiController
    {

        public ActivityController(IAttUow uow)
        {
            Uow = uow;
        }

        public IEnumerable<Activity> Get()
        {
            return Uow.Activities.GetAll();
        }
        
        public Activity Get(int id)
        {
            return Uow.Activities.GetById(id);
        }

        public IEnumerable<Activity> GetLasts(int count)
        {
            var result = Uow.Activities.GetAll();
            return result.OrderBy(m => m.Id).Skip(result.Count() - count);
        }

        // POST api/activity
        public HttpResponseMessage Post(List<Activity> activities)
        {
            foreach (var activity in activities)
            {
                Uow.Activities.Add(activity);                  
            }
            Uow.Commit();
            return new HttpResponseMessage(HttpStatusCode.Created);
        }        


    }
}
