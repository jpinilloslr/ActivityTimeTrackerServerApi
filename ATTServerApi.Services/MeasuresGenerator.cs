using System;
using System.Collections.Generic;
using System.Linq;
using ATTServerApi.Data.Contracts;
using ATTServerApi.Model;
using ATTServerApi.Services.Contracts;

namespace ATTServerApi.Services
{
    public class MeasuresGenerator : IMeasuresGenerator
    {
        private readonly IAttUow _attUow;
        private readonly IActivityQueryExecuter _activityQueryExecuter;

        public List<Measure> Measures { get; private set; }

        public MeasuresGenerator(IAttUow uow, IActivityQueryExecuter activityQueryExecuter)
        {
            _attUow = uow;
            _activityQueryExecuter = activityQueryExecuter;

            Measures = new List<Measure>();
            var activityConcepts = _attUow.ActivityConcepts.GetAllWithRules().ToList();

            foreach (var activityConcept in activityConcepts)
            {
                GetMeasuresFromActivityConcept(activityConcept);
            }
        }

        private void GetMeasuresFromActivityConcept(ActivityConcept concept)
        {
            var measure = new Measure()
            {
                Name = concept.Name,
                Time = 0
            };
            
            foreach (var filterRule in concept.Rules)
            {
                try
                {                    
                    var activities = _attUow.Activities.GetAll();
                    var list = _activityQueryExecuter.Query(activities, filterRule.Expression).ToList();

                    /*var sql = "SELECT * FROM Activities";

                    if (!String.IsNullOrEmpty(filterRule.Expression))
                    {
                        sql += " WHERE " + filterRule.Expression;
                    }

                    var list = _attUow.Activities.GetBySQL(sql).ToList();*/
                    var time = list.Sum(m => m.Life);
                    measure.Time += time;

                    var monthList = list.Where(m => m.Date.Year == DateTime.Now.Year &&
                                m.Date.Month == DateTime.Now.Month).ToList();
                    var timeThisMonth = monthList.Sum(m => m.Life);
                    measure.TimeMonthAccumulation += timeThisMonth;

                    var todayList = monthList.Where(m => m.Date.Day == DateTime.Now.Day).ToList();
                    var timeToday = todayList.Sum(m => m.Life);
                    measure.TimeToday += timeToday;
                }
                catch (Exception e)
                {
                    Measures.Add(new Measure() { Name = e.Message, Time = 0.0 });
                }                
            }
            measure.TimeMonthAccumulation -= measure.TimeToday;
            measure.TimeRestAccumulation = Math.Round((measure.Time - measure.TimeMonthAccumulation - measure.TimeToday), 2);
            Measures.Add(measure);
        }
    }
}
