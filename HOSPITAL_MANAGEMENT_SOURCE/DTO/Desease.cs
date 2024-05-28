using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using HOSPITAL_MANAGEMENT_SOURCE.DAL;

namespace HOSPITAL_MANAGEMENT_SOURCE.DTO
{
    public class Disease
    {
        public int DiseaseID { get; set; }
        public String DiseaseName { get; set; }
        public String Symptom { get; set; }
    }

}
