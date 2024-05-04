using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using HOSPITAL_MANAGEMENT_SOURCE.DAL;

namespace HOSPITAL_MANAGEMENT_SOURCE.DTO
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

        public Bill(int billTypeID, int patientID, int staffID)
        {
            this.BillTypeID = billTypeID;
            this.PatientID = patientID;
            this.StaffID = staffID;
        }

        public Bill(int billID, int billTypeID, int patientID, int staffID, DateTime date, decimal totalPrice, int state)
        {
            this.BillID = billID;
            this.BillTypeID = billTypeID;
            this.PatientID = patientID;
            this.StaffID = staffID;
            this.Date = date;
            this.TotalPrice = totalPrice;
            this.State = state;
        }

        public static int InsertBill(Bill newBill)
        {
            String sqlInsert = @"INSERT INTO    BILL(BILLTYPEID, PATIENTID, STAFFID, DATE, STATE, TOTALPRICE)
                                VALUES          (@BILLTYPEID, @PATIENTID, @STAFFID, @DATE, @STATE, @TOTALPRICE)";
            SqlParameter[] sqlParameters = { new SqlParameter("@BILLTYPEID", newBill.BillTypeID),
                                            new SqlParameter("@PATIENTID", newBill.PatientID),
                                            new SqlParameter("@STAFFID", newBill.StaffID),
                                            new SqlParameter("@DATE", newBill.Date),
                                            new SqlParameter("@STATE", newBill.State),
                                            new SqlParameter("@TOTALPRICE", newBill.TotalPrice)};
            return SqlResult.ExecuteNonQuery(sqlInsert, sqlParameters);
        }

        public static int UpdateBill(Bill updateBill)
        {
            string sqlUpdate = @"UPDATE     BILL
                                SET         STATE = @STATE, TOTALPRICE = @TOTALPRICE
                                WHERE       BILLID=@BILLID";

            SqlParameter[] sqlParameters = { new SqlParameter("@BILLID", updateBill.BillID),
                                           new SqlParameter("@STATE",updateBill.State),
                                           new SqlParameter("@TOTALPRICE",updateBill.TotalPrice)};

            return SqlResult.ExecuteNonQuery(sqlUpdate, sqlParameters);
        }

        public static int DeleteBill(int billID)
        {
            string sqlDelete = @"DELETE FROM BILL
                                WHERE (BILLID=@BILLID)";

            SqlParameter[] sqlParameters = { new SqlParameter("@BILLID", billID) };

            return SqlResult.ExecuteNonQuery(sqlDelete, sqlParameters);
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

            billTable = SqlResult.ExecuteQuery(sqlSelect);

            return billTable;
        }

        public static DataTable GetPatientBill(int patientID)
        {
            DataTable patientBillTable = new DataTable();
            string sqlSelect = @"SELECT BILLID, BILLTYPEID, PATIENTID, STAFFID, DATE, TOTALPRICE, STATE
                                FROM    BILL
                                WHERE   (PATIENTID=@PATIENTID)";

            SqlParameter[] sqlParameters = { new SqlParameter("@PATIENTID", patientID) };

            patientBillTable = SqlResult.ExecuteQuery(sqlSelect, sqlParameters);

            return patientBillTable;
        }

        // Get next identity bill ID in database
        public static int GetNextBillID()
        {
            string sqlSelect = @"SELECT IDENT_CURRENT('BILL') + IDENT_INCR('BILL') as NEXTIDENTITY";

            return Convert.ToInt32(SqlResult.ExecuteScalar(sqlSelect));
        }

        // Get current identity bill ID in database
        public static int GetCurrentBillID()
        {
            string sqlSelect = @"SELECT IDENT_CURRENT('BILL') as CURRENTIDENTITY";

            return Convert.ToInt32(SqlResult.ExecuteScalar(sqlSelect));
        }

        public static Bill GetBill(int billID)
        {
            Bill newBill = new Bill();
            string sqlSelect = @"SELECT BILLID, BILLTYPEID, PATIENTID, STAFFID, DATE, TOTALPRICE, STATE
                                FROM BILL
                                WHERE BILLID=@BILLID";

            SqlParameter[] sqlParameters = { new SqlParameter("@BILLID", billID) };

            DataTable dataTable = SqlResult.ExecuteQuery(sqlSelect, sqlParameters);

            if (dataTable.Rows.Count > 0)
            {
                newBill.BillID = Convert.ToInt32(dataTable.Rows[0]["BILLID"].ToString());
                newBill.BillTypeID = Convert.ToInt32(dataTable.Rows[0]["BILLTYPEID"].ToString());
                newBill.PatientID = Convert.ToInt32(dataTable.Rows[0]["PATIENTID"]);
                newBill.StaffID = Convert.ToInt32(dataTable.Rows[0]["STAFFID"]);
                newBill.Date = (DateTime)dataTable.Rows[0]["DATE"];
                newBill.TotalPrice = (decimal)dataTable.Rows[0]["TOTALPRICE"];
                newBill.State = (int)dataTable.Rows[0]["STATE"];
            }
            return newBill;
        }
        //Check can confirm DC of patient. If there are any bill haven't paid yes, return false
        public static Boolean ConfirmPatient(int patientID)
        {
            DataTable dtPatientBill = Bill.GetPatientBill(patientID);
            for (int i = 0; i < dtPatientBill.Rows.Count; i++)
            {
                int billState = Convert.ToInt32(dtPatientBill.Rows[i][6]);
                if (billState == 0)
                    return false;
            }
            return true;
        }

        public static DataTable GetPatientNotPayBill(int patientID)
        {
            DataTable patientBillTable = new DataTable();
            string sqlSelect = @"SELECT BILLID, BILLTYPEID, PATIENTID, STAFFID, DATE, TOTALPRICE, STATE
                                FROM    BILL
                                WHERE   (PATIENTID=@PATIENTID) AND STATE = 0";

            SqlParameter[] sqlParameters = { new SqlParameter("@PATIENTID", patientID) };

            patientBillTable = SqlResult.ExecuteQuery(sqlSelect, sqlParameters);

            return patientBillTable;
        }

        // Get total price patient has not pay yet
        public static decimal GetPatientPriceNeedPay(int patientID)
        {
            decimal totalPrice = new decimal();

            DataTable patientBillTable = new DataTable();
            string sqlSelect = @"SELECT Sum(TOTALPRICE)
                                FROM    BILL
                                WHERE   (PATIENTID=@PATIENTID) AND STATE = 0";

            SqlParameter[] sqlParameters = { new SqlParameter("@PATIENTID", patientID) };

            decimal.TryParse(SqlResult.ExecuteScalar(sqlSelect, sqlParameters).ToString(), out totalPrice);
            return totalPrice;
        }
    }
}
