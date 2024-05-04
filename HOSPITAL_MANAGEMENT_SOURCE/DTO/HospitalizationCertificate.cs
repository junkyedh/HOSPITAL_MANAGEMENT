using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using HOSPITAL_MANAGEMENT_SOURCE.DAL;

namespace HOSPITAL_MANAGEMENT_SOURCE.DTO
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
        public static int InsertHC(HospitalizationCertificate newHC)
        {
            String sqlInsert = @"INSERT INTO HOSPITALIZATIONCERTIFICATE(PATIENTID, STAFFID, REASON, DATE, STATE)
                                VALUES        (@PATIENTID,@STAFFID,@REASON,@DATE,@STATE)";
            SqlParameter[] sqlParameters = { new SqlParameter("@PATIENTID", newHC.PatientID),
                                            new SqlParameter("@STAFFID", newHC.StaffID),
                                            new SqlParameter("@REASON", newHC.Reason),
                                            new SqlParameter("@DATE", newHC.Date),
                                            new SqlParameter("@STATE", newHC.State)};
            return SqlResult.ExecuteNonQuery(sqlInsert, sqlParameters);
        }
        public static int UpdateHC(HospitalizationCertificate updateHC)
        {
            string sqlUpdate = @"UPDATE       HOSPITALIZATIONCERTIFICATE
                                SET                PATIENTID =@PATIENTID, STAFFID =@STAFFID, REASON =@REASON, DATE =@DATE, STATE =@STATE
                                WHERE         HCID=@HCID ";
            SqlParameter[] sqlParameters = { new SqlParameter("@HCID", updateHC.HCID ),
                                            new SqlParameter("@PATIENTID", updateHC.PatientID),
                                           new SqlParameter("@STAFFID", updateHC.StaffID),
                                           new SqlParameter("@REASON", updateHC.Reason),
                                           new SqlParameter("@DATE", updateHC.Date),
                                           new SqlParameter("@STATE", updateHC.State)};
            return SqlResult.ExecuteNonQuery(sqlUpdate, sqlParameters);
        }
        public static int DeleteHC(int hCID)
        {
            string sqlDelete = @"DELETE FROM HOSPITALIZATIONCERTIFICATE
                                WHERE        (HCID=@HCID)";
            SqlParameter[] sqlParameters = { new SqlParameter("@HCID", hCID) };
            return SqlResult.ExecuteNonQuery(sqlDelete, sqlParameters);
        }
        public static DataTable GetListHC()
        {
            DataTable dtHC = new DataTable();
            string sqlSelect = @"SELECT        HCID, h.PATIENTID, h.STAFFID, REASON, DATE, h.STATE, p.LASTNAME+' '+p.FIRSTNAME AS 'PATIENT NAME', s.LASTNAME+' '+s.FIRSTNAME AS 'STAFF NAME'
                                FROM            HOSPITALIZATIONCERTIFICATE h join PATIENT p on h.PATIENTID = p.PATIENTID join STAFF s on s.STAFFID = h.STAFFID";
            dtHC = SqlResult.ExecuteQuery(sqlSelect);
            //dtHC.Columns[0].ColumnName = "Mã giấy xuất viện";
            //dtHC.Columns[1].ColumnName = "Mã bệnh nhân";
            //dtHC.Columns[2].ColumnName = "Mã nhân viên";
            //dtHC.Columns[3].ColumnName = "Lý do nhập viện";
            //dtHC.Columns[4].ColumnName = "Ngày lập";
            //dtHC.Columns[5].ColumnName = "Trạng thái";
            //dtHC.Columns[6].ColumnName = "Tên bệnh nhân";
            //dtHC.Columns[7].ColumnName = "Tên nhân viên";
            return dtHC;
        }
        public static HospitalizationCertificate GetHC(int hCID)
        {
            HospitalizationCertificate hC = new HospitalizationCertificate();
            string sqlSelect = @"SELECT        HCID, PATIENTID, STAFFID, REASON, DATE, STATE
                                FROM            HOSPITALIZATIONCERTIFICATE
                                WHERE        HCID=@HCID";
            SqlParameter[] sqlParameters = { new SqlParameter("@HCID", hCID) };
            DataTable dataTable = SqlResult.ExecuteQuery(sqlSelect, sqlParameters);
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
        public static HospitalizationCertificate GetHC(decimal patientID)
        {
            HospitalizationCertificate hC = new HospitalizationCertificate();
            string sqlSelect = @"SELECT        HCID, PATIENTID, STAFFID, REASON, DATE, STATE
                                FROM            HOSPITALIZATIONCERTIFICATE
                                WHERE        PATIENTID=@PATIENTID";
            SqlParameter[] sqlParameters = { new SqlParameter("@PATIENTID", patientID) };
            DataTable dataTable = SqlResult.ExecuteQuery(sqlSelect, sqlParameters);
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
            SqlParameter[] sqlParameters = { new SqlParameter("@PATIENTID", patientID) };
            dtHC = SqlResult.ExecuteQuery(sqlSelect, sqlParameters);
            if (dtHC.Rows.Count > 0)
                return true;
            return false;
        }
    }
}
