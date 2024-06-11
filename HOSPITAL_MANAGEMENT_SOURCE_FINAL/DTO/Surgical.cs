using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOSPITAL_MANAGEMENT_SOURCE.DTO
{
    public class SurgicalDTO
    {
        public int SurgicalID { get; set; }
        public int PatientID { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int State { get; set; }
        public string PatientName { get; set; }
    }
}
