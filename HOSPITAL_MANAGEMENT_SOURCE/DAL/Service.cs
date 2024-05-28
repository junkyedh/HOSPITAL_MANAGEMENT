using HOSPITAL_MANAGEMENT_SOURCE.DTO;
using System;
using System.Data;
using Npgsql;

namespace HOSPITAL_MANAGEMENT_SOURCE.DAL
{
    public class Service
    {
        public int ServiceID { get; set; }
        public string ServiceName { get; set; }
        public decimal Price { get; set; }

        public Service() { }

        public Service(int serviceID, string serviceName, decimal price)
        {
            ServiceID = serviceID;
            ServiceName = serviceName;
            Price = price;
        }

        public static int InsertService(ServiceDTO newService)
        {
            string sqlInsert = @"INSERT INTO SERVICE(ServiceName, Price)
                                VALUES (@ServiceName, @Price)";

            NpgsqlParameter[] npgsqlParameters = {
                new NpgsqlParameter("@ServiceName", newService.ServiceName),
                new NpgsqlParameter("@Price", newService.Price)
            };

            return NpgSqlResult.ExecuteNonQuery(sqlInsert, npgsqlParameters);
        }

        public static int UpdateService(ServiceDTO updateService)
        {
            string sqlUpdate = @"UPDATE SERVICE
                                SET ServiceName = @ServiceName, Price = @Price
                                WHERE ServiceID = @ServiceID";

            NpgsqlParameter[] npgsqlParameters = {
                new NpgsqlParameter("@ServiceName", updateService.ServiceName),
                new NpgsqlParameter("@Price", updateService.Price),
                new NpgsqlParameter("@ServiceID", updateService.ServiceID)
            };

            return NpgSqlResult.ExecuteNonQuery(sqlUpdate, npgsqlParameters);
        }

        public static int DeleteService(int serviceID)
        {
            string sqlDelete = @"DELETE FROM SERVICE
                                WHERE ServiceID = @ServiceID";

            NpgsqlParameter[] npgsqlParameters = {
                new NpgsqlParameter("@ServiceID", serviceID)
            };

            return NpgSqlResult.ExecuteNonQuery(sqlDelete, npgsqlParameters);
        }

        public static DataTable GetListService()
        {
            string sqlSelect = @"SELECT ServiceID, ServiceName, Price
                                FROM SERVICE";

            return NpgSqlResult.ExecuteQuery(sqlSelect);
        }

        public static Service GetService(int serviceID)
        {
            Service newService = new Service();
            int tempInteger;
            string sqlSelect = @"SELECT ServiceID, ServiceName, Price
                                FROM SERVICE
                                WHERE ServiceID = @ServiceID";

            NpgsqlParameter[] npgsqlParameters = {
                new NpgsqlParameter("@ServiceID", serviceID)
            };

            DataTable dataTable = NpgSqlResult.ExecuteQuery(sqlSelect, npgsqlParameters);

            if (dataTable.Rows.Count > 0)
            {
                int.TryParse(dataTable.Rows[0][0].ToString(), out tempInteger);
                newService.ServiceID = tempInteger;
                newService.ServiceName = dataTable.Rows[0][1].ToString();
                newService.Price = Convert.ToDecimal(dataTable.Rows[0][2]);
            }

            return newService;
        }

        public static Service GetServiceExamination()
        {
            Service newService = new Service();
            int tempInteger;
            string sqlSelect = @"SELECT ServiceID, ServiceName, Price
                                FROM SERVICE
                                WHERE ServiceID = 100";

            DataTable dataTable = NpgSqlResult.ExecuteQuery(sqlSelect);

            if (dataTable.Rows.Count > 0)
            {
                int.TryParse(dataTable.Rows[0][0].ToString(), out tempInteger);
                newService.ServiceID = tempInteger;
                newService.ServiceName = dataTable.Rows[0][1].ToString();
                newService.Price = Convert.ToDecimal(dataTable.Rows[0][2]);
            }

            return newService;
        }
    }
}
