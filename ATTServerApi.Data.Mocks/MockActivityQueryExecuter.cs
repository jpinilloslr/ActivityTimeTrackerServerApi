using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using ATTServerApi.Model;
using ATTServerApi.Services.Contracts;

namespace ATTServerApi.Data.Mocks
{
    public class MockActivityQueryExecuter : IActivityQueryExecuter
    {
        public CompilerResults CompilerResults { get; private set; }

        public IEnumerable<Activity> Query(IQueryable<Activity> activities, string query)
        {
            return activities;
        }
    }
}
