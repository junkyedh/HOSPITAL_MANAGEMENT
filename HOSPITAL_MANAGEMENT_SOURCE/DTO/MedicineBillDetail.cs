using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOSPITAL_MANAGEMENT_SOURCE.DTO
{
    public class MedicineBillDetailDTO
    {
        public int MedicineID { get; set; }
        public int BillID { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public MedicineBillDetailDTO() { }

        public MedicineBillDetailDTO(int billID, int medicineID, int quantity, decimal price)
        {
            this.BillID = billID;
            this.MedicineID = medicineID;
            this.Quantity = quantity;
            this.Price = price;
        }
    }
}
