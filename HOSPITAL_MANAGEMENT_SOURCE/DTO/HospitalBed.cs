using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOSPITAL_MANAGEMENT_SOURCE.DTO
{
    public class HospitalBedDTO
    {

        public int BedID { get; set; }
        public int Patient { get; set; }
        public int State { get; set; }
        public HospitalBedDTO() { }
        public HospitalBedDTO(int bedID, int patient, int state)
        {
            this.BedID = bedID;
            this.Patient = patient;
            this.State = state;
        }
    }
}
