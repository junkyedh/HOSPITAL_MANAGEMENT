using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOSPITAL_MANAGEMENT_SOURCE.DTO
{
    public class ExaminationCertificateDTO
    {
        public int ECID { get; set; }
        public int PatientID { get; set; }
        public int StaffID { get; set; }
        public DateTime Date { get; set; }
        public string Result { get; set; }
        public int State { get; set; }

        public ExaminationCertificateDTO() { }

        public ExaminationCertificateDTO(int eCID, int patientID, int staffID, DateTime date, string result, int state)
        {
            ECID = eCID;
            PatientID = patientID;
            StaffID = staffID;
            Date = date;
            Result = result;
            State = state;
        }
    }
}
