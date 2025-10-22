using DataCommonClasses.Data;
using DistributedStorageService.Classes;
using Microsoft.AspNetCore.Mvc;
using DataRequest = DataCommonClasses.Data.DataRequest;

namespace DistributedStorageService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataController : ControllerBase
    {
        private readonly ILogger<DataController> _logger;

        public DataController(ILogger<DataController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "Get")]
        public DataResponse Get(DataRequest request)
        {
            _logger.LogInformation("Received Get request with Key: {Key}", request.ToString(), DateTime.UtcNow);
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
        [HttpPost(Name = "Delete")]
        public DataResponse Delete(DataRequest request)
        {
            return new DataResponse();
        }
    }
}
