using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using HOSPITAL_MANAGEMENT_SOURCE.DAL;

namespace HOSPITAL_MANAGEMENT_SOURCE.DTO
{
    public class AssignmentDetail
    {
        public int AssignID { get; set; }
        public int StaffID { get; set; }

        public AssignmentDetail()
        {

        }
        public AssignmentDetail(int assignID, int staffID)
        {
            this.AssignID = assignID;
            this.StaffID = staffID;
        }
        public static int InsertAssignmentDetails(AssignmentDetail newAD)
        {
            String sqlInsert = @"INSERT INTO ASSIGNMENTDETAIL(ASSIGNID, STAFFID)
                                VALUES        (@ASSIGNID,@STAFFID)";
            SqlParameter[] sqlParameters = { new SqlParameter("@ASSIGNID", newAD.AssignID),
                                            new SqlParameter("@STAFFID", newAD.StaffID)};
            return SqlResult.ExecuteNonQuery(sqlInsert, sqlParameters);
        }
        public static int DeleteAssignmentDetails(AssignmentDetail deleteAD)
        {
            string sqlDelete = @"DELETE FROM ASSIGNMENTDETAIL
                                WHERE        (ASSIGNID=@ASSIGNID AND STAFFID=@STAFFID)";
            SqlParameter[] sqlParameters = { new SqlParameter("@ASSIGNID", deleteAD.AssignID),
                                                 new SqlParameter("@STAFFID", deleteAD.StaffID)};
            return SqlResult.ExecuteNonQuery(sqlDelete, sqlParameters);
        }
        public static int DeleteAssignmentDetails(int assignmentID)
        {
            string sqlDelete = @"DELETE FROM ASSIGNMENTDETAIL
                                WHERE        (ASSIGNID=@ASSIGNID)";
            SqlParameter[] sqlParameters = { new SqlParameter("@ASSIGNID", assignmentID) };
            return SqlResult.ExecuteNonQuery(sqlDelete, sqlParameters);
        }
        public static DataTable GetListAssignmentDetails(int assignmentID)
        {
            DataTable dtAD = new DataTable();
            string sqlSelect = @"SELECT        ASSIGNMENTDETAIL.ASSIGNID, ASSIGNMENTDETAIL.STAFFID, STAFF.LASTNAME, STAFF.FIRSTNAME
                                FROM            ASSIGNMENTDETAIL INNER JOIN STAFF ON ASSIGNMENTDETAIL.STAFFID = STAFF.STAFFID
                                WHERE        (ASSIGNMENTDETAIL.ASSIGNID=@ASSIGNID)";
            SqlParameter[] sqlParameters = { new SqlParameter("@ASSIGNID", assignmentID) };
            dtAD = SqlResult.ExecuteQuery(sqlSelect, sqlParameters);
            dtAD.Columns[0].ColumnName = "Mã phân công";
            dtAD.Columns[1].ColumnName = "Mã nhân viên";
            dtAD.Columns[2].ColumnName = "Họ nhân viên";
            dtAD.Columns[3].ColumnName = "Tên nhân viên";
            return dtAD;
        }
    }
}
