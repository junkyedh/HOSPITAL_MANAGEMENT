using HOSPITAL_MANAGEMENT_SOURCE.DTO;
using Npgsql;
using System;
using System.Data;

namespace HOSPITAL_MANAGEMENT_SOURCE.DAL
{
    public class HealthFile
    {

        public int HeathFileID { get; set; }
        public int PatientID { get; set; }
        public DateTime Date { get; set; }
        public string PatientState { get; set; }
        public string PreHistory { get; set; }
        public string Disease { get; set; }
        public string Treatment { get; set; }

        public HealthFile() { }

        public HealthFile(int heathFileID, int patientID, DateTime date, string patientState, string preHistory, string disease, string treatment)
        {
            HeathFileID = heathFileID;
            PatientID = patientID;
            Date = date;
            PatientState = patientState;
            PreHistory = preHistory;
            Disease = disease;
            Treatment = treatment;
        }

        public static int InsertHeathFile(HealthFileDTO newHF)
        {
            string sqlInsert = @"INSERT INTO ""HEATHFILE""(PATIENTID, DATE, PATIENTSTATE, PREHISTORY, DISEASE, TREATMENT)
                                VALUES (@PATIENTID, @DATE, @PATIENTSTATE, @PREHISTORY, @DISEASE, @TREATMENT)";
            NpgsqlParameter[] npgsqlParameters = {
                new NpgsqlParameter("@PATIENTID", newHF.PatientID),
                new NpgsqlParameter("@DATE", newHF.Date),
                new NpgsqlParameter("@PATIENTSTATE", newHF.PatientState),
                new NpgsqlParameter("@PREHISTORY", newHF.PreHistory),
                new NpgsqlParameter("@DISEASE", newHF.Disease),
                new NpgsqlParameter("@TREATMENT", newHF.Treatment)
            };
            return NpgSqlResult.ExecuteNonQuery(sqlInsert, npgsqlParameters);
        }

        public static int UpdateHeathFile(HealthFileDTO updateHF)
        {
            string sqlUpdate = @"UPDATE ""HEATHFILE""
                                SET DATE = @DATE, PATIENTSTATE = @PATIENTSTATE, PREHISTORY = @PREHISTORY, DISEASE = @DISEASE, TREATMENT = @TREATMENT
                                WHERE HEATHFILEID = @HEATHFILEID";
            NpgsqlParameter[] npgsqlParameters = {
                new NpgsqlParameter("@HEATHFILEID", updateHF.HeathFileID),
                new NpgsqlParameter("@DATE", updateHF.Date),
                new NpgsqlParameter("@PATIENTSTATE", updateHF.PatientState),
                new NpgsqlParameter("@PREHISTORY", updateHF.PreHistory),
                new NpgsqlParameter("@DISEASE", updateHF.Disease),
                new NpgsqlParameter("@TREATMENT", updateHF.Treatment)
            };
            return NpgSqlResult.ExecuteNonQuery(sqlUpdate, npgsqlParameters);
        }

        public static int DeleteHeathFile(int heathFileID)
        {
            string sqlDelete = @"DELETE FROM ""HEATHFILE""
                                WHERE HEATHFILEID = @HEATHFILEID";
            NpgsqlParameter[] npgsqlParameters = { new NpgsqlParameter("@HEATHFILEID", heathFileID) };
            return NpgSqlResult.ExecuteNonQuery(sqlDelete, npgsqlParameters);
        }

        public static DataTable GetListHeathFile()   //cho nay co doi thanh static de chay dc trong formmainhf
        {
            string sqlSelect = @"SELECT 
                                    HEATHFILEID, PATIENTID, DATE, PATIENTSTATE, PREHISTORY, DISEASE, TREATMENT
                                 FROM ""HEATHFILE""";
            return NpgSqlResult.ExecuteQuery(sqlSelect);
        }

        public static HealthFileDTO GetHeathFile(int heathFileID)
        {
            string sqlSelect = @"SELECT HEATHFILEID, PATIENTID, DATE, PATIENTSTATE, PREHISTORY, DISEASE, TREATMENT
                                 FROM ""HEATHFILE""
                                 WHERE HEATHFILEID = @HEATHFILEID";
            NpgsqlParameter[] npgsqlParameters = { new NpgsqlParameter("@HEATHFILEID", heathFileID) };
            DataTable dataTable = NpgSqlResult.ExecuteQuery(sqlSelect, npgsqlParameters);
            if (dataTable.Rows.Count > 0)
            {
                return new HealthFileDTO
                {
                    HeathFileID = Convert.ToInt32(dataTable.Rows[0]["HEATHFILEID"]),
                    PatientID = Convert.ToInt32(dataTable.Rows[0]["PATIENTID"]),
                    Date = Convert.ToDateTime(dataTable.Rows[0]["DATE"]),
                    PatientState = dataTable.Rows[0]["PATIENTSTATE"].ToString(),
                    PreHistory = dataTable.Rows[0]["PREHISTORY"].ToString(),
                    Disease = dataTable.Rows[0]["DISEASE"].ToString(),
                    Treatment = dataTable.Rows[0]["TREATMENT"].ToString()
                };
            }
            return null;
        }

        public static bool DidPatientHaveHF(int patientID)
        {
            string sqlSelect = @"SELECT HEATHFILEID, PATIENTID, DATE, PATIENTSTATE, PREHISTORY, DISEASE, TREATMENT
                                FROM ""HEATHFILE""
                                WHERE PATIENTID = @PATIENTID";
            NpgsqlParameter[] npgsqlParameters = { new NpgsqlParameter("@PATIENTID", patientID) };
            DataTable dataTable = NpgSqlResult.ExecuteQuery(sqlSelect, npgsqlParameters);
            return dataTable.Rows.Count > 0;
        }

        public HealthFileDTO ToDTO()
        {
            return new HealthFileDTO {
                HeathFileID = this.HeathFileID,
                PatientID = this.PatientID,
                Date = this.Date,
                PatientState = this.PatientState,
                PreHistory = this.PreHistory,
                Disease = this.Disease,
                Treatment = this.Treatment
            };
        }
    }
}
