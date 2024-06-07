using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOSPITAL_MANAGEMENT_SOURCE.DTO
{
    public class BillTypeDTO
    {
        public int BillTypeID { get; set; }
        public string TypeName { get; set; }
        public BillTypeDTO() { }
        public BillTypeDTO(int billTypeID, string typeName)
        {
            this.BillTypeID = billTypeID;
            this.TypeName = typeName;
        }
    }
}
