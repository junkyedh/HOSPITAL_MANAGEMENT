using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOSPITAL_MANAGEMENT_SOURCE.DTO
{
    public class DiseaseDTO
    {
        public int DiseaseID { get; set; }
        public string DiseaseName { get; set; }
        public string Symptom { get; set; }
        public DiseaseDTO() { }

        public DiseaseDTO(int diseaseID, string diseaseName, string symptom)
        {
            DiseaseID = diseaseID;
            DiseaseName = diseaseName;
            Symptom = symptom;
        }
    }

}
