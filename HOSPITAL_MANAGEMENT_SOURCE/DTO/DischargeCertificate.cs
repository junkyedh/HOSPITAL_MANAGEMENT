using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOSPITAL_MANAGEMENT_SOURCE.DTO
{
    public class DischargeCertificateDTO
    {
        public int DCID { get; set; }
        public int StaffID { get; set; }
        public int PatientID { get; set; }
        public DateTime Date { get; set; }
        public int State { get; set; }

        public DischargeCertificateDTO() { }
        public DischargeCertificateDTO(int dcID, int staffID, int patientID, DateTime date, int state)
        {
            this.DCID = dcID;
            this.StaffID = staffID;
            this.PatientID = patientID;
            this.Date = date;
            this.State = state;
        }
    }
}
