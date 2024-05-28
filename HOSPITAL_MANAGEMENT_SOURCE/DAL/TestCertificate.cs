using HOSPITAL_MANAGEMENT_SOURCE.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using Npgsql;

namespace HOSPITAL_MANAGEMENT_SOURCE.DAL
{
    public class TestCertificate
    {
        public int TCID { get; set; }
        public int PatientID { get; set; }
        public int StaffID { get; set; }
        public DateTime Date { get; set; }
        public int State { get; set; }

        public TestCertificate() { }

        public TestCertificate(int tCID, int patientID, int staffID, DateTime date, int state)
        {
            this.TCID = tCID;
            this.PatientID = patientID;
            this.StaffID = staffID;
            this.Date = date;
            this.State = state;
        }

        public static int InsertTC(TestCertificateDTO newTC)
        {
            string sqlInsert = @"INSERT INTO TESTCERTIFICATE(PATIENTID, STAFFID, DATE, STATE)
                                 VALUES (@PATIENTID, @STAFFID, @DATE, @STATE)";
            NpgsqlParameter[] npgsqlParameters = {
                new NpgsqlParameter("@PATIENTID", newTC.PatientID),
                new NpgsqlParameter("@STAFFID", newTC.StaffID),
                new NpgsqlParameter("@DATE", newTC.Date),
                new NpgsqlParameter("@STATE", newTC.State)
            };
            return NpgSqlResult.ExecuteNonQuery(sqlInsert, npgsqlParameters);
        }

        public static int UpdateTC(TestCertificateDTO updateTC)
        {
            string sqlUpdate = @"UPDATE TESTCERTIFICATE
                                 SET DATE = @DATE, STATE = @STATE
                                 WHERE TCID = @TCID";
            NpgsqlParameter[] npgsqlParameters = {
                new NpgsqlParameter("@DATE", updateTC.Date),
                new NpgsqlParameter("@STATE", updateTC.State),
                new NpgsqlParameter("@TCID", updateTC.TCID)
            };
            return NpgSqlResult.ExecuteNonQuery(sqlUpdate, npgsqlParameters);
        }

        public static int DeleteTC(int tCID)
        {
            string sqlDelete = @"DELETE FROM TESTCERTIFICATE
                                 WHERE TCID = @TCID";
            NpgsqlParameter[] npgsqlParameters = {
                new NpgsqlParameter("@TCID", tCID)
            };
            return NpgSqlResult.ExecuteNonQuery(sqlDelete, npgsqlParameters);
        }

        public static DataTable GetListTC()
        {
            DataTable dtTC = new DataTable();
            string sqlSelect = @"SELECT TCID, t.PATIENTID, t.STAFFID, DATE, t.STATE, p.LASTNAME || ' ' || p.FIRSTNAME AS PATIENT_NAME, s.LASTNAME || ' ' || s.FIRSTNAME AS STAFF_NAME
                                 FROM TESTCERTIFICATE t
                                 JOIN PATIENT p ON t.PATIENTID = p.PATIENTID
                                 JOIN STAFF s ON t.STAFFID = s.STAFFID";
            dtTC = NpgSqlResult.ExecuteQuery(sqlSelect);
            dtTC.Columns[0].ColumnName = "Mã phiếu xét nghiệm";
            dtTC.Columns[1].ColumnName = "Mã bệnh nhân";
            dtTC.Columns[2].ColumnName = "Mã nhân viên";
            dtTC.Columns[3].ColumnName = "Ngày lập";
            dtTC.Columns[4].ColumnName = "Trạng thái";
            dtTC.Columns[5].ColumnName = "Tên bệnh nhân";
            dtTC.Columns[6].ColumnName = "Tên nhân viên";
            return dtTC;
        }

        public static TestCertificateDTO GetTC(int tCID)
        {
            TestCertificateDTO newTC = new TestCertificateDTO();
            string sqlSelect = @"SELECT TCID, PATIENTID, STAFFID, DATE, STATE
                                 FROM TESTCERTIFICATE
                                 WHERE TCID = @TCID";
            NpgsqlParameter[] npgsqlParameters = {
                new NpgsqlParameter("@TCID", tCID)
            };
            DataTable dataTable = NpgSqlResult.ExecuteQuery(sqlSelect, npgsqlParameters);
            if (dataTable.Rows.Count > 0)
            {
                newTC.TCID = Convert.ToInt32(dataTable.Rows[0][0]);
                newTC.PatientID = Convert.ToInt32(dataTable.Rows[0][1]);
                newTC.StaffID = Convert.ToInt32(dataTable.Rows[0][2]);
                newTC.Date = Convert.ToDateTime(dataTable.Rows[0][3]);
                newTC.State = Convert.ToInt32(dataTable.Rows[0][4]);
            }
            return newTC;
        }

        public static int GetCurrentIdentity()
        {
            string sqlSelect = @"SELECT LASTVAL()";
            object ob = NpgSqlResult.ExecuteScalar(sqlSelect);
            return Convert.ToInt32(ob);
        }
    }
}
