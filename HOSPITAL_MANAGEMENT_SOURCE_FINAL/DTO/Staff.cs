using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOSPITAL_MANAGEMENT_SOURCE.DTO
{
    public class StaffDTO
    {
        public int StaffID { get; set; }
        public string DepartmentName { get; set; }
        public string MajorName { get; set; }
        public string RoleName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }
        public int Gender { get; set; }
        public decimal ICN { get; set; }
        public string Address { get; set; }
        public int State { get; set; }
        public string Email { get; set; }
    }
}
