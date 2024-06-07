using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOSPITAL_MANAGEMENT_SOURCE.DTO
{
    public class DepartmentDTO
    {
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }

        public DepartmentDTO() { }
        public DepartmentDTO(int departmentID, string DepartmentName)
        {
            this.DepartmentID = departmentID;
            this.DepartmentName = DepartmentName;
        }
    }
}
