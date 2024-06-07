using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOSPITAL_MANAGEMENT_SOURCE.DTO
{
    public class RoleFunctionDTO
    {
        public int FunctionID { get; set; }
        public string FunctionName { get; set; }
        public string Button { get; set; }

        public RoleFunctionDTO() { }

        public RoleFunctionDTO(int functionID, string functionName, string button)
        {
            FunctionID = functionID;
            FunctionName = functionName;
            Button = button;
        }
    }
}
