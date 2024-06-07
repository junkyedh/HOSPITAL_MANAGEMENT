using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOSPITAL_MANAGEMENT_SOURCE.DTO
{
    public class HealthFileDTO
    {
        public int HeathFileID { get; set; }
        public int PatientID { get; set; }
        public DateTime Date { get; set; }
        public string PatientState { get; set; }
        public string PreHistory { get; set; }
        public string Disease { get; set; }
        public string Treatment { get; set; }

        public HealthFileDTO() { }

        public HealthFileDTO(int heathFileID, int patientID, DateTime date, string patientState, string preHistory, string disease, string treatment)
        {
            HeathFileID = heathFileID;
            PatientID = patientID;
            Date = date;
            PatientState = patientState;
            PreHistory = preHistory;
            Disease = disease;
            Treatment = treatment;
        }

    }
}
