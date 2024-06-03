using System;
using System.Data;
using Npgsql;

namespace HOSPITAL_MANAGEMENT_SOURCE.DAL
{
    public class RoleFunction
    {
        public int FunctionID { get; set; }
        public string FunctionName { get; set; }
        public string Button { get; set; }

        public RoleFunction() { }

        public RoleFunction(int functionID, string functionName, string button)
        {
            FunctionID = functionID;
            FunctionName = functionName;
            Button = button;
        }

        public static int InsertFunction(RoleFunction newFunction)
        {
            string sqlInsert = @"INSERT INTO ""ROLEFUNCTION""(FunctionName, Button)
                                VALUES (@FunctionName, @Button)";

            NpgsqlParameter[] npgsqlParameters = {
                new NpgsqlParameter("@FunctionName", newFunction.FunctionName),
                new NpgsqlParameter("@Button", newFunction.Button)
            };

            return NpgSqlResult.ExecuteNonQuery(sqlInsert, npgsqlParameters);
        }

        public static int UpdateFunction(RoleFunction updateFunction)
        {
            string sqlUpdate = @"UPDATE ""ROLEFUNCTION""
                                SET FunctionName = @FunctionName, Button = @Button
                                WHERE FunctionID = @FunctionID";

            NpgsqlParameter[] npgsqlParameters = {
                new NpgsqlParameter("@FunctionName", updateFunction.FunctionName),
                new NpgsqlParameter("@Button", updateFunction.Button),
                new NpgsqlParameter("@FunctionID", updateFunction.FunctionID)
            };

            return NpgSqlResult.ExecuteNonQuery(sqlUpdate, npgsqlParameters);
        }

        public static int DeleteFunction(int functionID)
        {
            string sqlDelete = @"DELETE FROM ""ROLEFUNCTION""
                                WHERE FunctionID = @FunctionID";

            NpgsqlParameter[] npgsqlParameters = {
                new NpgsqlParameter("@FunctionID", functionID)
            };

            return NpgSqlResult.ExecuteNonQuery(sqlDelete, npgsqlParameters);
        }

        public static DataTable GetListFunction()
        {
            string sqlSelect = @"SELECT FunctionID, FunctionName, Button
                                FROM ""ROLEFUNCTION""";

            return NpgSqlResult.ExecuteQuery(sqlSelect);
        }

        public static RoleFunction GetFunction(int functionID)
        {
            RoleFunction newFunction = new RoleFunction();
            int tempInteger;
            string sqlSelect = @"SELECT FunctionID, FunctionName, Button
                                FROM ""ROLEFUNCTION""
                                WHERE FunctionID = @FunctionID";

            NpgsqlParameter[] npgsqlParameters = {
                new NpgsqlParameter("@FunctionID", functionID)
            };


            DataTable dataTable = NpgSqlResult.ExecuteQuery(sqlSelect, npgsqlParameters);

            if (dataTable.Rows.Count > 0)
            {
                int.TryParse(dataTable.Rows[0][0].ToString(), out tempInteger);
                newFunction.FunctionID = tempInteger;
                newFunction.FunctionName = dataTable.Rows[0][1].ToString();
                newFunction.Button = dataTable.Rows[0][2].ToString();
            }

            return newFunction;
        }
    }
}
