using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOSPITAL_MANAGEMENT_SOURCE.DTO
{
    public class RentMaterialBillDetailDTO
    {
        public int BillID { get; set; }
        public int MaterialID { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public RentMaterialBillDetailDTO() { }

        public RentMaterialBillDetailDTO(int billID, int materialID, int quantity, decimal price)
        {
            BillID = billID;
            MaterialID = materialID;
            Quantity = quantity;
            Price = price;
        }
    }
}
