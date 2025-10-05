using DataCommonClasses.Data;
using Microsoft.AspNetCore.Mvc;

namespace DataAccessService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataAccessController : ControllerBase
    {
        private readonly ILogger<DataAccessController> _logger;

        public DataAccessController(ILogger<DataAccessController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "Get")]
        public DataResponse Get(DataRequest request)
        {
            return new DataResponse();
        }

        [HttpPost(Name = "Save")]
        public DataResponse Put(DataRequest request)
        {
            return new DataResponse();
        }

        [HttpPost(Name = "Update")]
        public DataResponse Update(DataRequest request)
        {
            return new DataResponse();
        }
    }
}
