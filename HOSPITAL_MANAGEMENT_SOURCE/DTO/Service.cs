using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOSPITAL_MANAGEMENT_SOURCE.DTO
{
    public class ServiceDTO
    {
        public int ServiceID { get; set; }
        public string ServiceName { get; set; }
        public decimal Price { get; set; }

        public ServiceDTO() { }

        public ServiceDTO(int serviceID, string serviceName, decimal price)
        {
            ServiceID = serviceID;
            ServiceName = serviceName;
            Price = price;
        }
    }
}
