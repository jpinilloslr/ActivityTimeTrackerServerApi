
using System;

namespace ATTServerApi.Data.Contracts
{
    public interface IAttUow : IDisposable
    {
        void Commit();
        IActivityRepository Activities { get; }
        IActivityConceptRepository ActivityConcepts { get; }
        IFilterRuleRepository FilterRules { get; }            
    }
}
