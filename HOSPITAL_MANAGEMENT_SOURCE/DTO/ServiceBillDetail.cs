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
    public class ServiceBillDetail
    {
        public int BillID { get; set; }
        public int ServiceID { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public ServiceBillDetail() { }

        public ServiceBillDetail(int billID, int serviceID, int quantity, decimal price)
        {
            this.BillID = billID;
            this.ServiceID = serviceID;
            this.Quantity = quantity;
            this.Price = price;
        }

        public static int InsertServiceBillDetail(ServiceBillDetail newSBD)
        {
            String sqlInsert = @"INSERT INTO SERVICEBILLDETAIL(BILLID, SERVICEID, QUANTITY, PRICE)
                                VALUES        (@BILLID,@SERVICEID,@QUANTITY,@PRICE)";

            SqlParameter[] sqlParameters = { new SqlParameter("@BILLID", newSBD.BillID),
                                            new SqlParameter("@SERVICEID", newSBD.ServiceID),
                                            new SqlParameter("@QUANTITY", newSBD.Quantity),
                                           new SqlParameter("@PRICE",newSBD.Price)};

            return SqlResult.ExecuteNonQuery(sqlInsert, sqlParameters);
        }

        public Boolean UpdateServiceBillDetail()
        {
            return true;
        }

        public static int DeleteServiceBillDetail(int billID, int serviceID)
        {
            string sqlDelete = @"DELETE FROM SERVICEBILLDETAIL
                                WHERE BILLID=@BILLID AND SERVICEID=@SERVICRID";

            SqlParameter[] sqlParameters = { new SqlParameter("@BILLID", billID),
                                           new SqlParameter("@SERVICEID", serviceID)};

            return SqlResult.ExecuteNonQuery(sqlDelete, sqlParameters);
        }

        public static int DeleteServiceBillDetail(int billID)
        {
            string sqlDelete = @"DELETE FROM SERVICEBILLDETAIL
                                WHERE BILLID=@BILLID";

            SqlParameter[] sqlParameters = { new SqlParameter("@BILLID", billID) };

            return SqlResult.ExecuteNonQuery(sqlDelete, sqlParameters);
        }

        public static DataTable GetListServiceBillDetail(int billID)
        {
            DataTable dtSBD = new DataTable();

            string sqlSelect = @"SELECT         SERVICE.SERVICENAME, SERVICEBILLDETAIL.QUANTITY, SERVICEBILLDETAIL.PRICE
                                FROM            SERVICEBILLDETAIL INNER JOIN
                                                SERVICE ON SERVICEBILLDETAIL.SERVICEID = SERVICE.SERVICEID
                                WHERE           BILLID=@BILLID";

            SqlParameter[] sqlParameters = { new SqlParameter("@BILLID", billID) };

            dtSBD = SqlResult.ExecuteQuery(sqlSelect, sqlParameters);

            return dtSBD;
        }
    }
}
