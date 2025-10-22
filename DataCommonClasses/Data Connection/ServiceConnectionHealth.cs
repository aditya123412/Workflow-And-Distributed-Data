using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCommonClasses.Data_Connection
{
    public class ServiceConnectionHealth
    {
        public bool IsHealthy { get; set; }
        public string? HealthMessage { get; set; }
        public ServiceConnectionHealth()
        {
            IsHealthy = true;
            HealthMessage = "Service is healthy.";
        }
    }
}
