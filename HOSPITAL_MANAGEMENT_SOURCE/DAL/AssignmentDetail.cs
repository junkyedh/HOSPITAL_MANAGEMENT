using System;
using System.Collections.Generic;
using System.Data;
using Npgsql;

namespace HOSPITAL_MANAGEMENT_SOURCE.DAL
{
    internal class AssignmentDetail
    {
        public int AssignID { get; set; }
        public int StaffID { get; set; }
        public string StaffName { get; set; }


        public AssignmentDetail() { }
        public AssignmentDetail(int assignID, int staffID, string staffName)
        {
            this.AssignID = assignID;
            this.StaffID = staffID;
            this.StaffName = staffName;
        }

        public static int InsertAssignmentDetails(AssignmentDetail newAD)
        {
            string sqlInsert = @"INSERT INTO ""ASSIGNMENTDETAIL""(ASSIGNID, STAFFID)
                                VALUES (@ASSIGNID, @STAFFID)";
            NpgsqlParameter[] npgsqlParameters = {
                new NpgsqlParameter("@ASSIGNID", newAD.AssignID),
                new NpgsqlParameter("@STAFFID", newAD.StaffID)
            };
            return NpgSqlResult.ExecuteNonQuery(sqlInsert, npgsqlParameters);
        }

        public int DeleteAssignmentDetails(AssignmentDetail deleteAD)
        {
            string sqlDelete = @"DELETE FROM ""ASSIGNMENTDETAIL""
                                WHERE (ASSIGNID = @ASSIGNID AND STAFFID = @STAFFID)";
            NpgsqlParameter[] npgsqlParameters = {
                new NpgsqlParameter("@ASSIGNID", deleteAD.AssignID),
                new NpgsqlParameter("@STAFFID", deleteAD.StaffID)
            };
            return NpgSqlResult.ExecuteNonQuery(sqlDelete, npgsqlParameters);
        }

        public static int DeleteAssignmentDetails(int assignmentID)
        {
            string sqlDelete = @"DELETE FROM ""ASSIGNMENTDETAIL""
                                WHERE (ASSIGNID = @ASSIGNID)";
            NpgsqlParameter[] npgsqlParameters = { new NpgsqlParameter("@ASSIGNID", assignmentID) };
            return NpgSqlResult.ExecuteNonQuery(sqlDelete, npgsqlParameters);
        }


        public static List<AssignmentDetail> GetListAssignmentDetails(int assignmentID)
        {
            List<AssignmentDetail> list = new List<AssignmentDetail>();
            string sqlSelect = @"SELECT ""ASSIGNMENTDETAIL"".ASSIGNID, ""ASSIGNMENTDETAIL"".STAFFID, ""STAFF"".LASTNAME, ""STAFF"".FIRSTNAME
                                FROM ""ASSIGNMENTDETAIL"" INNER JOIN ""STAFF"" ON ""ASSIGNMENTDETAIL"".STAFFID = ""STAFF"".STAFFID
                                WHERE (""ASSIGNMENTDETAIL"".ASSIGNID = @ASSIGNID)";
            NpgsqlParameter[] npgsqlParameters = { new NpgsqlParameter("@ASSIGNID", assignmentID) };
            DataTable dtAD = NpgSqlResult.ExecuteQuery(sqlSelect, npgsqlParameters);

            foreach (DataRow row in dtAD.Rows)
            {
                AssignmentDetail AssignmentDetail = new AssignmentDetail();
                AssignmentDetail.AssignID = Convert.ToInt32(row["ASSIGNID"]);
                AssignmentDetail.StaffID = Convert.ToInt32(row["STAFFID"]);
                AssignmentDetail.StaffName = row["LASTNAME"] + " " + row["FIRSTNAME"];
                list.Add(AssignmentDetail);
            }

            return list;
        }

        public AssignmentDetail ToDTO()
        {
            return new AssignmentDetail
            {
                AssignID = this.AssignID,
                StaffID = this.StaffID,
                StaffName = string.Empty
            };
        }
    }
}