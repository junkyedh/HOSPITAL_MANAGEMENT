using System.Data;
using Npgsql;
using System.Configuration;

namespace HOSPITAL_MANAGEMENT_SOURCE.DAL
{
    public static class NpgSqlResult
    {
        //Get ConnectionString in app.config
        private static string npgsqlConnectString = ConfigurationManager.ConnectionStrings["Server=localhost;Port=5432;Database=Hospital_Management;User Id=postgres;Password=admin123;"].ConnectionString;

        //Execute insert, update, delete command without parameters
        public static int ExecuteNonQuery(string commandString)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(npgsqlConnectString))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(commandString, connection))
                {
                    return command.ExecuteNonQuery();
                }
            }
        }

        //Execute insert, update, delete command with parameters
        public static int ExecuteNonQuery(string commandString, NpgsqlParameter[] npgsqlParameters)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(npgsqlConnectString))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(commandString, connection))
                {
                    command.Parameters.AddRange(npgsqlParameters);
                    return command.ExecuteNonQuery();
                }
            }
        }

        //Execute select without parameters
        public static DataTable ExecuteQuery(string commandString)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(npgsqlConnectString))
            {
                connection.Open();
                using (NpgsqlDataAdapter npgsqlDataAdapter = new NpgsqlDataAdapter(commandString, connection))
                {
                    DataTable dataTable = new DataTable();
                    npgsqlDataAdapter.Fill(dataTable);
                    return dataTable;
                }
            }
        }

        //Execute select with parameters
        public static DataTable ExecuteQuery(string commandString, NpgsqlParameter[] npgsqlParameters)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(npgsqlConnectString))
            {
                connection.Open();
                using (NpgsqlDataAdapter npgsqlDataAdapter = new NpgsqlDataAdapter(commandString, connection))
                {
                    npgsqlDataAdapter.SelectCommand.Parameters.AddRange(npgsqlParameters);
                    DataTable dataTable = new DataTable();
                    npgsqlDataAdapter.Fill(dataTable);
                    return dataTable;
                }
            }
        }

        //Execute scalar command without parameters
        public static object ExecuteScalar(string commandString)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(npgsqlConnectString))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(commandString, connection))
                {
                    return command.ExecuteScalar();
                }
            }
        }

        //Execute scalar command with parameters
        public static object ExecuteScalar(string commandString, NpgsqlParameter[] npgsqlParameters)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(npgsqlConnectString))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(commandString, connection))
                {
                    command.Parameters.AddRange(npgsqlParameters);
                    return command.ExecuteScalar();
                }
            }
        }
    }
}
