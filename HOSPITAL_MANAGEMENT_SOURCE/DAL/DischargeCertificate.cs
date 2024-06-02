using System;
using System.Collections.Generic;
using Npgsql;
using System.Data;
using HOSPITAL_MANAGEMENT_SOURCE.DTO;

namespace HOSPITAL_MANAGEMENT_SOURCE.DAL
{
    public class DischargeCertificate
    {
        public int DCID { get; set; }
        public int StaffID { get; set; }
        public int PatientID { get; set; }
        public DateTime Date { get; set; }
        public int State { get; set; }
        public static int InsertDC(DischargeCertificateDTO newDC)
        {
            string sqlInsert = @"INSERT INTO ""DISCHARGEDCERTIFICATE"" (STAFFID, PATIENTID, DATE, STATE) VALUES (@STAFFID, @PATIENTID, @DATE, @STATE)";
            NpgsqlParameter[] npgsqlParameters = {
                new NpgsqlParameter("@STAFFID", newDC.StaffID),
                new NpgsqlParameter("@PATIENTID", newDC.PatientID),
                new NpgsqlParameter("@DATE", newDC.Date),
                new NpgsqlParameter("@STATE", newDC.State)
            };
            return NpgSqlResult.ExecuteNonQuery(sqlInsert, npgsqlParameters);
        }

        public static int UpdateDC(DischargeCertificateDTO updateDC)
        {
            string sqlUpdate = @"UPDATE ""DISCHARGEDCERTIFICATE"" SET STAFFID = @STAFFID, PATIENTID = @PATIENTID, DATE = @DATE, STATE = @STATE WHERE DCID = @DCID";
            NpgsqlParameter[] npgsqlParameters = {
                new NpgsqlParameter("@DCID", updateDC.DCID),
                new NpgsqlParameter("@STAFFID", updateDC.StaffID),
                new NpgsqlParameter("@PATIENTID", updateDC.PatientID),
                new NpgsqlParameter("@DATE", updateDC.Date),
                new NpgsqlParameter("@STATE", updateDC.State)
            };
            return NpgSqlResult.ExecuteNonQuery(sqlUpdate, npgsqlParameters);
        }

        public static int DeleteDC(int dCID)
        {
            string sqlDelete = @"DELETE FROM ""DISCHARGEDCERTIFICATE"" WHERE DCID = @DCID";
            NpgsqlParameter[] npgsqlParameters = { new NpgsqlParameter("@DCID", dCID) };
            return NpgSqlResult.ExecuteNonQuery(sqlDelete, npgsqlParameters);
        }

        public static DataTable GetListDC()
        {
            string sqlSelect = @"SELECT DCID, STAFFID, PATIENTID, DATE, STATE FROM ""DISCHARGEDCERTIFICATE""";
            return NpgSqlResult.ExecuteQuery(sqlSelect);
        }

        public static DischargeCertificateDTO GetDC(int dCID)
        {
            string sqlSelect = @"SELECT DCID, STAFFID, PATIENTID, DATE, STATE FROM ""DISCHARGEDCERTIFICATE"" WHERE DCID = @DCID";
            NpgsqlParameter[] npgsqlParameters = { new NpgsqlParameter("@DCID", dCID) };
            DataTable dataTable = NpgSqlResult.ExecuteQuery(sqlSelect, npgsqlParameters);
            if (dataTable.Rows.Count > 0)
            {
                var dC = new DischargeCertificateDTO
                {
                    DCID = Convert.ToInt32(dataTable.Rows[0]["DCID"]),
                    StaffID = Convert.ToInt32(dataTable.Rows[0]["STAFFID"]),
                    PatientID = Convert.ToInt32(dataTable.Rows[0]["PATIENTID"]),
                    Date = Convert.ToDateTime(dataTable.Rows[0]["DATE"]),
                    State = Convert.ToInt32(dataTable.Rows[0]["STATE"])
                };
                return dC;
            }
            return null;
        }


        public static bool IsPatientHadDC(int patientID)
        {
            string sqlSelect = @"SELECT DCID, STAFFID, PATIENTID, DATE, STATE FROM ""DISCHARGEDCERTIFICATE"" WHERE PATIENTID = @PATIENTID";
            NpgsqlParameter[] npgsqlParameters = { new NpgsqlParameter("@PATIENTID", patientID) };
            DataTable dtDC = NpgSqlResult.ExecuteQuery(sqlSelect, npgsqlParameters);
            return dtDC.Rows.Count > 0;
        }
    }
}
