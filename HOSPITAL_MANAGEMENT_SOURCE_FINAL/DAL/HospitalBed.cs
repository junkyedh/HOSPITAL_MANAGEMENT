using HOSPITAL_MANAGEMENT_SOURCE.DTO;
using Npgsql;
using System;
using System.Data;

namespace HOSPITAL_MANAGEMENT_SOURCE.DAL
{
    public class HospitalBed
    {
        public int BedID { get; set; }
        public int Patient { get; set; }
        public int State { get; set; }

        public HospitalBed() { }

        public HospitalBed(int bedID, int patient, int state)
        {
            this.BedID = bedID;
            this.Patient = patient;
            this.State = state;
        }

        public static int InsertHospitalBed()
        {
            HospitalBed newHB = new HospitalBed();
            String sqlInsert = @"INSERT INTO ""HOSPITALBED""(PATIENT,STATE)
                                VALUES        (@PATIENT,@STATE)";

            NpgsqlParameter[] npgsqlParameters =
            {
                new NpgsqlParameter("@PATIENT", newHB.Patient),
                new NpgsqlParameter("@STATE", newHB.State)
            };

            return NpgSqlResult.ExecuteNonQuery(sqlInsert, npgsqlParameters);
        }

        public static int UpdateHospitalBed(HospitalBed updateHB)
        {
            string sqlUpdate = @"UPDATE       ""HOSPITALBED""
                                SET           PATIENT = @PATIENT, STATE = @STATE
                                WHERE         BEDID=@BEDID";

            NpgsqlParameter[] npgsqlParameters =
            {
                new NpgsqlParameter("@BEDID", updateHB.BedID),
                new NpgsqlParameter("@PATIENT", updateHB.Patient),
                new NpgsqlParameter("@STATE", updateHB.State)
            };

            return NpgSqlResult.ExecuteNonQuery(sqlUpdate, npgsqlParameters);
        }

        public static int DeleteHospitalBed(int bedID)
        {
            string sqlDelete = @"DELETE FROM ""HOSPITALBED""
                                WHERE (BEDID = @BEDID)";

            NpgsqlParameter[] npgsqlParameters = { new NpgsqlParameter("@BEDID", bedID) };

            return NpgSqlResult.ExecuteNonQuery(sqlDelete, npgsqlParameters);
        }

        public Boolean ChangeHospitalState()
        {
            return true;
        }

        public static DataTable GetListHospitalBed()
        {
            DataTable dtHB = new DataTable();
            string sqlSelect = @"SELECT        BEDID,PATIENT, h.STATE, COALESCE(p.LASTNAME || ' ' || p.FIRSTNAME) AS ""PATIENT NAME""
                                FROM            ""HOSPITALBED"" h left join ""PATIENT"" p on h.PATIENT = p.PATIENTID";

            dtHB = NpgSqlResult.ExecuteQuery(sqlSelect);

            return dtHB;
        }

        public static HospitalBed GetHospitalBed(int bedID)
        {
            HospitalBed hB = new HospitalBed();
            int tempInterger;
            string sqlSelect = @"SELECT        BEDID,PATIENT, STATE
                                FROM            ""HOSPITALBED""
                                WHERE          (BEDID=@BEDID)";

            NpgsqlParameter[] npgsqlParameters = { new NpgsqlParameter("@BEDID", bedID) };

            DataTable dataTable = NpgSqlResult.ExecuteQuery(sqlSelect, npgsqlParameters);

            int.TryParse(dataTable.Rows[0][0].ToString(), out tempInterger);
            hB.BedID = tempInterger;
            hB.Patient = int.Parse(dataTable.Rows[0][1].ToString());
            hB.State = int.Parse(dataTable.Rows[0][2].ToString());

            return hB;
        }

        public static HospitalBedDTO GetHospitalBed(String patient)
        {
            HospitalBedDTO hB = new HospitalBedDTO();
            string sqlSelect = @"SELECT        BEDID, PATIENT, STATE
                                FROM            ""HOSPITALBED""
                                WHERE          (PATIENT=@PATIENT)";

            NpgsqlParameter[] npgsqlParameters = { new NpgsqlParameter("@PATIENT", int.Parse(patient)) };

            DataTable dataTable = NpgSqlResult.ExecuteQuery(sqlSelect, npgsqlParameters);

            if (dataTable.Rows.Count > 0)
            {
                hB.BedID = Convert.ToInt32(dataTable.Rows[0][0]);
                hB.Patient = Convert.ToInt32(dataTable.Rows[0][1].ToString());
                hB.State = int.Parse(dataTable.Rows[0][2].ToString());
            }

            return hB;
        }

        public static Boolean CheckPatient(int patientID)
        {
            HospitalBedDTO hB = new HospitalBedDTO();
            string sqlSelect = @"SELECT        PATIENT, STATE, BEDID
                                FROM            ""HOSPITALBED""
                                WHERE          (PATIENT=@PATIENT)";

            NpgsqlParameter[] npgsqlParameters = { new NpgsqlParameter("@PATIENT", patientID) };

            DataTable dataTable = NpgSqlResult.ExecuteQuery(sqlSelect, npgsqlParameters);

            return dataTable.Rows.Count > 0;
        }

        public static Boolean ConfirmPatient(int patientID)
        {
            if (CheckPatient(patientID))
                return false;
            else
                return true;
        }

        public HospitalBedDTO ToDTO ()
        {
            return new HospitalBedDTO
            {
                    BedID = this.BedID,
                    Patient = this.Patient,
                    State = this.State
            };
        }
    }
}
