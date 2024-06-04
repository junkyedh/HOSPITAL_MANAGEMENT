using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOSPITAL_MANAGEMENT_SOURCE.DTO
{
    public class TestDetailDTO
    {
        public int TCID { get; set; }
        public int TestTypeID { get; set; }
        public string Result { get; set; }
        public string TestTypeName { get; set; }

        public TestDetailDTO() { }

        public TestDetailDTO(int testTypeID, int tcID, string result)
        {
            this.TestTypeID = testTypeID;
            this.TCID = tcID;
            this.Result = result;
        }
    }
}
