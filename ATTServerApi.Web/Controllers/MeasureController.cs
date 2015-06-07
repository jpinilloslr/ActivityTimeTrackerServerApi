using System.Collections.Generic;
using System.Web.Http;
using ATTServerApi.Model;
using ATTServerApi.Services.Contracts;

namespace ATTServerApi.Web.Controllers
{
    public class MeasureController : ApiController
    {
        private readonly IMeasuresGenerator _measuresGenerator;


        public MeasureController(IMeasuresGenerator measuresGenerator)
        {
            _measuresGenerator = measuresGenerator;
        }

        // GET api/measure
        public IEnumerable<Measure> Get()
        {
            return _measuresGenerator.Measures;
        }

    }
}
