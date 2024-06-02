using HOSPITAL_MANAGEMENT_SOURCE.DTO;
using Npgsql;
using System;
using System.Data;

namespace HOSPITAL_MANAGEMENT_SOURCE.DAL
{
    public class ExaminationCertificate
    {

        public int ECID { get; set; }
        public int PatientID { get; set; }
        public int StaffID { get; set; }
        public DateTime Date { get; set; }
        public string Result { get; set; }
        public int State { get; set; }

        public ExaminationCertificate() { }

        public ExaminationCertificate(int eCID, int patientID, int staffID, DateTime date, string result, int state)
        {
            ECID = eCID;
            PatientID = patientID;
            StaffID = staffID;
            Date = date;
            Result = result;
            State = state;
        }


        public static int InsertEC(ExaminationCertificate newEC)
        {
            string sqlInsert = @"INSERT INTO ""EXAMINATIONCERTIFICATE""(PATIENTID, STAFFID, DATE, RESULT, STATE)
                                VALUES (@PATIENTID, @STAFFID, @DATE, @RESULT, @STATE)";
            NpgsqlParameter[] npgsqlParameters = {
                new NpgsqlParameter("@PATIENTID", newEC.PatientID),
                new NpgsqlParameter("@STAFFID", newEC.StaffID),
                new NpgsqlParameter("@DATE", newEC.Date),
                new NpgsqlParameter("@RESULT", newEC.Result),
                new NpgsqlParameter("@STATE", newEC.State)
            };
            return NpgSqlResult.ExecuteNonQuery(sqlInsert, npgsqlParameters);
        }

        public static int UpdateEC(ExaminationCertificate updateEC)
        {
            string sqlUpdate = @"UPDATE ""EXAMINATIONCERTIFICATE""
                                SET DATE = @DATE, RESULT = @RESULT, STATE = @STATE
                                WHERE ECID = @ECID";
            NpgsqlParameter[] npgsqlParameters = {
                new NpgsqlParameter("@ECID", updateEC.ECID),
                new NpgsqlParameter("@DATE", updateEC.Date),
                new NpgsqlParameter("@RESULT", updateEC.Result),
                new NpgsqlParameter("@STATE", updateEC.State)
            };
            return NpgSqlResult.ExecuteNonQuery(sqlUpdate, npgsqlParameters);
        }

        public static int DeleteEC(int eCID)
        {
            string sqlDelete = @"DELETE FROM ""EXAMINATIONCERTIFICATE""
                                WHERE ECID = @ECID";
            NpgsqlParameter[] npgsqlParameters = { new NpgsqlParameter("@ECID", eCID) };
            return NpgSqlResult.ExecuteNonQuery(sqlDelete, npgsqlParameters);
        }

        public  static DataTable GetListEC()
        {
            string sqlSelect = @"SELECT ECID, PATIENTID, STAFFID, DATE, RESULT, STATE
                                 FROM ""EXAMINATIONCERTIFICATE""";
            return NpgSqlResult.ExecuteQuery(sqlSelect);
        }

        public static ExaminationCertificate GetEC(int eCID)
        {
            string sqlSelect = @"SELECT ECID, PATIENTID, STAFFID, DATE, RESULT, STATE
                                 FROM ""EXAMINATIONCERTIFICATE""
                                 WHERE ECID = @ECID";
            NpgsqlParameter[] npgsqlParameters = { new NpgsqlParameter("@ECID", eCID) };
            DataTable dataTable = NpgSqlResult.ExecuteQuery(sqlSelect, npgsqlParameters);
            if (dataTable.Rows.Count > 0)
            {
                return new ExaminationCertificate
                {
                    ECID = Convert.ToInt32(dataTable.Rows[0]["ECID"]),
                    PatientID = Convert.ToInt32(dataTable.Rows[0]["PATIENTID"]),
                    StaffID = Convert.ToInt32(dataTable.Rows[0]["STAFFID"]),
                    Date = Convert.ToDateTime(dataTable.Rows[0]["DATE"]),
                    Result = dataTable.Rows[0]["RESULT"].ToString(),
                    State = Convert.ToInt32(dataTable.Rows[0]["STATE"])
                };
            }
            return null;
        }

        public static int GetCurrentECID()
        {
            string sqlSelect = @"SELECT last_value FROM EXAMINATIONCERTIFICATE_ECID_seq";
            return Convert.ToInt32(NpgSqlResult.ExecuteScalar(sqlSelect)) + 1;
        }
    }
}
