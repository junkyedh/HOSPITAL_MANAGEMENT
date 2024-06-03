using System;
using System.Data;
using Npgsql;

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

        public int InsertMajor(Major major)
        {
            string sqlInsert = @"INSERT INTO ""MAJOR""(MAJORNAME)
                                VALUES (@MajorName)";

            NpgsqlParameter[] npgsqlParameters = { new NpgsqlParameter("@MajorName", major.MajorName) };

            return NpgSqlResult.ExecuteNonQuery(sqlInsert, npgsqlParameters);
        }

        public int UpdateMajor(Major major)
        {
            string sqlUpdate = @"UPDATE ""MAJOR""
                                SET MAJORNAME = @MajorName
                                WHERE (MAJORID = @MajorID)";

            NpgsqlParameter[] npgsqlParameters = {
                new NpgsqlParameter("@MajorID", major.MajorID),
                new NpgsqlParameter("@MajorName", major.MajorName)
            };

            return NpgSqlResult.ExecuteNonQuery(sqlUpdate, npgsqlParameters);
        }

        public int DeleteMajor(int majorID)
        {
            string sqlDelete = @"DELETE FROM ""MAJOR""
                                WHERE (MAJORID = @MajorID)";

            NpgsqlParameter[] npgsqlParameters = { new NpgsqlParameter("@MajorID", majorID) };

            return NpgSqlResult.ExecuteNonQuery(sqlDelete, npgsqlParameters);
        }

        public DataTable GetListMajor()
        {
            string sqlSelect = @"SELECT MAJORID, MAJORNAME
                                FROM ""MAJOR""";

            DataTable dataTable = NpgSqlResult.ExecuteQuery(sqlSelect);

            return dataTable;
        }

        public Major GetMajor(int majorID)
        {
            string sqlSelect = @"SELECT MAJORID, MAJORNAME
                                FROM ""MAJOR""
                                WHERE (MAJORID = @MAJORID)";

            NpgsqlParameter[] npgsqlParameters = { new NpgsqlParameter("@MAJORID", majorID) };

            DataTable dataTable = NpgSqlResult.ExecuteQuery(sqlSelect, npgsqlParameters);

            Major major = new Major();
            major.MajorID = Convert.ToInt32(dataTable.Rows[0]["MAJORID"]);
            major.MajorName = Convert.ToString(dataTable.Rows[0]["MAJORNAME"]);

            return major;
        }

    }
}
