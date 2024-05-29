using System;
using System.Collections.Generic;
using System.Data;
using Npgsql;
using HOSPITAL_MANAGEMENT_SOURCE.DTO;

namespace HOSPITAL_MANAGEMENT_SOURCE.DAL
{
    internal class AssignmentDetail
    {
        public int AssignID { get; set; }
        public int StaffID { get; set; }

        public AssignmentDetail() { }
        public AssignmentDetail(int assignID, int staffID)
        {
            this.AssignID = assignID;
            this.StaffID = staffID;
        }

        public static int InsertAssignmentDetails(AssignmentDetailDTO newAD)
        {
            string sqlInsert = @"INSERT INTO ASSIGNMENTDETAIL(ASSIGNID, STAFFID)
                                VALUES (@ASSIGNID, @STAFFID)";
            NpgsqlParameter[] npgsqlParameters = {
                new NpgsqlParameter("@ASSIGNID", newAD.AssignID),
                new NpgsqlParameter("@STAFFID", newAD.StaffID)
            };
            return NpgSqlResult.ExecuteNonQuery(sqlInsert, npgsqlParameters);
        }

        public int DeleteAssignmentDetails(AssignmentDetailDTO deleteAD)
        {
            string sqlDelete = @"DELETE FROM ASSIGNMENTDETAIL
                                WHERE (ASSIGNID = @ASSIGNID AND STAFFID = @STAFFID)";
            NpgsqlParameter[] npgsqlParameters = {
                new NpgsqlParameter("@ASSIGNID", deleteAD.AssignID),
                new NpgsqlParameter("@STAFFID", deleteAD.StaffID)
            };
            return NpgSqlResult.ExecuteNonQuery(sqlDelete, npgsqlParameters);
        }

        public static int DeleteAssignmentDetails(int assignmentID)
        {
            string sqlDelete = @"DELETE FROM ASSIGNMENTDETAIL
                                WHERE (ASSIGNID = @ASSIGNID)";
            NpgsqlParameter[] npgsqlParameters = { new NpgsqlParameter("@ASSIGNID", assignmentID) };
            return NpgSqlResult.ExecuteNonQuery(sqlDelete, npgsqlParameters);
        }

        public static List<AssignmentDetailDTO> GetListAssignmentDetails(int assignmentID)
        {
            List<AssignmentDetailDTO> list = new List<AssignmentDetailDTO>();
            string sqlSelect = @"SELECT ASSIGNMENTDETAIL.ASSIGNID, ASSIGNMENTDETAIL.STAFFID, STAFF.LASTNAME, STAFF.FIRSTNAME
                                FROM ASSIGNMENTDETAIL INNER JOIN STAFF ON ASSIGNMENTDETAIL.STAFFID = STAFF.STAFFID
                                WHERE (ASSIGNMENTDETAIL.ASSIGNID = @ASSIGNID)";
            NpgsqlParameter[] npgsqlParameters = { new NpgsqlParameter("@ASSIGNID", assignmentID) };
            DataTable dtAD = NpgSqlResult.ExecuteQuery(sqlSelect, npgsqlParameters);

            foreach (DataRow row in dtAD.Rows)
            {
                AssignmentDetailDTO assignmentDetailDTO = new AssignmentDetailDTO();
                assignmentDetailDTO.AssignID = Convert.ToInt32(row["ASSIGNID"]);
                assignmentDetailDTO.StaffID = Convert.ToInt32(row["STAFFID"]);
                assignmentDetailDTO.StaffName = row["LASTNAME"] + " " + row["FIRSTNAME"];
                list.Add(assignmentDetailDTO);
            }

            return list;
        }

        public AssignmentDetailDTO ToDTO()
        {
            return new AssignmentDetailDTO
            {
                AssignID = this.AssignID,
                StaffID = this.StaffID,
                StaffName = string.Empty
            };
        }
    }
}
