using HOSPITAL_MANAGEMENT_SOURCE.DTO;
using Npgsql;
using System;
using System.Data;

namespace HOSPITAL_MANAGEMENT_SOURCE.DAL
{
    public class BillType
    {
        public int BillTypeID { get; set; }
        public string TypeName { get; set; }
        public BillType() { }

        // Phương thức khởi tạo
        public BillType(int billTypeID, string typeName)
        {
            this.BillTypeID = billTypeID;
            this.TypeName = typeName;
        }

        // Phương thức lấy thông tin của một loại hóa đơn
        public static BillTypeDTO GetBillType(int billTypeID)
        {
            string sqlSelect = @"SELECT BILLTYPEID, TYPENAME
                                FROM BILLTYPE
                                WHERE BILLTYPEID = @BILLTYPEID";

            NpgsqlParameter[] npgsqlParameters = { new NpgsqlParameter("@BILLTYPEID", billTypeID) };

            DataTable dataTable = NpgSqlResult.ExecuteQuery(sqlSelect, npgsqlParameters);

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];
                BillTypeDTO billType = new BillTypeDTO(
                    Convert.ToInt32(row["BILLTYPEID"]),
                    row["TYPENAME"].ToString()
                );
                return billType;
            }

            return null;
        }

        // Phương thức lấy danh sách các loại hóa đơn
        public static DataTable GetListBillType()
        {
            string sqlSelect = @"SELECT BILLTYPEID AS 'Mã loại hóa đơn', TYPENAME AS 'Tên loại hóa đơn'
                                FROM BILLTYPE";

            return NpgSqlResult.ExecuteQuery(sqlSelect);
        }
    }
}
