using System;
using System.Data;
using Npgsql;
using HOSPITAL_MANAGEMENT_SOURCE.DTO;

namespace HOSPITAL_MANAGEMENT_SOURCE.DAL
{
    public class SurgicalDetail
    {
        public int SurgicalID { get; set; }
        public int StaffID { get; set; }

        public SurgicalDetail() { }

        public SurgicalDetail(int surgicalID, int staffID)
        {
            this.SurgicalID = surgicalID;
            this.StaffID = staffID;
        }

        public static int InsertSurgicalDetail(SurgicalDetailDTO newSD)
        {
            string sqlInsert = @"INSERT INTO SURGICALDETAIL (SURGICALID, STAFFID)
                                 VALUES (@SURGICALID, @STAFFID)";
            NpgsqlParameter[] npgsqlParameters = {
                new NpgsqlParameter("@SURGICALID", newSD.SurgicalID),
                new NpgsqlParameter("@STAFFID", newSD.StaffID)
            };
            return NpgSqlResult.ExecuteNonQuery(sqlInsert, npgsqlParameters);
        }
        public Boolean UpdateSurgicalDetail()
        {
            return true;
        }

        public static int DeleteSurgicalDetail(int surgicalID, int staffID)
        {
            string sqlDelete = @"DELETE FROM SURGICALDETAIL
                                 WHERE SURGICALID = @SURGICALID AND STAFFID = @STAFFID";
            NpgsqlParameter[] npgsqlParameters = {
                new NpgsqlParameter("@SURGICALID", surgicalID),
                new NpgsqlParameter("@STAFFID", staffID)
            };
            return NpgSqlResult.ExecuteNonQuery(sqlDelete, npgsqlParameters);
        }


        public static int DeleteSurgicalDetail(int surgicalID)
        {
            string sqlDelete = @"DELETE FROM SURGICALDETAIL
                                 WHERE SURGICALID = @SURGICALID";
            NpgsqlParameter[] npgsqlParameters = {
                new NpgsqlParameter("@SURGICALID", surgicalID)
            };
            return NpgSqlResult.ExecuteNonQuery(sqlDelete, npgsqlParameters);
        }

        public static DataTable GetListSurgicalDetail(int surgicalID)
        {
            DataTable dtSD = new DataTable();
            string sqlSelect = @"SELECT sd.SURGICALID, s.STAFFID, s.LASTNAME, s.FIRSTNAME
                                 FROM SURGICALDETAIL sd
                                 INNER JOIN STAFF s ON sd.STAFFID = s.STAFFID
                                 WHERE sd.SURGICALID = @SURGICALID";
            NpgsqlParameter[] npgsqlParameters = {
                new NpgsqlParameter("@SURGICALID", surgicalID)
            };
            dtSD = NpgSqlResult.ExecuteQuery(sqlSelect, npgsqlParameters);
            dtSD.Columns[0].ColumnName = "Mã ca phẫu thuật";
            dtSD.Columns[1].ColumnName = "Mã nhân viên";
            dtSD.Columns[2].ColumnName = "Họ";
            dtSD.Columns[3].ColumnName = "Tên";
            return dtSD;
        }
    }
}
