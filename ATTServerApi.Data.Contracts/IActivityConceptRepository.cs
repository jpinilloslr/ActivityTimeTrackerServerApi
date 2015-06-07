using System;
using System.Linq;
using ATTServerApi.Model;

namespace ATTServerApi.Data.Contracts
{
    public interface IActivityConceptRepository : IRepository<ActivityConcept>
    {
        IQueryable<ActivityConcept> GetAllWithRules();
        ActivityConcept GetByIdWithRules(int id);
    }
}
