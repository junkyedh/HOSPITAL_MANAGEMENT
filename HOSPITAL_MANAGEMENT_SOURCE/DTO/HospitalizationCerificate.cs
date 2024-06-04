using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOSPITAL_MANAGEMENT_SOURCE.DTO
{
    public class HospitalizationCertificateDTO
    {
        public int HCID { get; set; }
        public int PatientID { get; set; }
        public int StaffID { get; set; }
        public string Reason { get; set; }
        public DateTime Date { get; set; }
        public int State { get; set; }
        public string PatientName { get; set; }
        public string StaffName { get; set; }


        public HospitalizationCertificateDTO() { }

        public HospitalizationCertificateDTO(int hCID, int patientID, int staffID, String reason, DateTime date, int state)
        {
            this.HCID = hCID;
            this.PatientID = patientID;
            this.StaffID = staffID;
            this.Reason = reason;
            this.Date = date;
            this.State = state;
        }
    }
}
