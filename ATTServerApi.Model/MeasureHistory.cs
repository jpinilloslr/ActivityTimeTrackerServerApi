using System.Collections.Generic;

namespace ATTServerApi.Model
{
    public class MeasureHistory
    {
        public string MeasureName { get; set; }
        public List<MeasureHistoryEntry> Entries { get; set; }
    }
}
