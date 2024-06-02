using HOSPITAL_MANAGEMENT_SOURCE.DTO;
using System;
using System.Data;
using Npgsql;

namespace HOSPITAL_MANAGEMENT_SOURCE.DAL
{
    public class RoleDetail
    {
        public int RoleID { get; set; }
        public int FunctionID { get; set; }

        public RoleDetail() { }

        public RoleDetail(int roleID, int functionID)
        {
            RoleID = roleID;
            FunctionID = functionID;
        }

        public static int InsertRoleDetail(RoleDetailDTO newRD)
        {
            string sqlInsert = @"INSERT INTO ""ROLEDETAIL""(RoleID, FunctionID)
                                VALUES (@RoleID, @FunctionID)";

            NpgsqlParameter[] npgsqlParameters = {
                new NpgsqlParameter("@RoleID", newRD.RoleID),
                new NpgsqlParameter("@FunctionID", newRD.FunctionID)
            };

            return NpgSqlResult.ExecuteNonQuery(sqlInsert, npgsqlParameters);
        }

        public static int DeleteRoleDetail(int roleID, int functionID)
        {
            string sqlDelete = @"DELETE FROM ""ROLEDETAIL""
                                WHERE RoleID = @RoleID AND FunctionID = @FunctionID";

            NpgsqlParameter[] npgsqlParameters = {
                new NpgsqlParameter("@RoleID", roleID),
                new NpgsqlParameter("@FunctionID", functionID)
            };

            return NpgSqlResult.ExecuteNonQuery(sqlDelete, npgsqlParameters);
        }

        public static int DeleteRoleDetail(int roleID)
        {
            string sqlDelete = @"DELETE FROM ""ROLEDETAIL""
                                WHERE RoleID = @RoleID";

            NpgsqlParameter[] npgsqlParameters = {
                new NpgsqlParameter("@RoleID", roleID)
            };

            return NpgSqlResult.ExecuteNonQuery(sqlDelete, npgsqlParameters);
        }

        public static DataTable GetListStaffFunction(int roleID)
        {
            string sqlSelect = @"SELECT RF.FunctionID, RF.FunctionName, RF.Button
                                FROM ""ROLEDETAIL"" RD
                                INNER JOIN ""ROLEFUNCTION"" RF ON RD.FunctionID = RF.FunctionID
                                WHERE RD.RoleID = @RoleID";

            NpgsqlParameter[] npgsqlParameters = {
                new NpgsqlParameter("@RoleID", roleID)
            };


            return NpgSqlResult.ExecuteQuery(sqlSelect, npgsqlParameters);
        }
    }
}
