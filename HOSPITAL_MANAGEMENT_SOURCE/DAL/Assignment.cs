using System;
using System.Collections.Generic;
using System.Data;
using Npgsql;

namespace HOSPITAL_MANAGEMENT_SOURCE.DAL
{
    public class Assignment
    {
        public int AssignID { get; set; }
        public int PatientID { get; set; }
        public DateTime Date { get; set; }
        public DateTime DischargedDate { get; set; }
        public DateTime HospitalizateDate { get; set; }
        public string PatientName { get; set; }

        public Assignment() { }

        public Assignment(int assignID, int patientID, DateTime date, DateTime dischargedDate, DateTime hospitalizateDate, string patientName)
        {
            this.AssignID = assignID;
            this.PatientID = patientID;
            this.Date = date;
            this.DischargedDate = dischargedDate;
            this.HospitalizateDate = hospitalizateDate;
            this.PatientName = patientName;
        }


        public static int InsertAssignment(Assignment newAssignment)
        {
            string sqlInsert = @"INSERT INTO ""ASSIGNMENT"" (PATIENTID, DATE, DISCHARGEDDATE, HOPITALIZATEDATE)
                                VALUES (@PATIENTID, @DATE, @DISCHARGEDDATE, @HOPITALIZATEDATE)";
            NpgsqlParameter[] npgsqlParameters = {
                new NpgsqlParameter("@PATIENTID", newAssignment.PatientID),
                new NpgsqlParameter("@DATE", newAssignment.Date),
                new NpgsqlParameter("@DISCHARGEDDATE", newAssignment.DischargedDate),
                new NpgsqlParameter("@HOPITALIZATEDATE", newAssignment.HospitalizateDate)
            };
            return NpgSqlResult.ExecuteNonQuery(sqlInsert, npgsqlParameters);
        }


        public static int UpdateAssignment(Assignment updateAssignment)
        {
            string sqlUpdate = @"UPDATE ""ASSIGNMENT""
                                SET DATE = @DATE, DISCHARGEDDATE = @DISCHARGEDDATE
                                WHERE ASSIGNID = @ASSIGNID";
            NpgsqlParameter[] NpgsqlParameters = {
                new NpgsqlParameter("@ASSIGNID", updateAssignment.AssignID),
                new NpgsqlParameter("@DATE", updateAssignment.Date),
                new NpgsqlParameter("@DISCHARGEDDATE", updateAssignment.DischargedDate)
            };
            return NpgSqlResult.ExecuteNonQuery(sqlUpdate, NpgsqlParameters);
        }

        public static int DeleteAssignment(int assignmentID)
        {
            string sqlDelete = @"DELETE FROM ""ASSIGNMENT""
                                WHERE ASSIGNID = @ASSIGNID";
            NpgsqlParameter[] NpgsqlParameters = { new NpgsqlParameter("@ASSIGNID", assignmentID) };
            return NpgSqlResult.ExecuteNonQuery(sqlDelete, NpgsqlParameters);
        }

        public static List<Assignment> GetListAssignment()
        {
            List<Assignment> assignments = new List<Assignment>();
            string sqlSelect = @"SELECT ASSIGNID, a.PATIENTID, DATE, DISCHARGEDDATE, HOPITALIZATEDATE, p.LASTNAME +' '+p.FIRSTNAME as 'PATIENT NAME'
                                FROM ""ASSIGNMENT"" a 
                                JOIN ""PATIENT"" p ON a.PATIENTID = p.PATIENTID";
            DataTable dataTable = NpgSqlResult.ExecuteQuery(sqlSelect);
            foreach (DataRow row in dataTable.Rows)
            {
                Assignment assignment = new Assignment();
                assignment.AssignID = Convert.ToInt32(row["ASSIGNID"]);
                assignment.PatientID = Convert.ToInt32(row["PATIENTID"]);
                assignment.Date = Convert.ToDateTime(row["DATE"]);
                assignment.DischargedDate = Convert.ToDateTime(row["DISCHARGEDDATE"]);
                assignment.HospitalizateDate = Convert.ToDateTime(row["HOPITALIZATEDATE"]);
                assignment.PatientName = row["PATIENT NAME"].ToString();
                assignments.Add(assignment);
            }
            return assignments;
        }

        public static Assignment GetAssignment(int assignID)
        {
            string sqlSelect = @"SELECT ASSIGNID, PATIENTID, DATE, DISCHARGEDDATE, HOPITALIZATEDATE
                                FROM ""ASSIGNMENT""
                                WHERE ASSIGNID = @ASSIGNID";
            NpgsqlParameter[] NpgsqlParameters = { new NpgsqlParameter("@ASSIGNID", assignID) };
            DataTable dataTable = NpgSqlResult.ExecuteQuery(sqlSelect, NpgsqlParameters);

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];
                Assignment assignment = new Assignment();
                assignment.AssignID = Convert.ToInt32(row["ASSIGNID"]);
                assignment.PatientID = Convert.ToInt32(row["PATIENTID"]);
                assignment.Date = Convert.ToDateTime(row["DATE"]);
                assignment.DischargedDate = Convert.ToDateTime(row["DISCHARGEDDATE"]);
                assignment.HospitalizateDate = Convert.ToDateTime(row["HOPITALIZATEDATE"]);
                return assignment;
            }
            return null;
        }

        public static int GetCurrentIdentity()
        {
            string sqlSelect = @"SELECT IDENT_CURRENT('ASSIGNMENT') AS currIdent";
            object ob = NpgSqlResult.ExecuteScalar(sqlSelect);
            return Convert.ToInt32(ob);
        }

        public static bool IsPatientHadAssignment(int patientID)
        {
            string sqlSelect = @"SELECT ASSIGNID, DATE, HOPITALIZATEDATE, DISCHARGEDDATE, PATIENTID
                                FROM ""ASSIGNMENT""
                                WHERE PATIENTID = @PATIENTID";
            NpgsqlParameter[] NpgsqlParameters = { new NpgsqlParameter("@PATIENTID", patientID) };
            DataTable dataTable = NpgSqlResult.ExecuteQuery(sqlSelect, NpgsqlParameters);
            return dataTable.Rows.Count > 0;
        }
    }
}