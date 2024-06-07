using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOSPITAL_MANAGEMENT_SOURCE.DTO
{
    public class TestCertificateDTO
    {
        public int TCID { get; set; }
        public int PatientID { get; set; }
        public string PatientName { get; set; }
        public int StaffID { get; set; }
        public string StaffName { get; set; }
        public DateTime Date { get; set; }
        public int State { get; set; }

        public TestCertificateDTO() { }

        public TestCertificateDTO(int tCID, int patientID, int staffID, DateTime date, int state)
        {
            this.TCID = tCID;
            this.PatientID = patientID;
            this.StaffID = staffID;
            this.Date = date;
            this.State = state;
        }
    }
}
