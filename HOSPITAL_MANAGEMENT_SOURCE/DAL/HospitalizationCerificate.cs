using HOSPITAL_MANAGEMENT_SOURCE.DTO;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;

namespace HOSPITAL_MANAGEMENT_SOURCE.DAL
{
    public class HospitalizationCertificate
    {
        public int HCID { get; set; }
        public int PatientID { get; set; }
        public int StaffID { get; set; }
        public String Reason { get; set; }
        public DateTime Date { get; set; }
        public int State { get; set; }

        public HospitalizationCertificate() { }

        public HospitalizationCertificate(int hCID, int patientID, int staffID, String reason, DateTime date, int state)
        {
            this.HCID = hCID;
            this.PatientID = patientID;
            this.StaffID = staffID;
            this.Reason = reason;
            this.Date = date;
            this.State = state;
        }

        public static int InsertHC(HospitalizationCertificateDTO newHC)
        {
            String sqlInsert = @"INSERT INTO HOSPITALIZATIONCERTIFICATE(PATIENTID, STAFFID, REASON, DATE, STATE)
                                VALUES        (@PATIENTID,@STAFFID,@REASON,@DATE,@STATE)";

            NpgsqlParameter[] npgsqlParameters =
            {
                new NpgsqlParameter("@PATIENTID", newHC.PatientID),
                new NpgsqlParameter("@STAFFID", newHC.StaffID),
                new NpgsqlParameter("@REASON", newHC.Reason),
                new NpgsqlParameter("@DATE", newHC.Date),
                new NpgsqlParameter("@STATE", newHC.State)
            };

            return NpgSqlResult.ExecuteNonQuery(sqlInsert, npgsqlParameters);
        }

        public static int UpdateHC(HospitalizationCertificateDTO updateHC)
        {
            string sqlUpdate = @"UPDATE       HOSPITALIZATIONCERTIFICATE
                                SET                PATIENTID =@PATIENTID, STAFFID =@STAFFID, REASON =@REASON, DATE =@DATE, STATE =@STATE
                                WHERE         HCID=@HCID ";

            NpgsqlParameter[] npgsqlParameters =
            {
                new NpgsqlParameter("@HCID", updateHC.HCID),
                new NpgsqlParameter("@PATIENTID", updateHC.PatientID),
                new NpgsqlParameter("@STAFFID", updateHC.StaffID),
                new NpgsqlParameter("@REASON", updateHC.Reason),
                new NpgsqlParameter("@DATE", updateHC.Date),
                new NpgsqlParameter("@STATE", updateHC.State)
            };

            return NpgSqlResult.ExecuteNonQuery(sqlUpdate, npgsqlParameters);
        }

        public static int DeleteHC(int hCID)
        {
            string sqlDelete = @"DELETE FROM HOSPITALIZATIONCERTIFICATE
                                WHERE        (HCID=@HCID)";

            NpgsqlParameter[] npgsqlParameters = { new NpgsqlParameter("@HCID", hCID) };

            return NpgSqlResult.ExecuteNonQuery(sqlDelete, npgsqlParameters);
        }

        public static DataTable GetListHC()
        {
            DataTable dtHC = new DataTable();
            string sqlSelect = @"SELECT        HCID, h.PATIENTID, h.STAFFID, REASON, DATE, h.STATE, p.LASTNAME+' '+p.FIRSTNAME AS 'PATIENT NAME', s.LASTNAME+' '+s.FIRSTNAME AS 'STAFF NAME'
                                FROM            HOSPITALIZATIONCERTIFICATE h join PATIENT p on h.PATIENTID = p.PATIENTID join STAFF s on s.STAFFID = h.STAFFID";

            dtHC = NpgSqlResult.ExecuteQuery(sqlSelect);

            return dtHC;
        }

        public static HospitalizationCertificateDTO GetHC(int hCID)
        {
            HospitalizationCertificateDTO hC = new HospitalizationCertificateDTO();
            string sqlSelect = @"SELECT        HCID, PATIENTID, STAFFID, REASON, DATE, STATE
                                FROM            HOSPITALIZATIONCERTIFICATE
                                WHERE        HCID=@HCID";

            NpgsqlParameter[] npgsqlParameters = { new NpgsqlParameter("@HCID", hCID) };

            DataTable dataTable = NpgSqlResult.ExecuteQuery(sqlSelect, npgsqlParameters);

            if (dataTable.Rows.Count > 0)
            {
                hC.HCID = Convert.ToInt32(dataTable.Rows[0][0]);
                hC.PatientID = Convert.ToInt32(dataTable.Rows[0][1]);
                hC.StaffID = Convert.ToInt32(dataTable.Rows[0][2]);
                hC.Reason = (String)dataTable.Rows[0][3];
                hC.Date = (DateTime)dataTable.Rows[0][4];
                hC.State = (int)dataTable.Rows[0][5];
            }

            return hC;
        }

        // Lấy giấy nhập viện dựa vào thông tin của bệnh nhân 
        public static HospitalizationCertificateDTO GetHC(decimal patientID)
        {
            HospitalizationCertificateDTO hC = new HospitalizationCertificateDTO();
            string sqlSelect = @"SELECT        HCID, PATIENTID, STAFFID, REASON, DATE, STATE
                                FROM            HOSPITALIZATIONCERTIFICATE
                                WHERE        PATIENTID=@PATIENTID";

            NpgsqlParameter[] npgsqlParameters = { new NpgsqlParameter("@PATIENTID", patientID) };

            DataTable dataTable = NpgSqlResult.ExecuteQuery(sqlSelect, npgsqlParameters);

            if (dataTable.Rows.Count > 0)
            {
                hC.HCID = Convert.ToInt32(dataTable.Rows[0][0]);
                hC.PatientID = Convert.ToInt32(dataTable.Rows[0][1]);
                hC.StaffID = Convert.ToInt32(dataTable.Rows[0][2]);
                hC.Reason = (String)dataTable.Rows[0][3];
                hC.Date = (DateTime)dataTable.Rows[0][4];
                hC.State = (int)dataTable.Rows[0][5];
            }

            return hC;
        }

        // Kiểm tra xem bệnh nhân đã có giấy nhập viện chưa
        public static Boolean IsPatientHadHC(int patientID)
        {
            DataTable dtHC = new DataTable();
            string sqlSelect = @"SELECT        HCID, PATIENTID, STAFFID, REASON, DATE, STATE
                                FROM            HOSPITALIZATIONCERTIFICATE
                                WHERE        PATIENTID=@PATIENTID";

            NpgsqlParameter[] npgsqlParameters = { new NpgsqlParameter("@PATIENTID", patientID) };

            dtHC = NpgSqlResult.ExecuteQuery(sqlSelect, npgsqlParameters);

            if (dtHC.Rows.Count > 0)
                return true;

            return false;
        }
    }
}
