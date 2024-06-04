using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOSPITAL_MANAGEMENT_SOURCE.DTO
{
    public class RoleDTO
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }

        public RoleDTO() { }

        public RoleDTO(int roleID, string roleName)
        {
            RoleID = roleID;
            RoleName = roleName;
        }
    }
}
