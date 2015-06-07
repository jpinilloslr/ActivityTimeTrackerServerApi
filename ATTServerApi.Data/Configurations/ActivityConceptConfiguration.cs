using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATTServerApi.Model;

namespace ATTServerApi.Data.Configurations
{
    public class ActivityConceptConfiguration 
        : EntityTypeConfiguration<ActivityConcept>
    {
        public ActivityConceptConfiguration()
        {
            
        }
    }
}
