using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOSPITAL_MANAGEMENT_SOURCE.DTO
{
    public class HICDTO
    {
        public int HICID { get; set; }
        public int PatientID { get; set; }
        public DateTime ExpireDate { get; set; }
        public DateTime IssueDate { get; set; }

        public HICDTO() { }
        public HICDTO(int hicID, int patientID, DateTime expireDate, DateTime issueDate)
        {
            this.HICID = hicID;
            this.PatientID = patientID;
            this.ExpireDate = expireDate;
            this.IssueDate = issueDate;
        }
    }
}
