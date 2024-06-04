using HOSPITAL_MANAGEMENT_SOURCE.DTO;
using System;
using System.Data;
using Npgsql;

namespace HOSPITAL_MANAGEMENT_SOURCE.DAL
{
    public class Bill
    {
        public const int PAY = 1;
        public const int UNPAY = 0;
        public const int MEDICINEBILL = 100;
        public const int SERVICEBILL = 101;
        public const int MATERIALBILL = 102;
        public static DataTable billTable;

        public int BillID { get; set; }
        public int BillTypeID { get; set; }
        public int PatientID { get; set; }
        public int StaffID { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalPrice { get; set; }
        public int State { get; set; }
        
        public Bill() { }
        public Bill( int billID, int billTypeID, int patientID, int staffID, DateTime date, decimal totalPrice, int state)
        {
            this.BillID = billID;
            this.BillTypeID = billTypeID;
            this.PatientID = patientID;
            this.StaffID = staffID;
            this.Date = date;
            this.TotalPrice = totalPrice;
            this.State = state;
        }
        public static int InsertBill(BillDTO newBill)
        {
            string sqlInsert = @"INSERT INTO BILL(BILLTYPEID, PATIENTID, STAFFID, DATE, STATE, TOTALPRICE)
                                VALUES (@BILLTYPEID, @PATIENTID, @STAFFID, @DATE, @STATE, @TOTALPRICE)";

            NpgsqlParameter[] npgsqlParameters = {
                new NpgsqlParameter("@BILLTYPEID", newBill.BillTypeID),
                new NpgsqlParameter("@PATIENTID", newBill.PatientID),
                new NpgsqlParameter("@STAFFID", newBill.StaffID),
                new NpgsqlParameter("@DATE", newBill.Date),
                new NpgsqlParameter("@STATE", newBill.State),
                new NpgsqlParameter("@TOTALPRICE", newBill.TotalPrice)
            };

            return NpgSqlResult.ExecuteNonQuery(sqlInsert, npgsqlParameters);
        }

        public static int UpdateBill(BillDTO updateBill)
        {
            string sqlUpdate = @"UPDATE BILL
                                SET STATE = @STATE, TOTALPRICE = @TOTALPRICE
                                WHERE BILLID = @BILLID";

            NpgsqlParameter[] npgsqlParameters = {
                new NpgsqlParameter("@STATE", updateBill.State),
                new NpgsqlParameter("@TOTALPRICE", updateBill.TotalPrice),
                new NpgsqlParameter("@BILLID", updateBill.BillID)
            };

            return NpgSqlResult.ExecuteNonQuery(sqlUpdate, npgsqlParameters);
        }

        public static int DeleteBill(int billID)
        {
            string sqlDelete = @"DELETE FROM BILL
                                WHERE BILLID = @BILLID";

            NpgsqlParameter[] npgsqlParameters = { new NpgsqlParameter("@BILLID", billID) };

            return NpgSqlResult.ExecuteNonQuery(sqlDelete, npgsqlParameters);
        }

        public static DataTable GetListBill()
        {
            string sqlSelect = @"SELECT BILL.BILLID, BILLTYPE.TYPENAME, PATIENT.FIRSTNAME AS PATIENTFIRSTNAME,
                                PATIENT.LASTNAME AS PATIENTLASTNAME, BILL.BILLTYPEID, BILL.PATIENTID, BILL.STAFFID,
                                BILL.DATE, BILL.TOTALPRICE,BILL.STATE, STAFF.LASTNAME AS STAFFLASTNAME,
                                STAFF.FIRSTNAME AS STAFFFIRSTNAME
                                FROM BILL INNER JOIN
                                BILLTYPE ON BILL.BILLTYPEID = BILLTYPE.BILLTYPEID INNER JOIN
                                PATIENT ON BILL.PATIENTID = PATIENT.PATIENTID INNER JOIN
                                STAFF ON BILL.STAFFID = STAFF.STAFFID";

            return NpgSqlResult.ExecuteQuery(sqlSelect);
        }

        public static DataTable GetPatientBill(int patientID)
        {
            string sqlSelect = @"SELECT BILLID, BILLTYPEID, PATIENTID, STAFFID, DATE, TOTALPRICE, STATE
                                FROM BILL
                                WHERE (PATIENTID = @PATIENTID)";

            NpgsqlParameter[] npgsqlParameters = { new NpgsqlParameter("@PATIENTID", patientID) };

            return NpgSqlResult.ExecuteQuery(sqlSelect, npgsqlParameters);
        }

        public static int GetNextBillID()
        {
            string sqlSelect = @"SELECT IDENT_CURRENT('BILL') + IDENT_INCR('BILL') as NEXTIDENTITY";

            return Convert.ToInt32(NpgSqlResult.ExecuteScalar(sqlSelect));
        }

        public static int GetCurrentBillID()
        {
            string sqlSelect = @"SELECT IDENT_CURRENT('BILL') as CURRENTIDENTITY";

            return Convert.ToInt32(NpgSqlResult.ExecuteScalar(sqlSelect));
        }

        public static BillDTO GetBill(int billID)
        {
            string sqlSelect = @"SELECT BILLID, BILLTYPEID, PATIENTID, STAFFID, DATE, TOTALPRICE, STATE
                                FROM BILL
                                WHERE BILLID=@BILLID";

            NpgsqlParameter[] npgsqlParameters = { new NpgsqlParameter("@BILLID", billID) };

            DataTable dataTable = NpgSqlResult.ExecuteQuery(sqlSelect, npgsqlParameters);

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];
                BillDTO billDTO = new BillDTO
                {
                    BillID = Convert.ToInt32(row["BILLID"]),
                    BillTypeID = Convert.ToInt32(row["BILLTYPEID"]),
                    PatientID = Convert.ToInt32(row["PATIENTID"]),
                    StaffID = Convert.ToInt32(row["STAFFID"]),
                    Date = Convert.ToDateTime(row["DATE"]),
                    TotalPrice = Convert.ToDecimal(row["TOTALPRICE"]),
                    State = Convert.ToInt32(row["STATE"])
                };
                return billDTO;
            }

            return null;
        }

        public static bool ConfirmPatient(int patientID)
        {
            DataTable dtPatientBill = GetPatientNotPayBill(patientID);
            foreach (DataRow row in dtPatientBill.Rows)
            {
                int billState = Convert.ToInt32(row["STATE"]);
                if (billState == 0)
                    return false;
            }
            return true;
        }

        public static DataTable GetPatientNotPayBill(int patientID)
        {
            string sqlSelect = @"SELECT BILLID, BILLTYPEID, PATIENTID, STAFFID, DATE, TOTALPRICE, STATE
                                FROM BILL
                                WHERE (PATIENTID = @PATIENTID) AND (STATE = 0)";

            NpgsqlParameter[] npgsqlParameters = { new NpgsqlParameter("@PATIENTID", patientID) };

            return NpgSqlResult.ExecuteQuery(sqlSelect, npgsqlParameters);
        }

        public static decimal GetPatientPriceNeedPay(int patientID)
        {
            decimal totalPrice = 0;

            string sqlSelect = @"SELECT SUM(TOTALPRICE)
                                FROM BILL
                                WHERE (PATIENTID = @PATIENTID) AND (STATE = 0)";

            NpgsqlParameter[] npgsqlParameters = { new NpgsqlParameter("@PATIENTID", patientID) };

            object result = NpgSqlResult.ExecuteScalar(sqlSelect, npgsqlParameters);
            if (result != null && result != DBNull.Value)
            {
                decimal.TryParse(result.ToString(), out totalPrice);
            }

            return totalPrice;
        }
    }
}
