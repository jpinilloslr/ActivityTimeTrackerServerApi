using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using ATTServerApi.Data.Contracts;
using ATTServerApi.Model;
using ATTServerApi.Services.Contracts;

namespace ATTServerApi.Web.Controllers
{    
    public class FilterRuleController : BaseApiController
    {
        private readonly IActivityQueryExecuter _activityQueryExecuter;

        public FilterRuleController(IAttUow uow, IActivityQueryExecuter activityQueryExecuter)
        {
            Uow = uow;
            _activityQueryExecuter = activityQueryExecuter;
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

            _activityQueryExecuter.Query(new List<Activity>().AsQueryable(), filterRule.Expression);
            var compilerResults = _activityQueryExecuter.CompilerResults;

            if (compilerResults.Errors.Count > 0)
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotAcceptable);
                var reason = "Invalid expression: ";

                foreach (var error in compilerResults.Errors)
                {
                    var currentError = error.ToString();
                    currentError = currentError.Substring(currentError.IndexOf("error", System.StringComparison.Ordinal));
                    currentError = currentError.Substring(currentError.IndexOf(":", System.StringComparison.Ordinal) + 1);

                    reason += "<br/>-" + currentError ;
                }
                response.ReasonPhrase = reason;
                return response;
            }

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
