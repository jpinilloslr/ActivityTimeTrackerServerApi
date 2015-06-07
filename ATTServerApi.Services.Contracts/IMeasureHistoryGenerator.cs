using ATTServerApi.Model;

namespace ATTServerApi.Services.Contracts
{
    public interface IMeasureHistoryGenerator
    {
        MeasureHistory MeasureHistory { get; }
    }
}
