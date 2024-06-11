using HOSPITAL_MANAGEMENT_SOURCE.DTO;
using System;
using System.Data;
using Npgsql;

namespace HOSPITAL_MANAGEMENT_SOURCE.DAL
{
    public class Role
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }

        public Role() { }

        public Role(int roleID, string roleName)
        {
            RoleID = roleID;
            RoleName = roleName;
        }

        public static int InsertRole(Role newRole)
        {
            string sqlInsert = @"INSERT INTO ""ROLE"" (RoleName)
                                VALUES (@RoleName)";

            NpgsqlParameter[] npgsqlParameters = {
                new NpgsqlParameter("@RoleName", newRole.RoleName)
            };

            return NpgSqlResult.ExecuteNonQuery(sqlInsert, npgsqlParameters);
        }

        public static int UpdateRole(Role updateRole)
        {
            string sqlUpdate = @"UPDATE ""ROLE""
                                SET RoleName = @RoleName
                                WHERE RoleID = @RoleID";

            NpgsqlParameter[] npgsqlParameters = {
                new NpgsqlParameter("@RoleName", updateRole.RoleName),
                new NpgsqlParameter("@RoleID", updateRole.RoleID)
            };

            return NpgSqlResult.ExecuteNonQuery(sqlUpdate, npgsqlParameters);
        }

        public static int DeleteRole(int roleID)
        {
            string sqlDelete = @"DELETE FROM ""ROLE""
                                WHERE RoleID = @RoleID";

            NpgsqlParameter[] npgsqlParameters = {
                new NpgsqlParameter("@RoleID", roleID)
            };

            return NpgSqlResult.ExecuteNonQuery(sqlDelete, npgsqlParameters);
        }

        public static DataTable GetListRole()
        {
            string sqlSelect = @"SELECT RoleID, RoleName
                                FROM ""ROLE""";

            return NpgSqlResult.ExecuteQuery(sqlSelect);
        }

        public static Role GetRole(int roleID)
        {
            Role newRole = new Role();
            string sqlSelect = @"SELECT RoleID, RoleName
                                FROM ""ROLE""
                                WHERE RoleID = @RoleID";

            NpgsqlParameter[] npgsqlParameters = {
                new NpgsqlParameter("@RoleID", roleID)
            };

            DataTable dataTable = NpgSqlResult.ExecuteQuery(sqlSelect, npgsqlParameters);

            if (dataTable.Rows.Count > 0)
            {
                newRole.RoleID = Convert.ToInt32(dataTable.Rows[0]["RoleID"]);
                newRole.RoleName = dataTable.Rows[0]["RoleName"].ToString();
            }

            return newRole;
        }


        public static int GetCurrentIdentity()
        {
            string sqlSelect = @"SELECT last_value FROM role_roleid_seq";
            object ob = NpgSqlResult.ExecuteScalar(sqlSelect);
            return Convert.ToInt32(ob);
        }
    }
}
