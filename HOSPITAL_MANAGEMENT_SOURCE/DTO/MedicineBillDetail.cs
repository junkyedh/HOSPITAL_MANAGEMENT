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
    }
}
