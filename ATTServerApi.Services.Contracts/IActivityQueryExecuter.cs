using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATTServerApi.Model;

namespace ATTServerApi.Services.Contracts
{
    public interface IActivityQueryExecuter
    {
        CompilerResults CompilerResults { get; }
        IEnumerable<Activity> Query(IQueryable<Activity> activities, String query);
    }
}
