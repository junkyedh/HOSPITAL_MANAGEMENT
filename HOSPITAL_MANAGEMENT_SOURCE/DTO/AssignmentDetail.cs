using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOSPITAL_MANAGEMENT_SOURCE.DTO
{
    internal class AssignmentDetailDTO
    {
        public int AssignID { get; set; }
        public int StaffID { get; set; }
        public string StaffName { get; set; } // Combine LastName and FirstName into a single property

        public AssignmentDetailDTO() { }
        public AssignmentDetailDTO(int assignID, int staffID, string staffName)
        {
            this.AssignID = assignID;
            this.StaffID = staffID;
            this.StaffName = staffName;
        }
    }
}
