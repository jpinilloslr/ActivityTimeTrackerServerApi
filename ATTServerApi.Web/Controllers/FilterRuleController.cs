using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using ATTServerApi.Data.Contracts;
using ATTServerApi.Model;

namespace ATTServerApi.Web.Controllers
{
    public class FilterRuleController : BaseApiController
    {

        public FilterRuleController(IAttUow uow)
        {
            Uow = uow;
        }

        // GET api/filterrule
        public IEnumerable<FilterRule> Get()
        {
            return Uow.FilterRules.GetAll();
        }

        // GET api/filterrule/5
        public FilterRule Get(int id)
        {
            return Uow.FilterRules.GetById(id);
        }

        // POST api/filterrule
        public HttpResponseMessage Post(FilterRule filterRule)
        {
            var item = Uow.FilterRules.GetById(filterRule.Id);

            //update
            if (null != item)
            {
                item.Name = filterRule.Name;
                item.Description = filterRule.Description;
                item.Expression = filterRule.Expression;

                Uow.FilterRules.Update(item);
                Uow.Commit();
                return new HttpResponseMessage(HttpStatusCode.Accepted);
            }
            else //create
            {
                filterRule.ActivityConcepts.Clear();
                Uow.FilterRules.Add(filterRule);
                Uow.Commit();
                return new HttpResponseMessage(HttpStatusCode.Created);
            }
        }

        // DELETE api/filterrule/5
        public HttpResponseMessage Delete(int id)
        {
            Uow.FilterRules.Delete(id);
            Uow.Commit();
            return new HttpResponseMessage(HttpStatusCode.Accepted);
        }
    }
}
