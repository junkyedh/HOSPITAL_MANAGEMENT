using System.Data;
using Npgsql;
using HOSPITAL_MANAGEMENT_SOURCE.DTO;
using System;

namespace HOSPITAL_MANAGEMENT_SOURCE.DAL
{
    public class Material
    {
        public int MaterialID { get; set; }
        public string MaterialName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public Material() { }

        public Material(int materialID, string materialName, int quantity, decimal price)
        {
            MaterialID = materialID;
            MaterialName = materialName;
            Quantity = quantity;
            Price = price;
        }

        public static int InsertMaterial(MaterialDTO newMaterial)
        {
            string sqlInsert = @"INSERT INTO ""MATERIAL""(MATERIALNAME, QUANTITY, PRICE)
                                VALUES (@MATERIALNAME, @QUANTITY, @PRICE)";

            NpgsqlParameter[] npgsqlParameters = {
                new NpgsqlParameter("@MATERIALNAME", newMaterial.MaterialName),
                new NpgsqlParameter("@QUANTITY", newMaterial.Quantity),
                new NpgsqlParameter("@PRICE", newMaterial.Price)
            };

            return NpgSqlResult.ExecuteNonQuery(sqlInsert, npgsqlParameters);
        }

        public static int UpdateMaterial(MaterialDTO updateMaterial)
        {
            string sqlUpdate = @"UPDATE ""MATERIAL""
                                SET MATERIALNAME = @MATERIALNAME, QUANTITY = @QUANTITY, PRICE = @PRICE
                                WHERE (MATERIALID = @MATERIALID)";

            NpgsqlParameter[] npgsqlParameters = {
                new NpgsqlParameter("@MATERIALID", updateMaterial.MaterialID),
                new NpgsqlParameter("@MATERIALNAME", updateMaterial.MaterialName),
                new NpgsqlParameter("@QUANTITY", updateMaterial.Quantity),
                new NpgsqlParameter("@PRICE", updateMaterial.Price)
            };

            return NpgSqlResult.ExecuteNonQuery(sqlUpdate, npgsqlParameters);
        }

        public static int DeleteMaterial(int materialID)
        {
            string sqlDelete = @"DELETE FROM ""MATERIAL""
                                WHERE (MATERIALID = @MATERIALID)";

            NpgsqlParameter[] npgsqlParameters = { new NpgsqlParameter("@MATERIALID", materialID) };

            return NpgSqlResult.ExecuteNonQuery(sqlDelete, npgsqlParameters);
        }

        public static DataTable GetListMaterial()
        {
            string sqlSelect = @"SELECT MATERIALID, MATERIALNAME, QUANTITY, PRICE
                                FROM ""MATERIAL""";

            DataTable dataTable = NpgSqlResult.ExecuteQuery(sqlSelect);

            return dataTable;
        }

        public static MaterialDTO GetMaterial(int materialID)
        {
            string sqlSelect = @"SELECT MATERIALID, MATERIALNAME, QUANTITY, PRICE
                                FROM ""MATERIAL""
                                WHERE (MATERIALID = @MATERIALID)";

            NpgsqlParameter[] npgsqlParameters = { new NpgsqlParameter("@MATERIALID", materialID) };

            DataTable dataTable = NpgSqlResult.ExecuteQuery(sqlSelect, npgsqlParameters);

            MaterialDTO material = new MaterialDTO();
            material.MaterialID = Convert.ToInt32(dataTable.Rows[0]["MATERIALID"]);
            material.MaterialName = Convert.ToString(dataTable.Rows[0]["MATERIALNAME"]);
            material.Quantity = Convert.ToInt32(dataTable.Rows[0]["QUANTITY"]);
            material.Price = Convert.ToDecimal(dataTable.Rows[0]["PRICE"]);

            return material;
        }
    }
}
