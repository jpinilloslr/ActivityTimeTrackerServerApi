using System.Collections.Generic;
using ATTServerApi.Model;

namespace ATTServerApi.Services.Contracts
{
    public interface IMeasuresGenerator
    {
        List<Measure> Measures { get; }
    }
}
