using System.Data;
using Npgsql;
using HOSPITAL_MANAGEMENT_SOURCE.DTO;
using System;

namespace HOSPITAL_MANAGEMENT_SOURCE.DAL
{
    public class Medicine
    {
        public int MedicineID { get; set; }
        public string MedicineName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public Medicine() { }

        public Medicine(int medicineID, string medicineName, int quantity, decimal price)
        {
           this.MedicineID = medicineID;
           this.MedicineName = medicineName;
           this.Quantity = quantity;
           this.Price = price;
        }

        public static int InsertMedicine(Medicine newMedicine)
        {
            string sqlInsert = @"INSERT INTO ""MEDICINE""(MEDICINENAME, QUANTITY, PRICE)
                                VALUES (@MEDICINENAME, @QUANTITY, @PRICE)";

            NpgsqlParameter[] npgsqlParameters = {
                new NpgsqlParameter("@MEDICINENAME", newMedicine.MedicineName),
                new NpgsqlParameter("@QUANTITY", newMedicine.Quantity),
                new NpgsqlParameter("@PRICE", newMedicine.Price)
            };

            return NpgSqlResult.ExecuteNonQuery(sqlInsert, npgsqlParameters);
        }
        public static int GetNextMedicineID()
        {
            string sqlSelect = @"SELECT MAX(MEDICINEID) + 1 AS next_billid FROM ""MEDICINE""  ";

            return Convert.ToInt32(NpgSqlResult.ExecuteScalar(sqlSelect));
        }
        public static int UpdateMedicine(Medicine updateMedicine)
        {
            string sqlUpdate = @"UPDATE ""MEDICINE""
                                SET MEDICINENAME = @MEDICINENAME, QUANTITY = @QUANTITY, PRICE = @PRICE
                                WHERE (MEDICINEID = @MEDICINEID)";

            NpgsqlParameter[] npgsqlParameters = {
                new NpgsqlParameter("@MEDICINEID", updateMedicine.MedicineID),
                new NpgsqlParameter("@MEDICINENAME", updateMedicine.MedicineName),
                new NpgsqlParameter("@QUANTITY", updateMedicine.Quantity),
                new NpgsqlParameter("@PRICE", updateMedicine.Price)
            };

            return NpgSqlResult.ExecuteNonQuery(sqlUpdate, npgsqlParameters);
        }

        public static int DeleteMedicine(int medicineID)
        {
            string sqlDelete = @"DELETE FROM ""MEDICINE""
                                WHERE (MEDICINEID = @MEDICINEID)";

            NpgsqlParameter[] npgsqlParameters = { new NpgsqlParameter("@MEDICINEID", medicineID) };

            return NpgSqlResult.ExecuteNonQuery(sqlDelete, npgsqlParameters);
        }

        public static DataTable GetListMedicine()
        {
            string sqlSelect = @"SELECT MEDICINEID, MEDICINENAME, QUANTITY, PRICE
                                FROM ""MEDICINE""";

            DataTable dataTable = NpgSqlResult.ExecuteQuery(sqlSelect);

            return dataTable;
        }

        public static Medicine GetMedicine(int medicineID)
        {
            string sqlSelect = @"SELECT MEDICINEID, MEDICINENAME, QUANTITY, PRICE
                                FROM ""MEDICINE""
                                WHERE (MEDICINEID = @MEDICINEID)";

            NpgsqlParameter[] npgsqlParameters = { new NpgsqlParameter("@MEDICINEID", medicineID) };

            DataTable dataTable = NpgSqlResult.ExecuteQuery(sqlSelect, npgsqlParameters);

            Medicine medicine = new Medicine();
            medicine.MedicineID = Convert.ToInt32(dataTable.Rows[0]["MEDICINEID"]);
            medicine.MedicineName = Convert.ToString(dataTable.Rows[0]["MEDICINENAME"]);
            medicine.Quantity = Convert.ToInt32(dataTable.Rows[0]["QUANTITY"]);
            medicine.Price = Convert.ToDecimal(dataTable.Rows[0]["PRICE"]);

            return medicine;
        }
    }
}
