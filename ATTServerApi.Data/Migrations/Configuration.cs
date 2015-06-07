using ATTServerApi.Model;

namespace ATTServerApi.Data.Migrations
{

    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<AttDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(AttDbContext context)
        {

            /*context.Activities.AddOrUpdate(
                a => a.ProcessName,
                new Activity() {ProcessName = "proc1", ModuleFilename = "test1.exe", Time = 54.1, WindowText = "test1"},
                new Activity() {ProcessName = "proc2", ModuleFilename = "test2.exe", Time = 54.2, WindowText = "test2"},
                new Activity() {ProcessName = "proc3", ModuleFilename = "test3.exe", Time = 54.3, WindowText = "test3"}
            );*/
           
        }
    }
}
