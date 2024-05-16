using Npgsql;
using System;
using System.Data;

namespace HOSPITAL_MANAGEMENT_SOURCE.DAL
{
    public class HeathMonitoringNoteDTO
    {
        public int HNID { get; set; }
        public int PatientID { get; set; }
        public int StaffID { get; set; }
        public DateTime Date { get; set; }
        public string Weight { get; set; }
        public string BloodPressure { get; set; }
        public string PatientState { get; set; }

        public static int InsertHN(HeathMonitoringNoteDTO newHN)
        {
            string sqlInsert = @"INSERT INTO HEATHMONITORINGNOTE(PATIENTID, STAFFID, DATE, WEIGHT, BLOODPRESSURE, PATIENTSTATE)
                                VALUES (@PATIENTID, @STAFFID, @DATE, @WEIGHT, @BLOODPRESSURE, @PATIENTSTATE)";
            NpgsqlParameter[] npgsqlParameters = {
                new NpgsqlParameter("@PATIENTID", newHN.PatientID),
                new NpgsqlParameter("@STAFFID", newHN.StaffID),
                new NpgsqlParameter("@DATE", newHN.Date),
                new NpgsqlParameter("@WEIGHT", newHN.Weight),
                new NpgsqlParameter("@BLOODPRESSURE", newHN.BloodPressure),
                new NpgsqlParameter("@PATIENTSTATE", newHN.PatientState)
            };
            return NpgSqlResult.ExecuteNonQuery(sqlInsert, npgsqlParameters);
        }

        public static int UpdateHN(HeathMonitoringNoteDTO updateHN)
        {
            string sqlUpdate = @"UPDATE HEATHMONITORINGNOTE
                                SET PATIENTID = @PATIENTID, STAFFID = @STAFFID, DATE = @DATE, WEIGHT = @WEIGHT, BLOODPRESSURE = @BLOODPRESSURE, PATIENTSTATE = @PATIENTSTATE
                                WHERE HNID = @HNID";
            NpgsqlParameter[] npgsqlParameters = {
                new NpgsqlParameter("@HNID", updateHN.HNID),
                new NpgsqlParameter("@PATIENTID", updateHN.PatientID),
                new NpgsqlParameter("@STAFFID", updateHN.StaffID),
                new NpgsqlParameter("@DATE", updateHN.Date),
                new NpgsqlParameter("@WEIGHT", updateHN.Weight),
                new NpgsqlParameter("@BLOODPRESSURE", updateHN.BloodPressure),
                new NpgsqlParameter("@PATIENTSTATE", updateHN.PatientState)
            };
            return NpgSqlResult.ExecuteNonQuery(sqlUpdate, npgsqlParameters);
        }

        public static int DeleteHN(int hNID)
        {
            string sqlDelete = @"DELETE FROM HEATHMONITORINGNOTE
                                WHERE HNID = @HNID";
            NpgsqlParameter[] npgsqlParameters = { new NpgsqlParameter("@HNID", hNID) };
            return NpgSqlResult.ExecuteNonQuery(sqlDelete, npgsqlParameters);
        }

        public static DataTable GetListHN()
        {
            string sqlSelect = @"SELECT HNID, PATIENTID, STAFFID, DATE, WEIGHT, BLOODPRESSURE, PATIENTSTATE
                                 FROM HEATHMONITORINGNOTE";
            return NpgSqlResult.ExecuteQuery(sqlSelect);
        }

        public static DataTable GetListHN(int patientID)
        {
            string sqlSelect = @"SELECT HNID, PATIENTID, STAFFID, DATE, WEIGHT, BLOODPRESSURE, PATIENTSTATE
                                 FROM HEATHMONITORINGNOTE
                                 WHERE PATIENTID = @PATIENTID";
            NpgsqlParameter[] npgsqlParameters = { new NpgsqlParameter("@PATIENTID", patientID) };
            return NpgSqlResult.ExecuteQuery(sqlSelect, npgsqlParameters);
        }

        public static HeathMonitoringNoteDTO GetHN(int hNID)
        {
            string sqlSelect = @"SELECT HNID, PATIENTID, STAFFID, DATE, WEIGHT, BLOODPRESSURE, PATIENTSTATE
                                 FROM HEATHMONITORINGNOTE
                                 WHERE HNID = @HNID";
            NpgsqlParameter[] npgsqlParameters = { new NpgsqlParameter("@HNID", hNID) };
            DataTable dataTable = NpgSqlResult.ExecuteQuery(sqlSelect, npgsqlParameters);
            if (dataTable.Rows.Count > 0)
            {
                return new HeathMonitoringNoteDTO
                {
                    HNID = Convert.ToInt32(dataTable.Rows[0]["HNID"]),
                    PatientID = Convert.ToInt32(dataTable.Rows[0]["PATIENTID"]),
                    StaffID = Convert.ToInt32(dataTable.Rows[0]["STAFFID"]),
                    Date = Convert.ToDateTime(dataTable.Rows[0]["DATE"]),
                    Weight = dataTable.Rows[0]["WEIGHT"].ToString(),
                    BloodPressure = dataTable.Rows[0]["BLOODPRESSURE"].ToString(),
                    PatientState = dataTable.Rows[0]["PATIENTSTATE"].ToString()
                };
            }
            return null;
        }
    }
}
