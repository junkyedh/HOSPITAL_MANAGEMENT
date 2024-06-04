using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOSPITAL_MANAGEMENT_SOURCE.DTO
{
    public class BillDTO
    {
        public int BillID { get; set; }
        public int BillTypeID { get; set; }
        public int PatientID { get; set; }
        public int StaffID { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalPrice { get; set; }
        public int State { get; set; }

        public BillDTO() { }
        public BillDTO(int billID, int billTypeID, int patientID, int staffID, DateTime date, decimal totalPrice, int state)
        {
            this.BillID = billID;
            this.BillTypeID = billTypeID;
            this.PatientID = patientID;
            this.StaffID = staffID;
            this.Date = date;
            this.TotalPrice = totalPrice;
            this.State = state;
        }
    }
}
