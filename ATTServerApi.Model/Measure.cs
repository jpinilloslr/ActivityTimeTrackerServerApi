
namespace ATTServerApi.Model
{
    public class Measure
    {
        public string Name { get; set; }
        public double Time { get; set; }
        public double TimeToday { get; set; }
        public double TimeMonthAccumulation { get; set; }
        public double TimeRestAccumulation { get; set; }
    }
}
