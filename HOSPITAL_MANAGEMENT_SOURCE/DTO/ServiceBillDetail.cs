using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOSPITAL_MANAGEMENT_SOURCE.DTO
{
    public class ServiceBillDetailDTO
    {
        public int BillID { get; set; }
        public int ServiceID { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public ServiceBillDetailDTO() { }

        public ServiceBillDetailDTO(int billID, int serviceID, int quantity, decimal price)
        {
            BillID = billID;
            ServiceID = serviceID;
            Quantity = quantity;
            Price = price;
        }

    }
}
