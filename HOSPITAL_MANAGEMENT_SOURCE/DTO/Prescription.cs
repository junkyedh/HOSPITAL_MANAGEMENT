using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOSPITAL_MANAGEMENT_SOURCE.DTO
{
    public class PrescriptionDTO
    {
        public int PrescriptionID { get; set; }
        public int StaffID { get; set; }
        public int PatientID { get; set; }
        public DateTime Date { get; set; }
        public string PatientName { get; set; }
        public string StaffName { get; set; }

        public PrescriptionDTO() { }

        public PrescriptionDTO(int prescriptionID, int staffID, int patientID, DateTime date)
        {
            PrescriptionID = prescriptionID;
            StaffID = staffID;
            PatientID = patientID;
            Date = date;
        }
    }
}
