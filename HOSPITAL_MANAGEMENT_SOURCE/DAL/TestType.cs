using HOSPITAL_MANAGEMENT_SOURCE.DTO;
using System.Data;
using Npgsql;
using System;

namespace HOSPITAL_MANAGEMENT_SOURCE.DAL
{
    public class TestType
    {
        public int TestTypeID { get; set; }
        public string TestName { get; set; }

        public TestType() { }
        public TestType(int testTypeID, string testName)
        {
            this.TestTypeID = testTypeID;
            this.TestName = testName;
        }

        public static DataTable GetListTestType()
        {
            DataTable dtT = new DataTable();
            string sqlSelect = @"SELECT TESTTYPEID, TYPENAME FROM ""TESTTYPE""";
            dtT = NpgSqlResult.ExecuteQuery(sqlSelect);
            // dtT.Columns[0].ColumnName = "Mã loại xét nghiệm";
            // dtT.Columns[1].ColumnName = "Tên loại xét nghiệm";
            return dtT;
        }

        public static TestTypeDTO GetTestType(int testTypeID)
        {
            TestTypeDTO newTestType = new TestTypeDTO();
            string sqlSelect = @"SELECT TESTTYPEID, TYPENAME FROM ""TESTTYPE"" WHERE TESTTYPEID = @TESTTYPEID";
            NpgsqlParameter[] npgsqlParameters = { new NpgsqlParameter("@TESTTYPEID", testTypeID) };
            DataTable dataTable = NpgSqlResult.ExecuteQuery(sqlSelect, npgsqlParameters);

            if (dataTable.Rows.Count > 0)
            {
                newTestType.TestTypeID = Convert.ToInt32(dataTable.Rows[0][0]);
                newTestType.TestName = dataTable.Rows[0][1].ToString();
            }

            return newTestType;
        }
    }
}
