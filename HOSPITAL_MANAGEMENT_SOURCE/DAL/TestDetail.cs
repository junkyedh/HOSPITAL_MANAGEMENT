using HOSPITAL_MANAGEMENT_SOURCE.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using Npgsql;

namespace HOSPITAL_MANAGEMENT_SOURCE.DAL
{
    public class TestDetail
    {
        public int TestTypeID { get; set; }
        public int TCID { get; set; }
        public string Result { get; set; }

        public TestDetail() { }

        public TestDetail(int testTypeID, int tcID, string result)
        {
            this.TestTypeID = testTypeID;
            this.TCID = tcID;
            this.Result = result;
        }

        public static int InsertTestDetail(TestDetailDTO newTD)
        {
            string sqlInsert = @"INSERT INTO TESTDETAIL(TCID, TESTTYPEID, RESULT)
                                VALUES (@TCID, @TESTTYPEID, @RESULT)";
            NpgsqlParameter[] npgsqlParameters = {
                new NpgsqlParameter("@TCID", newTD.TCID),
                new NpgsqlParameter("@TESTTYPEID", newTD.TestTypeID),
                new NpgsqlParameter("@RESULT", newTD.Result)
            };
            return NpgSqlResult.ExecuteNonQuery(sqlInsert, npgsqlParameters);
        }

        public bool UpdateTestDetail()
        {
            return true;
        }

        public static int DeleteTestDetail(int tCID, int testTypeID)
        {
            string sqlDelete = @"DELETE FROM TESTDETAIL
                                WHERE TCID = @TCID AND TESTTYPEID = @TESTTYPEID";
            NpgsqlParameter[] npgsqlParameters = {
                new NpgsqlParameter("@TCID", tCID),
                new NpgsqlParameter("@TESTTYPEID", testTypeID)
            };
            return NpgSqlResult.ExecuteNonQuery(sqlDelete, npgsqlParameters);
        }

        public static int DeleteTestDetail(int tCID)
        {
            string sqlDelete = @"DELETE FROM TESTDETAIL
                                WHERE TCID = @TCID";
            NpgsqlParameter[] npgsqlParameters = {
                new NpgsqlParameter("@TCID", tCID)
            };
            return NpgSqlResult.ExecuteNonQuery(sqlDelete, npgsqlParameters);
        }

        public static DataTable GetListTestDetail(int tCID)
        {
            DataTable dtTD = new DataTable();
            string sqlSelect = @"SELECT TESTDETAIL.TCID, TESTDETAIL.TESTTYPEID, TESTDETAIL.RESULT, TESTTYPE.TYPENAME
                                 FROM TESTTYPE
                                 INNER JOIN TESTDETAIL ON TESTTYPE.TESTTYPEID = TESTDETAIL.TESTTYPEID
                                 WHERE TESTDETAIL.TCID = @TCID";
            NpgsqlParameter[] npgsqlParameters = {
                new NpgsqlParameter("@TCID", tCID)
            };
            dtTD = NpgSqlResult.ExecuteQuery(sqlSelect, npgsqlParameters);
            dtTD.Columns[0].ColumnName = "Mã phiếu xét nghiệm";
            dtTD.Columns[1].ColumnName = "Mã loại xét nghiệm";
            dtTD.Columns[2].ColumnName = "Kết quả";
            dtTD.Columns[3].ColumnName = "Tên loại xét nghiệm";
            return dtTD;
        }
    }
}
