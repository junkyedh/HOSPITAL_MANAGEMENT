using System;
using System.Data;
using Npgsql;
using HOSPITAL_MANAGEMENT_SOURCE.DTO;

namespace HOSPITAL_MANAGEMENT_SOURCE.DAL
{
    public class Major
    {
        public int MajorID { get; set; }
        public string MajorName { get; set; }

        public Major() { }

        public Major(int majorID, string majorName)
        {
            MajorID = majorID;
            MajorName = majorName;
        }

        public static int InsertMajor(Major major)
        {
            string sqlInsert = @"INSERT INTO ""MAJOR""(MAJORNAME)
                                VALUES (@MajorName)";

            NpgsqlParameter[] npgsqlParameters = { new NpgsqlParameter("@MajorName", major.MajorName) };

            return NpgSqlResult.ExecuteNonQuery(sqlInsert, npgsqlParameters);
        }

        public static int UpdateMajor(Major updateMajor)
        {
            string sqlUpdate = @"UPDATE ""MAJOR""
                                SET MAJORNAME = @MajorName
                                WHERE (MAJORID = @MajorID)";

            NpgsqlParameter[] npgsqlParameters = {
                new NpgsqlParameter("@MajorID", updateMajor.MajorID),
                new NpgsqlParameter("@MajorName", updateMajor.MajorName)
            };

            return NpgSqlResult.ExecuteNonQuery(sqlUpdate, npgsqlParameters);
        }

        public static int DeleteMajor(int majorID)
        {
            string sqlDelete = @"DELETE FROM ""MAJOR""
                                WHERE (MAJORID = @MajorID)";

            NpgsqlParameter[] npgsqlParameters = { new NpgsqlParameter("@MajorID", majorID) };

            return NpgSqlResult.ExecuteNonQuery(sqlDelete, npgsqlParameters);
        }
        // public static DataTable GetListRole()
        public static DataTable GetListMajor()
        {
            string sqlSelect = @"SELECT MAJORID, MAJORNAME
                                FROM ""MAJOR""";
            DataTable dataTable = NpgSqlResult.ExecuteQuery(sqlSelect);

            return dataTable;
        }

        public static Major GetMajor(int majorID)
        {
            Major newMajor = new Major();
            string sqlSelect = @"SELECT MAJORID, MAJORNAME
                                FROM ""MAJOR""
                                WHERE (MAJORID = @MAJORID)";

            NpgsqlParameter[] npgsqlParameters = { new NpgsqlParameter("@MAJORID", majorID) };

            DataTable majorTable = NpgSqlResult.ExecuteQuery(sqlSelect, npgsqlParameters);

            if (majorTable.Rows.Count > 0)
            {
                newMajor.MajorID = Convert.ToInt32(majorTable.Rows[0]["MAJORID"]);
                newMajor.MajorName = majorTable.Rows[0]["MAJORNAME"].ToString();
            }

            return newMajor;
        }
    }
}
