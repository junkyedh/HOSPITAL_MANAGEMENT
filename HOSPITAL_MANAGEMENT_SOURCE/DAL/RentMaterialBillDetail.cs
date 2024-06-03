using System;
using System.Data;
using Npgsql;

namespace HOSPITAL_MANAGEMENT_SOURCE.DAL
{
    public class RentMaterialBillDetail
    {
        public int BillID { get; set; }
        public int MaterialID { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public RentMaterialBillDetail() { }

        public RentMaterialBillDetail(int billID, int materialID, int quantity, decimal price)
        {
            BillID = billID;
            MaterialID = materialID;
            Quantity = quantity;
            Price = price;
        }

        public static int InsertRentMaterialBillDetail(RentMaterialBillDetail newRMBD)
        {
            string sqlInsert = @"INSERT INTO ""RENTMATERIALBILLDETAIL""(BILLID, MATERIALID, QUANTITY, PRICE)
                                VALUES (@BillID, @MaterialID, @Quantity, @Price)";

            NpgsqlParameter[] npgsqlParameters = {
                new NpgsqlParameter("@BillID", newRMBD.BillID),
                new NpgsqlParameter("@MaterialID", newRMBD.MaterialID),
                new NpgsqlParameter("@Quantity", newRMBD.Quantity),
                new NpgsqlParameter("@Price", newRMBD.Price)
            };

            return NpgSqlResult.ExecuteNonQuery(sqlInsert, npgsqlParameters);
        }

        public static int DeleteRentMaterialBillDetail(int billID, int materialID)
        {
            string sqlDelete = @"DELETE FROM ""RENTMATERIALBILLDETAIL""
                                WHERE BILLID = @BillID AND MATERIALID = @MaterialID";

            NpgsqlParameter[] npgsqlParameters = {
                new NpgsqlParameter("@BillID", billID),
                new NpgsqlParameter("@MaterialID", materialID)
            };

            return NpgSqlResult.ExecuteNonQuery(sqlDelete, npgsqlParameters);
        }

        public static int DeleteRentMaterialBillDetail(int billID)
        {
            string sqlDelete = @"DELETE FROM ""RENTMATERIALBILLDETAIL""
                                WHERE BILLID = @BillID";

            NpgsqlParameter[] npgsqlParameters = {
                new NpgsqlParameter("@BillID", billID)
            };

            return NpgSqlResult.ExecuteNonQuery(sqlDelete, npgsqlParameters);
        }

        public static DataTable GetListRentMaterialBillDetail(int billID)
        {
            string sqlSelect = @"SELECT ""MATERIAL"".MATERIALNAME, ""RENTMATERIALBILLDETAIL"".QUANTITY, ""RENTMATERIALBILLDETAIL"".PRICE
                                FROM ""MATERIAL""
                                INNER JOIN ""RENTMATERIALBILLDETAIL"" ON ""MATERIAL"".MATERIALID = ""RENTMATERIALBILLDETAIL"".MATERIALID
                                WHERE BILLID = @BillID";


            NpgsqlParameter[] npgsqlParameters = {
                new NpgsqlParameter("@BillID", billID)
            };

            return NpgSqlResult.ExecuteQuery(sqlSelect, npgsqlParameters);
        }
    }
}
