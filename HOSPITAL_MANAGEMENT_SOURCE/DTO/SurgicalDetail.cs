using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOSPITAL_MANAGEMENT_SOURCE.DTO
{
    public class SurgicalDetailDTO
    {
        public int SurgicalID { get; set; }
        public int StaffID { get; set; }
        public string StaffLastName { get; set; }
        public string StaffFirstName { get; set; }

        public SurgicalDetailDTO() { }

        public SurgicalDetailDTO(int surgicalID, int staffID)
        {
            this.SurgicalID = surgicalID;
            this.StaffID = staffID;
        }
    }
}
