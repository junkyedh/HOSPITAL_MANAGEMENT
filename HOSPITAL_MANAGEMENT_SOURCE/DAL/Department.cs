using System.Data;
using Npgsql;
using System;

namespace HOSPITAL_MANAGEMENT_SOURCE.DAL
{

    public class Department
    {
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }

        public Department() {}
        public Department(int departmentID, string DepartmentName)
        {
            this.DepartmentID = departmentID;
            this.DepartmentName = DepartmentName;
        }

        public static int InsertDepartment(Department newDepartment)
        {
            string sqlInsert = @"INSERT INTO ""DEPARTMENT"" (DEPARTMENTNAME) VALUES (@DEPARTMENTNAME)";
            NpgsqlParameter[] npgsqlParameters = { new NpgsqlParameter("@DEPARTMENTNAME", newDepartment.DepartmentName) };
            return NpgSqlResult.ExecuteNonQuery(sqlInsert, npgsqlParameters);
        }

        public static int UpdateDepartment(Department updateDepartment)
        {
            string sqlUpdate = @"UPDATE ""DEPARTMENT"" SET DEPARTMENTNAME = @DEPARTMENTNAME WHERE (DEPARTMENTID = @DEPARTMENTID)";
            NpgsqlParameter[] npgsqlParameters = {
                new NpgsqlParameter("@DEPARTMENTID", updateDepartment.DepartmentID),
                new NpgsqlParameter("@DEPARTMENTNAME", updateDepartment.DepartmentName)
            };
            return NpgSqlResult.ExecuteNonQuery(sqlUpdate, npgsqlParameters);
        }

        public static int DeleteDepartment(int departmentID)
        {
            string sqlDelete = @"DELETE FROM ""DEPARTMENT"" WHERE (DEPARTMENTID = @DEPARTMENTID)";
            NpgsqlParameter[] npgsqlParameters = { new NpgsqlParameter("@DEPARTMENTID", departmentID) };
            return NpgSqlResult.ExecuteNonQuery(sqlDelete, npgsqlParameters);
        }

        public static Department GetDepartment(int departmentID)
        {
            string sqlSelect = @"SELECT DEPARTMENTID, DEPARTMENTNAME FROM ""DEPARTMENT"" WHERE (DEPARTMENTID = @DEPARTMENTID)";
            NpgsqlParameter[] npgsqlParameters = { new NpgsqlParameter("@DEPARTMENTID", departmentID) };
            DataTable dataTable = NpgSqlResult.ExecuteQuery(sqlSelect, npgsqlParameters);
            if (dataTable.Rows.Count > 0)
            {
                Department department = new Department
                {
                    DepartmentID = Convert.ToInt32(dataTable.Rows[0]["DEPARTMENTID"]),
                    DepartmentName = dataTable.Rows[0]["DEPARTMENTNAME"].ToString()
                };
                return department;
            }
            return null;
        }

        public static DataTable GetListDepartment()
        {
            string sqlSelect = @"SELECT DEPARTMENTID, DEPARTMENTNAME FROM ""DEPARTMENT""";
            return NpgSqlResult.ExecuteQuery(sqlSelect);
        }

    }
}