
using System.Collections.Generic;

namespace ATTServerApi.Model
{
    public class ActivityConcept
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<FilterRule> Rules { get; set; }

        public ActivityConcept()
        {
            Rules = new List<FilterRule>();
        }
    }
}
