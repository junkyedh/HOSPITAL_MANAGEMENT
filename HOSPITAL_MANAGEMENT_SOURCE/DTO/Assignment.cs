using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOSPITAL_MANAGEMENT_SOURCE.DTO
{
    public class AssignmentDTO
    {
        public int AssignID { get; set; }
        public int PatientID { get; set; }
        public DateTime Date { get; set; }
        public DateTime DischargedDate { get; set; }
        public DateTime HospitalizateDate { get; set; }
        public string PatientName { get; set; } // Thêm thông tin chi tiết

        public AssignmentDTO() { }

        public AssignmentDTO(int assignID, int patientID, DateTime date, DateTime dischargedDate, DateTime hospitalizateDate, string patientName)
        {
            this.AssignID = assignID;
            this.PatientID = patientID;
            this.Date = date;
            this.DischargedDate = dischargedDate;
            this.HospitalizateDate = hospitalizateDate;
            this.PatientName = patientName;
        }
    }
}
