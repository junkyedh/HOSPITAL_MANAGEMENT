using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOSPITAL_MANAGEMENT_SOURCE.DTO
{
    public class HealthMonitoringNoteDTO
    {
        public int HNID { get; set; }
        public int PatientID { get; set; }
        public int StaffID { get; set; }
        public DateTime Date { get; set; }
        public string Weight { get; set; }
        public string BloodPressure { get; set; }
        public string PatientState { get; set; }

        public HealthMonitoringNoteDTO() { }
        public HealthMonitoringNoteDTO(int hnID, int patientID, int staffID, DateTime date, string weight, string bloodPressure, string patientState)
        {
            this.HNID = hnID;
            this.PatientID = patientID;
            this.StaffID = staffID;
            this.Date = date;
            this.Weight = weight;
            this.BloodPressure = bloodPressure;
            this.PatientState = patientState;
        }
    }
}
