using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ATTServerApi.Model
{
    public class FilterRule
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Expression { get; set; }

        public string Description { get; set; }

        [IgnoreDataMember]
        public ICollection<ActivityConcept> ActivityConcepts { get; set; }

        public FilterRule()
        {
            ActivityConcepts = new List<ActivityConcept>();
        }
    }
}
