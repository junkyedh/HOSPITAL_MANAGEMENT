using System;
using System.Data;
using Npgsql;

namespace HOSPITAL_MANAGEMENT_SOURCE.DAL
{
    public class PrescriptionDetail
    {
        public int MedicineID { get; set; }
        public int PrescriptionID { get; set; }
        public int Quantity { get; set; }
        public string Instruction { get; set; }

        public PrescriptionDetail() { }

        public PrescriptionDetail(int medicineID, int prescriptionID, int quantity, string instruction)
        {
            MedicineID = medicineID;
            PrescriptionID = prescriptionID;
            Quantity = quantity;
            Instruction = instruction;
        }

        public static int InsertPrescriptionDetail(PrescriptionDetail newPD)
        {
            string sqlInsert = @"INSERT INTO ""PRESCRIPTIONDETAIL""(PRESCRIPTIONID, MEDICINEID, QUANTITY, INSTRUCTION)
                                VALUES (@PrescriptionID, @MedicineID, @Quantity, @Instruction)";

            NpgsqlParameter[] npgsqlParameters = {
                new NpgsqlParameter("@PrescriptionID", newPD.PrescriptionID),
                new NpgsqlParameter("@MedicineID", newPD.MedicineID),
                new NpgsqlParameter("@Quantity", newPD.Quantity),
                new NpgsqlParameter("@Instruction", newPD.Instruction)
            };

            return NpgSqlResult.ExecuteNonQuery(sqlInsert, npgsqlParameters);
        }

        public static int DeletePrescriptionDetail(int prescriptionID, int medicineID)
        {
            string sqlDelete = @"DELETE FROM ""PRESCRIPTIONDETAIL""
                                WHERE PRESCRIPTIONID = @PrescriptionID AND MEDICINEID = @MedicineID";

            NpgsqlParameter[] npgsqlParameters = {
                new NpgsqlParameter("@PrescriptionID", prescriptionID),
                new NpgsqlParameter("@MedicineID", medicineID)
            };

            return NpgSqlResult.ExecuteNonQuery(sqlDelete, npgsqlParameters);
        }

        public static int DeletePrescriptionDetail(int prescriptionID)
        {
            string sqlDelete = @"DELETE FROM ""PRESCRIPTIONDETAIL""
                                WHERE PRESCRIPTIONID = @PrescriptionID";

            NpgsqlParameter[] npgsqlParameters = {
                new NpgsqlParameter("@PrescriptionID", prescriptionID)
            };

            return NpgSqlResult.ExecuteNonQuery(sqlDelete, npgsqlParameters);
        }

        public static DataTable GetListPrescriptionDetail(int prescriptionID)
        {
            string sqlSelect = @"SELECT PRESCRIPTIONID, MEDICINEID, QUANTITY, INSTRUCTION
                                FROM ""PRESCRIPTIONDETAIL""
                                WHERE PRESCRIPTIONID = @PrescriptionID";

            NpgsqlParameter[] npgsqlParameters = {
                new NpgsqlParameter("@PrescriptionID", prescriptionID)
            };

            return NpgSqlResult.ExecuteQuery(sqlSelect, npgsqlParameters);
        }

        public static DataTable GetListPrescriptionDetailWithMedicine(int prescriptionID)
        {
            string sqlSelect = @"SELECT ""MEDICINE"".MEDICINEID, ""MEDICINE"".MEDICINENAME, ""PRESCRIPTIONDETAIL"".QUANTITY, ""MEDICINE"".PRICE * ""PRESCRIPTIONDETAIL"".QUANTITY AS PRICE
                                FROM ""PRESCRIPTIONDETAIL""
                                INNER JOIN ""MEDICINE"" ON ""PRESCRIPTIONDETAIL"".MEDICINEID = ""MEDICINE"".MEDICINEID
                                WHERE ""PRESCRIPTIONDETAIL"".PRESCRIPTIONID = @PrescriptionID";

            NpgsqlParameter[] npgsqlParameters = {
                new NpgsqlParameter("@PrescriptionID", prescriptionID)
            };



            return NpgSqlResult.ExecuteQuery(sqlSelect, npgsqlParameters);
        }
    }
}
