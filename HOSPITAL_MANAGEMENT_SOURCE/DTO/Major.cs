using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOSPITAL_MANAGEMENT_SOURCE.DTO
{
    public class MajorDTO
    {
        public int MajorID { get; set; }
        public string MajorName { get; set; }

        public MajorDTO() { }

        public MajorDTO(int majorID, string majorName)
        {
            MajorID = majorID;
            MajorName = majorName;
        }
    }
}
