using HOSPITAL_MANAGEMENT_SOURCE.DTO;
using Npgsql;
using System;
using System.Data;

namespace HOSPITAL_MANAGEMENT_SOURCE.DAL
{
    public class HIC
    {
        public int HICID { get; set; }
        public int PatientID { get; set; }
        public DateTime ExpireDate { get; set; }
        public DateTime IssueDate { get; set; }

        public static int InsertHIC(HICDTO newHIC)
        {
            string sqlInsert = @"INSERT INTO ""HIC""(PATIENTID, EXPIREDATE, ISSUEDATE)
                                VALUES (@PATIENTID, @EXPIREDATE, @ISSUEDATE)";
            NpgsqlParameter[] npgsqlParameters = {
                new NpgsqlParameter("@PATIENTID", newHIC.PatientID),
                new NpgsqlParameter("@EXPIREDATE", newHIC.ExpireDate),
                new NpgsqlParameter("@ISSUEDATE", newHIC.IssueDate)
            };
            return NpgSqlResult.ExecuteNonQuery(sqlInsert, npgsqlParameters);
        }

        public static int UpdateHIC(HICDTO updateHIC)
        {
            string sqlUpdate = @"UPDATE ""HIC""
                                SET PATIENTID = @PATIENTID, EXPIREDATE = @EXPIREDATE, ISSUEDATE = @ISSUEDATE
                                WHERE HICID = @HICID";
            NpgsqlParameter[] npgsqlParameters = {
                new NpgsqlParameter("@HICID", updateHIC.HICID),
                new NpgsqlParameter("@PATIENTID", updateHIC.PatientID),
                new NpgsqlParameter("@EXPIREDATE", updateHIC.ExpireDate),
                new NpgsqlParameter("@ISSUEDATE", updateHIC.IssueDate)
            };
            return NpgSqlResult.ExecuteNonQuery(sqlUpdate, npgsqlParameters);
        }

        public static int DeleteHIC(int hICID)
        {
            string sqlDelete = @"DELETE FROM ""HIC""
                                WHERE HICID = @HICID";
            NpgsqlParameter[] npgsqlParameters = { new NpgsqlParameter("@HICID", hICID) };
            return NpgSqlResult.ExecuteNonQuery(sqlDelete, npgsqlParameters);
        }

        public static DataTable GetListHIC(int patientID)
        {
            string sqlSelect = @"SELECT HICID, PATIENTID, EXPIREDATE, ISSUEDATE
                                 FROM ""HIC""
                                 WHERE PATIENTID = @PATIENTID";
            NpgsqlParameter[] npgsqlParameters = { new NpgsqlParameter("@PATIENTID", patientID) };
            return NpgSqlResult.ExecuteQuery(sqlSelect, npgsqlParameters);
        }

        public static HICDTO GetPatientHIC(int patientID)
        {
            string sqlSelect = @"SELECT HICID, PATIENTID, EXPIREDATE, ISSUEDATE
                                 FROM ""HIC""
                                 WHERE PATIENTID = @PATIENTID";
            NpgsqlParameter[] npgsqlParameters = { new NpgsqlParameter("@PATIENTID", patientID) };
            DataTable dataTable = NpgSqlResult.ExecuteQuery(sqlSelect, npgsqlParameters);
            if (dataTable.Rows.Count > 0)
            {
                return new HICDTO
                {
                    HICID = Convert.ToInt32(dataTable.Rows[0]["HICID"]),
                    PatientID = Convert.ToInt32(dataTable.Rows[0]["PATIENTID"]),
                    ExpireDate = Convert.ToDateTime(dataTable.Rows[0]["EXPIREDATE"]),
                    IssueDate = Convert.ToDateTime(dataTable.Rows[0]["ISSUEDATE"])
                };
            }
            return null;
        }

        public static HICDTO GetHIC(int HICID)
        {
            string sqlSelect = @"SELECT HICID, PATIENTID, EXPIREDATE, ISSUEDATE
                                 FROM ""HIC""
                                 WHERE HICID = @HICID";
            NpgsqlParameter[] npgsqlParameters = { new NpgsqlParameter("@HICID", HICID) };
            DataTable dataTable = NpgSqlResult.ExecuteQuery(sqlSelect, npgsqlParameters);
            if (dataTable.Rows.Count > 0)
            {
                return new HICDTO
                {
                    HICID = Convert.ToInt32(dataTable.Rows[0]["HICID"]),
                    PatientID = Convert.ToInt32(dataTable.Rows[0]["PATIENTID"]),
                    ExpireDate = Convert.ToDateTime(dataTable.Rows[0]["EXPIREDATE"]),
                    IssueDate = Convert.ToDateTime(dataTable.Rows[0]["ISSUEDATE"])
                };
            }
            return null;
        }

        public static bool CheckHIC(int patientID)
        {
            string sqlSelect = @"SELECT HICID, PATIENTID, EXPIREDATE, ISSUEDATE
                                FROM ""HIC""
                                WHERE PATIENTID = @PATIENTID";
            NpgsqlParameter[] npgsqlParameters = { new NpgsqlParameter("@PATIENTID", patientID) };
            DataTable dataTable = NpgSqlResult.ExecuteQuery(sqlSelect, npgsqlParameters);
            return dataTable.Rows.Count > 0;
        }


        public static bool CheckHICExpiration(int HICID)
        {
            HICDTO newHIC = GetHIC(HICID);
            return newHIC.ExpireDate < DateTime.Today;
        }
    }
}
