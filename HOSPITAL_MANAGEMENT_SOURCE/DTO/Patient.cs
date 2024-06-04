using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOSPITAL_MANAGEMENT_SOURCE.DTO
{
    public class PatientDTO
    {
        public int PatientID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }
        public int Gender { get; set; }
        public decimal ICN { get; set; }
        public string Profession { get; set; }
        public string Address { get; set; }
        public decimal Deposit { get; set; }
        public int State { get; set; }

        public PatientDTO() { }

        // Constructor set all properties
        public PatientDTO(int patientID, string firstName, string lastName, DateTime birthDay,
            int gender, decimal iCN, string profession, string address, decimal deposit, int state)
        {
            PatientID = patientID;
            FirstName = firstName;
            LastName = lastName;
            BirthDay = birthDay;
            Gender = gender;
            ICN = iCN;
            Profession = profession;
            Address = address;
            Deposit = deposit;
            State = state;
        }
    }
}
