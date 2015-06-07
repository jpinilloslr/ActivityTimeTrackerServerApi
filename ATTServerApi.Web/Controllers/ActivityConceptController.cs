using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ATTServerApi.Data.Contracts;
using ATTServerApi.Model;

namespace ATTServerApi.Web.Controllers
{
    public class ActivityConceptController : BaseApiController
    {
        public ActivityConceptController(IAttUow uow)
        {
            Uow = uow;
        }

        public IEnumerable<ActivityConcept> Get()
        {
            return Uow.ActivityConcepts.GetAllWithRules();
        }

        public ActivityConcept Get(int id)
        {
            return Uow.ActivityConcepts.GetByIdWithRules(id);
        }

        public HttpResponseMessage Post([FromBody]ActivityConcept activityConcept)
        {            
            var item = Uow.ActivityConcepts.GetByIdWithRules(activityConcept.Id);
            var response = HttpStatusCode.Accepted;
                       
            //update
            if (null != item)
            {
                item.Name = activityConcept.Name;
                item.Description = activityConcept.Description;
                item.Rules.Clear();
                foreach (var rule in activityConcept.Rules)
                {
                    item.Rules.Add(rule.Id != 0 ? Uow.FilterRules.GetById(rule.Id) : rule);
                }

                Uow.ActivityConcepts.Update(item);                
            }
            else //create
            {
                var rules = activityConcept.Rules.ToList();
                activityConcept.Rules.Clear();

                foreach (var rule in rules)
                {
                    activityConcept.Rules.Add(rule.Id != 0 ? Uow.FilterRules.GetById(rule.Id) : rule);
                }
                Uow.ActivityConcepts.Add(activityConcept);
                response = HttpStatusCode.Created;
            }

            Uow.Commit();
            return new HttpResponseMessage(response);
        }        
      
        public HttpResponseMessage Delete(int id)
        {
            Uow.ActivityConcepts.Delete(id);
            Uow.Commit();
            return new HttpResponseMessage(HttpStatusCode.Accepted);
        }
    }
}
