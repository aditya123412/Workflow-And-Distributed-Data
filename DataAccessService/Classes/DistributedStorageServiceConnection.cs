using DataCommonClasses.Data_Connection;

namespace DataAccessService.Classes
{
    public class DistributedStorageServiceConnection
    {
        public ServiceConnectionHealth ServiceConnectionHealth { get; set; }
        public int RefreshIntervalInSeconds { get; set; } = 60;
        public DistributedStorageServiceConnection()
        {
            ServiceConnectionHealth = new ServiceConnectionHealth();
        }
    }
}
