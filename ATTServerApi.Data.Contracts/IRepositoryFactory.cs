using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATTServerApi.Data.Contracts
{
    public interface IRepositoryFactory
    {
        IActivityConceptRepository CreateActivityConceptRepository();
        IActivityRepository CreateActivityRepository();
        IFilterRuleRepository CreatFilterRuleRepository();
    }
}
