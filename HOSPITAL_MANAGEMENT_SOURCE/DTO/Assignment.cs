using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using HOSPITAL_MANAGEMENT_SOURCE.DAL;
using System.Data.SqlClient;

namespace HOSPITAL_MANAGEMENT_SOURCE.DTO
{
    public class Assignment
    {
        public int AssignID { get; set; }
        public int PatientID { get; set; }
        public DateTime Date { get; set; }
        public DateTime DischargedDate { get; set; }
        public DateTime HospitalizateDate { get; set; }

        public Assignment() { }
        public Assignment(int assignID, int patientID, DateTime date, DateTime dischargedDate, DateTime hospitalizateDate)
        {
            this.AssignID = assignID;
            this.PatientID = patientID;
            this.Date = date;
            this.DischargedDate = dischargedDate;
            this.HospitalizateDate = hospitalizateDate;
        }
        public static int InsertAssignment(Assignment newAssignmet)
        {
            String sqlInsert = @"INSERT INTO ASSIGNMENT (PATIENTID, DATE, DISCHARGEDDATE, HOPITALIZATEDATE)
                                VALUES        (@PATIENTID, @DATE,@DISCHARGEDDATE,@HOPITALIZATEDATE)";
            SqlParameter[] sqlParameters = {
                                            new SqlParameter("@PATIENTID", newAssignmet.PatientID),
                                            new SqlParameter("@DATE", newAssignmet.Date),
                                            new SqlParameter("@DISCHARGEDDATE", newAssignmet.DischargedDate),
                                            new SqlParameter("@HOPITALIZATEDATE", newAssignmet.HospitalizateDate)};
            return SqlResult.ExecuteNonQuery(sqlInsert, sqlParameters);
        }
        public static int UpdateAssignment(Assignment updateAssignment)
        {
            string sqlUpdate = @"UPDATE       ASSIGNMENT
                                SET                DATE =@DATE, DISCHARGEDDATE =@DISCHARGEDDATE
                                WHERE         ASSIGNID =@ASSIGNID  ";
            SqlParameter[] sqlParameters = { new SqlParameter("@ASSIGNID", updateAssignment.AssignID ),
                                            new SqlParameter("@DATE", updateAssignment.Date),
                                            new SqlParameter("@DISCHARGEDDATE", updateAssignment.DischargedDate)};
            return SqlResult.ExecuteNonQuery(sqlUpdate, sqlParameters);
        }
        public static int DeleteAssignment(int assignmentID)
        {
            string sqlDelete = @"DELETE FROM ASSIGNMENT
                                WHERE        (ASSIGNID=@ASSIGNID)";
            SqlParameter[] sqlParameters = { new SqlParameter("@ASSIGNID", assignmentID) };
            return SqlResult.ExecuteNonQuery(sqlDelete, sqlParameters);
        }
        public static DataTable GetListAssignment()
        {
            DataTable dtAssignment = new DataTable();
            string sqlSelect = @"SELECT        ASSIGNID, a.PATIENTID, DATE, DISCHARGEDDATE, HOPITALIZATEDATE, p.LASTNAME +' '+p.FIRSTNAME as 'PATIENT NAME'
                                FROM            ASSIGNMENT a join PATIENT p on a.PATIENTID = p.PATIENTID";
            dtAssignment = SqlResult.ExecuteQuery(sqlSelect);
            return dtAssignment;
        }
        public static Assignment GetAssignment(int assignID)
        {
            Assignment assign = new Assignment();
            string sqlSelect = @"SELECT        ASSIGNID, PATIENTID, DATE, DISCHARGEDDATE, HOPITALIZATEDATE
                                 FROM            ASSIGNMENT
                                 WHERE        ASSIGNID=@ASSIGNID";
            SqlParameter[] sqlParameters = { new SqlParameter("@ASSIGNID", assignID) };
            DataTable dataTable = SqlResult.ExecuteQuery(sqlSelect, sqlParameters);
            if (dataTable.Rows.Count > 0)
            {
                assign.AssignID = Convert.ToInt32(dataTable.Rows[0][0]);
                assign.PatientID = Convert.ToInt32(dataTable.Rows[0][1]);
                assign.Date = (DateTime)dataTable.Rows[0][2];
                assign.DischargedDate = (DateTime)dataTable.Rows[0][3];
                assign.HospitalizateDate = (DateTime)dataTable.Rows[0][4];
            }
            return assign;
        }
        public static int GetCurrentIdentity()
        {
            string sqlSelect = @"SELECT IDENT_CURRENT('ASSIGNMENT')  as currIdent";
            object ob = SqlResult.ExecuteScalar(sqlSelect);
            return Convert.ToInt32(ob);
        }
        public static Boolean IsPatientHadAssignment(int patientID)
        {
            DataTable dtA = new DataTable();
            string sqlSelect = @"SELECT        ASSIGNID, DATE, HOPITALIZATEDATE, DISCHARGEDDATE, PATIENTID
                                FROM            ASSIGNMENT
                                WHERE        PATIENTID=@PATIENTID";
            SqlParameter[] sqlParameters = { new SqlParameter("@PATIENTID", patientID) };
            dtA = SqlResult.ExecuteQuery(sqlSelect, sqlParameters);
            if (dtA.Rows.Count > 0)
                return true;
            return false;
        }
    }
}
