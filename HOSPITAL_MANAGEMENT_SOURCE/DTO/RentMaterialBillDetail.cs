using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using HOSPITAL_MANAGEMENT_SOURCE.DAL;

namespace HOSPITAL_MANAGEMENT_SOURCE.DTO
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
            this.BillID = billID;
            this.MaterialID = materialID;
            this.Quantity = quantity;
            this.Price = price;
        }

        public static int InsertRentMaterialBillDetail(RentMaterialBillDetail newRMBD)
        {
            String sqlInsert = @"INSERT INTO RENTMATERIALBILLDETAIL(BILLID, MATERIALID, QUANTITY, PRICE)
                                VALUES        (@BILLID,@MATERIALID,@QUANTITY,@PRICE)";

            SqlParameter[] sqlParameters = { new SqlParameter("@BILLID", newRMBD.BillID),
                                            new SqlParameter("@MATERIALID", newRMBD.MaterialID),
                                            new SqlParameter("@QUANTITY", newRMBD.Quantity),
                                           new SqlParameter("@PRICE",newRMBD.Price)};

            return SqlResult.ExecuteNonQuery(sqlInsert, sqlParameters);
        }

        public static int DeleteRentMaterialBillDetail(int billID, int materialID)
        {
            string sqlDelete = @"DELETE FROM RENTMATERIALBILLDETAIL
                                WHERE BILLID=@BILLID AND MATERIALID=@MATERIALID";

            SqlParameter[] sqlParameters = { new SqlParameter("@BILLID", billID),
                                           new SqlParameter("@MATERIALID", materialID)};

            return SqlResult.ExecuteNonQuery(sqlDelete, sqlParameters);
        }

        public static int DeleteRentMaterialBillDetail(int billID)
        {
            string sqlDelete = @"DELETE FROM RENTMATERIALBILLDETAIL
                                WHERE BILLID=@BILLID";

            SqlParameter[] sqlParameters = { new SqlParameter("@BILLID", billID) };

            return SqlResult.ExecuteNonQuery(sqlDelete, sqlParameters);
        }

        public static DataTable GetListRentMaterialBillDetail(int billID)
        {
            DataTable dtRMBD;

            string sqlSelect = @"SELECT         MATERIAL.MATERIALNAME, RENTMATERIALBILLDETAIL.QUANTITY, RENTMATERIALBILLDETAIL.PRICE
                                FROM            MATERIAL INNER JOIN
                                                RENTMATERIALBILLDETAIL ON MATERIAL.MATERIALID = RENTMATERIALBILLDETAIL.MATERIALID
                                WHERE           BILLID=@BILLID";

            SqlParameter[] sqlParameters = { new SqlParameter("@BILLID", billID) };

            dtRMBD = SqlResult.ExecuteQuery(sqlSelect, sqlParameters);

            return dtRMBD;
        }
    }
}
