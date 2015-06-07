
using System;

namespace ATTServerApi.Model
{
    public class Activity
    {
        public int Id { get; set; }
     
        public string WindowText { get; set; }

        public string ProcessName { get; set; }

        public string ModuleFilename { get; set; }

        public double Life { get; set; }

        public DateTime Date { get; set; }

    }
}
