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

        public PrescriptionDetailDTO() { }

        public PrescriptionDetailDTO(int medicineID, int prescriptionID, int quantity, string instruction)
        {
            MedicineID = medicineID;
            PrescriptionID = prescriptionID;
            Quantity = quantity;
            Instruction = instruction;
        }
    }
}
