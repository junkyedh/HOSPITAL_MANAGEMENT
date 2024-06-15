using System.Data;
using Npgsql;
using HOSPITAL_MANAGEMENT_SOURCE.DTO;
using System.Data.SqlClient;

namespace HOSPITAL_MANAGEMENT_SOURCE.DAL
{
    public class MedicineBillDetail
    {
        public int MedicineID { get; set; }
        public int BillID { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public MedicineBillDetail() { }

        public MedicineBillDetail(int billID, int medicineID, int quantity, decimal price)
        {
            this.BillID = billID;
            this.MedicineID = medicineID;
            this.Quantity = quantity;
            this.Price = price;
        }

        public static int InsertMedicineBillDetail(MedicineBillDetail newMBD)
        {
            string sqlInsert = @"INSERT INTO 
                                    ""MEDICINEBILLDETAIL""(BILLID, MEDICINEID, QUANTITY, PRICE)
                                VALUES 
                                    (@BILLID, @MEDICINEID, @QUANTITY, @PRICE)";

            NpgsqlParameter[] npgsqlParameters = {
                new NpgsqlParameter("@BILLID", newMBD.BillID),
                new NpgsqlParameter("@MEDICINEID", newMBD.MedicineID),
                new NpgsqlParameter("@QUANTITY", newMBD.Quantity),
                new NpgsqlParameter("@PRICE", newMBD.Price)
            };

            return NpgSqlResult.ExecuteNonQuery(sqlInsert, npgsqlParameters);
        }

        public static int DeleteMedicineBillDetail(int billID, int medicineID)
        {
            string sqlDelete = @"DELETE FROM MEDICINEBILLDETAIL
                                WHERE BILLID = @BILLID AND MEDICINEID = @MEDICINEID";

            NpgsqlParameter[] npgsqlParameters = {
                new NpgsqlParameter("@BILLID", billID),
                new NpgsqlParameter("@MEDICINEID", medicineID)
            };

            return NpgSqlResult.ExecuteNonQuery(sqlDelete, npgsqlParameters);
        }

        public static int DeleteMedicineBillDetail(int billID)
        {
            string sqlDelete = @"DELETE FROM MEDICINEBILLDETAIL
                                WHERE BILLID = @BILLID";

            NpgsqlParameter[] npgsqlParameters = {
                new NpgsqlParameter("@BILLID", billID)
            };

            return NpgSqlResult.ExecuteNonQuery(sqlDelete, npgsqlParameters);
        }

        public static DataTable GetListMedicineBillDetail(int billID)
        {
            DataTable dtMBD = new DataTable();

            string sqlSelect = @"SELECT MEDICINE.MEDICINENAME, MEDICINEBILLDETAIL.QUANTITY, MEDICINEBILLDETAIL.PRICE
                                FROM MEDICINEBILLDETAIL
                                INNER JOIN MEDICINE ON MEDICINEBILLDETAIL.MEDICINEID = MEDICINE.MEDICINEID
                                WHERE BILLID = @BILLID";

            NpgsqlParameter[] npgsqlParameters = {
                new NpgsqlParameter("@BILLID", billID)
            };

            dtMBD = NpgSqlResult.ExecuteQuery(sqlSelect, npgsqlParameters);

            return dtMBD;
        }
    }
}
