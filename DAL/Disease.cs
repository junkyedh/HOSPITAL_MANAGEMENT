using HOSPITAL_MANAGEMENT_SOURCE.DTO;
using Npgsql;
using System;
using System.Data;

namespace HOSPITAL_MANAGEMENT_SOURCE.DAL
{
    public class Disease
    {
       
        public int DiseaseID { get; set; }
        public string DiseaseName { get; set; }
        public string Symptom { get; set; }

        public Disease() { }

        public Disease(int diseaseID, string diseaseName, string symptom)
        {
            DiseaseID = diseaseID;
            DiseaseName = diseaseName;
            Symptom = symptom;
        }


        public static int InsertDisease(Disease newDisease)
        {
            string sqlInsert = @"INSERT INTO ""DISEASE""(DISEASENAME, SYMPTOM)
                                 VALUES (@DISEASENAME, @SYMPTOM)";
            NpgsqlParameter[] npgsqlParameters = {
                new NpgsqlParameter("@DISEASENAME", newDisease.DiseaseName),
                new NpgsqlParameter("@SYMPTOM", newDisease.Symptom)
            };
            return NpgSqlResult.ExecuteNonQuery(sqlInsert, npgsqlParameters);
        }

        public static int UpdateDisease(Disease updateDisease)
        {
            string sqlUpdate = @"UPDATE ""DISEASE""
                                 SET DISEASENAME = @DISEASENAME, SYMPTOM = @SYMPTOM
                                 WHERE DISEASEID = @DISEASEID";
            NpgsqlParameter[] npgsqlParameters = {
                new NpgsqlParameter("@DISEASEID", updateDisease.DiseaseID),
                new NpgsqlParameter("@DISEASENAME", updateDisease.DiseaseName),
                new NpgsqlParameter("@SYMPTOM", updateDisease.Symptom)
            };
            return NpgSqlResult.ExecuteNonQuery(sqlUpdate, npgsqlParameters);
        }

        public static int DeleteDisease(int diseaseID)
        {
            string sqlDelete = @"DELETE FROM ""DISEASE"" WHERE DISEASEID = @DISEASEID";
            NpgsqlParameter[] npgsqlParameters = { new NpgsqlParameter("@DISEASEID", diseaseID) };
            return NpgSqlResult.ExecuteNonQuery(sqlDelete, npgsqlParameters);
        }

        public static DataTable GetListDisease()
        {
            string sqlSelect = @"SELECT DISEASEID, DISEASENAME, SYMPTOM FROM ""DISEASE""";
            return NpgSqlResult.ExecuteQuery(sqlSelect);
        }


        public static Disease GetDisease(int diseaseID)
        {
            string sqlSelect = @"SELECT DISEASEID, DISEASENAME, SYMPTOM
                                 FROM ""DISEASE""
                                 WHERE DISEASEID = @DISEASEID";
            NpgsqlParameter[] npgsqlParameters = { new NpgsqlParameter("@DISEASEID", diseaseID) };
            DataTable dataTable = NpgSqlResult.ExecuteQuery(sqlSelect, npgsqlParameters);
            if (dataTable.Rows.Count > 0)
            {
                return new Disease
                {
                    DiseaseID = Convert.ToInt32(dataTable.Rows[0]["DISEASEID"]),
                    DiseaseName = dataTable.Rows[0]["DISEASENAME"].ToString(),
                    Symptom = dataTable.Rows[0]["SYMPTOM"].ToString()
                };
            }
            return null;
        }
    }
}
