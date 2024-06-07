using Dapper.Contrib.Extensions;
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
        public int RoleID { get; set; }
        public int MajorID { get; set; }
        public int DepartmentID { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDay { get; set; }
        public int Gender { get; set; }
        public decimal ICN { get; set; }
        public string Address { get; set; }
        public int State { get; set; }
        public string SDT { get; set; }

        public StaffDTO() { }

        public StaffDTO(int staffID, int majorID, int departmentID, int roleID, string password, string firstName, string lastName, string email,
            DateTime birthDay, int gender, decimal iCN, string address, int state, string sdt)
        {
            StaffID = staffID;
            MajorID = majorID;
            DepartmentID = departmentID;
            RoleID = roleID;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            BirthDay = birthDay;
            Gender = gender;
            ICN = iCN;
            Address = address;
            State = state;
            SDT = sdt;
        }
    }
}