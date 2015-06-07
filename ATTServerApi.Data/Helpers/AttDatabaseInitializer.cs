using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATTServerApi.Data.Helpers
{
    public class AttDatabaseInitializer : DropCreateDatabaseIfModelChanges<AttDbContext>
    {
        protected override void Seed(AttDbContext context)
        {
            
        }
    }
}
