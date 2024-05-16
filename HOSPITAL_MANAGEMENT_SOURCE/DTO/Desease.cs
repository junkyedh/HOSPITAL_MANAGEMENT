using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using HOSPITAL_MANAGEMENT_SOURCE.DAL;

namespace HOSPITAL_MANAGEMENT_SOURCE.DAL
{ 
    public class Disease
    {
        public int DiseaseID { get; set; }
        public String DiseaseName { get; set; }
        public String Symptom { get; set; }

        public Disease() { }

        public Disease(int diseaseID, String diseaseName, String symptom)
        {
            this.DiseaseID = diseaseID;
            this.DiseaseName = diseaseName;
            this.Symptom = symptom;
        }

        public static int InsertDisease(Disease newDisease)
        {
            String sqlInsert = @"INSERT INTO DISEASE(DISEASENAME,SYMPTOM)
                                VALUES        (@DISEASENAME,@SYMPTOM)";
            SqlParameter[] sqlParameters = { new SqlParameter("@DISEASENAME", newDisease.DiseaseName),
                                           new SqlParameter("@SYMPTOM",newDisease.Symptom)};
            return SqlResult.ExecuteNonQuery(sqlInsert, sqlParameters);
        }
        public static int UpdateDisease(Disease updateDisease)
        {
            string sqlUpdate = @"UPDATE DISEASE
                                SET DISEASENAME = @DISEASENAME,SYMPTOM=@SYMPTOM
                                WHERE (DISEASEID =@DISEASEID)";
            SqlParameter[] sqlParameters = { new SqlParameter("@DISEASEID", updateDisease.DiseaseID),
                                           new SqlParameter("@DISEASENAME", updateDisease.DiseaseName),
                                           new SqlParameter("@SYMPTOM", updateDisease.Symptom)};
            return SqlResult.ExecuteNonQuery(sqlUpdate, sqlParameters);
        }
        public static int DeleteDisease(int diseaseID)
        {
            string sqlDelete = @"DELETE FROM DISEASE
                                WHERE (DISEASEID = @DISEASEID)";
            SqlParameter[] sqlParameters = { new SqlParameter("@DISEASEID", diseaseID) };
            return SqlResult.ExecuteNonQuery(sqlDelete, sqlParameters);
        }
        public static DataTable GetListDisease()
        {
            DataTable dtDisease = new DataTable();
            string sqlSelect = @"SELECT DISEASEID,DISEASENAME,SYMPTOM
                                FROM DISEASE";
            dtDisease = SqlResult.ExecuteQuery(sqlSelect);
            //dtDisease.Columns[0].ColumnName = "Mã bệnh";
            //dtDisease.Columns[1].ColumnName = "Tên bệnh";
            //dtDisease.Columns[2].ColumnName = "Triệu chứng";
            return dtDisease;
        }
        public static Disease GetDisease(int diseaseID)
        {
            int tempInterger;
            Disease newDisease = new Disease();
            string sqlSelect = @"SELECT DISEASEID, DISEASENAME,SYMPTOM
                                FROM DISEASE
                                WHERE (DISEASEID = @DISEASEID)";
            SqlParameter[] sqlParameters = { new SqlParameter("@DISEASEID", diseaseID) };
            DataTable dataTable = SqlResult.ExecuteQuery(sqlSelect, sqlParameters);
            if (dataTable.Rows.Count > 0)
            {
                int.TryParse(dataTable.Rows[0][0].ToString(), out tempInterger);
                newDisease.DiseaseID = tempInterger;
                newDisease.DiseaseName = dataTable.Rows[0][1].ToString();
                newDisease.Symptom = dataTable.Rows[0][2].ToString();
            }
            return newDisease;
        }
    }
}
