using HOSPITAL_MANAGEMENT_SOURCE.DTO;
using System;
using System.Data;
using Npgsql;

namespace HOSPITAL_MANAGEMENT_SOURCE.DAL
{
    public class ServiceBillDetail
    {
        public int BillID { get; set; }
        public int ServiceID { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public ServiceBillDetail() { }

        public ServiceBillDetail(int billID, int serviceID, int quantity, decimal price)
        {
            BillID = billID;
            ServiceID = serviceID;
            Quantity = quantity;
            Price = price;
        }

        public static int InsertServiceBillDetail(ServiceBillDetailDTO newSBD)
        {
            string sqlInsert = @"INSERT INTO ""SERVICEBILLDETAIL""(BILLID, SERVICEID, QUANTITY, PRICE)
                                VALUES (@BILLID, @SERVICEID, @QUANTITY, @PRICE)";

            NpgsqlParameter[] npgsqlParameters = {
                new NpgsqlParameter("@BILLID", newSBD.BillID),
                new NpgsqlParameter("@SERVICEID", newSBD.ServiceID),
                new NpgsqlParameter("@QUANTITY", newSBD.Quantity),
                new NpgsqlParameter("@PRICE", newSBD.Price)
            };

            return NpgSqlResult.ExecuteNonQuery(sqlInsert, npgsqlParameters);
        }

        public static int DeleteServiceBillDetail(int billID, int serviceID)
        {
            string sqlDelete = @"DELETE FROM ""SERVICEBILLDETAIL""
                                WHERE BILLID = @BILLID AND SERVICEID = @SERVICEID";

            NpgsqlParameter[] npgsqlParameters = {
                new NpgsqlParameter("@BILLID", billID),
                new NpgsqlParameter("@SERVICEID", serviceID)
            };

            return NpgSqlResult.ExecuteNonQuery(sqlDelete, npgsqlParameters);
        }

        public static int DeleteServiceBillDetail(int billID)
        {
            string sqlDelete = @"DELETE FROM ""SERVICEBILLDETAIL""
                                WHERE BILLID = @BILLID";

            NpgsqlParameter[] npgsqlParameters = {
                new NpgsqlParameter("@BILLID", billID)
            };

            return NpgSqlResult.ExecuteNonQuery(sqlDelete, npgsqlParameters);
        }

        public static DataTable GetListServiceBillDetail(int billID)
        {
            string sqlSelect = @"SELECT ""SERVICE"".SERVICENAME, ""SERVICEBILLDETAIL"".QUANTITY, ""SERVICEBILLDETAIL"".PRICE
                                FROM ""SERVICEBILLDETAIL""
                                INNER JOIN ""SERVICE"" ON ""SERVICEBILLDETAIL"".SERVICEID = ""SERVICE"".SERVICEID
                                WHERE BILLID = @BILLID";

            NpgsqlParameter[] npgsqlParameters = {
                new NpgsqlParameter("@BILLID", billID)
            };


            return NpgSqlResult.ExecuteQuery(sqlSelect, npgsqlParameters);
        }
    }
}
