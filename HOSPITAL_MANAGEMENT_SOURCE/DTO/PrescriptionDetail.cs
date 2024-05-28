using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOSPITAL_MANAGEMENT_SOURCE.DTO
{
    public class PrescriptionDetailDTO
    {
        public int MedicineID { get; set; }
        public int PrescriptionID { get; set; }
        public int Quantity { get; set; }
        public string Instruction { get; set; }
    }
}
