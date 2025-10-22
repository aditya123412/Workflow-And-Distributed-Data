using DataAccessService.Services;
using DataCommonClasses.Data;
using Microsoft.AspNetCore.Mvc;

namespace DataAccessService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataAccessController : ControllerBase
    {
        private readonly ILogger<DataAccessController> _logger;
        private readonly StorageOrchestratorService _storageOrchestratorService;

        public DataAccessController(ILogger<DataAccessController> logger, StorageOrchestratorService storageOrchestratorService)
        {
            _logger = logger;
            _storageOrchestratorService = storageOrchestratorService;
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

        [HttpPost(Name = "Delete")]
        public DataResponse Delete(DataRequest request)
        {
            return new DataResponse();
        }
    }
}
