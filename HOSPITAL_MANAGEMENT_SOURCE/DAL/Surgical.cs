using System;
using System.Data;
using Npgsql;

namespace HOSPITAL_MANAGEMENT_SOURCE.DAL
{
    public class Surgical
    {
        public int SurgicalID { get; set; }
        public int PatientID { get; set; }
        public DateTime Date { get; set; }
        public String Description { get; set; }
        public int State { get; set; }
        public string PatientName { get; set; }

        public Surgical() { }

        public static int InsertSurgical(Surgical newSurgical)
        {
            String sqlInsert = @"INSERT INTO ""SURGICAL""(PATIENTID, DATE, DESCRIPTION, STATE)
                                VALUES        (@PATIENTID,@DATE,@DESCRIPTION,@STATE)";
            NpgsqlParameter[] npgsqlParameters = {
                new NpgsqlParameter("@PATIENTID", newSurgical.PatientID),
                new NpgsqlParameter("@DATE", newSurgical.Date),
                new NpgsqlParameter("@DESCRIPTION", newSurgical.Description ),
                new NpgsqlParameter("@STATE",newSurgical.State)
            };
            return NpgSqlResult.ExecuteNonQuery(sqlInsert, npgsqlParameters);
        }

        public static int UpdateSurgical(Surgical updateSurgical)
        {
            string sqlUpdate = @"UPDATE       ""SURGICAL""
                                SET                DATE =@DATE, DESCRIPTION =@DESCRIPTION, STATE =@STATE
                                WHERE         SURGICALID=@SURGICALID ";
            NpgsqlParameter[] npgsqlParameters = {
                new NpgsqlParameter("@SURGICALID", updateSurgical.SurgicalID),
                new NpgsqlParameter("@DATE", updateSurgical.Date),
                new NpgsqlParameter("@DESCRIPTION", updateSurgical.Description),
                new NpgsqlParameter("@STATE", updateSurgical.State)
            };
            return NpgSqlResult.ExecuteNonQuery(sqlUpdate, npgsqlParameters);
        }

        public static int DeleteSurgical(int surgicalID)
        {
            string sqlDelete = @"DELETE FROM ""SURGICAL""
                                WHERE        (SURGICALID=@SURGICALID)";
            NpgsqlParameter[] npgsqlParameters = { new NpgsqlParameter("@SURGICALID", surgicalID) };
            return NpgSqlResult.ExecuteNonQuery(sqlDelete, npgsqlParameters);
        }

        public static DataTable GetListSurgical()
        {
            string sqlSelect = @"SELECT        SURGICALID, s.PATIENTID, DATE, DESCRIPTION, s.STATE, p.LASTNAME || ' ' || p.FIRSTNAME as PATIENT_NAME
                                FROM            ""SURGICAL"" s join ""PATIENT"" p on s.PATIENTID = p.PATIENTID";
            return NpgSqlResult.ExecuteQuery(sqlSelect);
        }

        public static Surgical GetSurgical(int surgicalID)
        {
            Surgical newSurgical = new Surgical();
            string sqlSelect = @"SELECT        SURGICALID, PATIENTID, DATE, DESCRIPTION, STATE
                                FROM            ""SURGICAL""
                                WHERE        SURGICALID=@SURGICALID";
            NpgsqlParameter[] npgsqlParameters = { new NpgsqlParameter("@SURGICALID", surgicalID) };
            DataTable dataTable = NpgSqlResult.ExecuteQuery(sqlSelect, npgsqlParameters);
            if (dataTable.Rows.Count > 0)
            {
                newSurgical.SurgicalID = Convert.ToInt32(dataTable.Rows[0]["SURGICALID"]);
                newSurgical.PatientID = Convert.ToInt32(dataTable.Rows[0]["PATIENTID"]);
                newSurgical.Date = Convert.ToDateTime(dataTable.Rows[0]["DATE"]);
                newSurgical.Description = Convert.ToString(dataTable.Rows[0]["DESCRIPTION"]);
                newSurgical.State = Convert.ToInt32(dataTable.Rows[0]["STATE"]);
                newSurgical.PatientName = Convert.ToString(dataTable.Rows[0]["PATIENT_NAME"]);
            }
            return newSurgical;
        }


        public static int GetCurrentIdentity()
        {
            string sqlSelect = @"SELECT last_value FROM SURGICAL_SURGICALID_seq";
            object ob = NpgSqlResult.ExecuteScalar(sqlSelect);
            return Convert.ToInt32(ob);
        }
    }
}
