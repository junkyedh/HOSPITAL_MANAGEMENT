using AutoMapper;
using HOSPITAL_MANAGEMENT_SOURCE.DTO;
using System;
using System.Data;
using Npgsql;
using System.Collections.Generic;

namespace HOSPITAL_MANAGEMENT_SOURCE.DAL
{
    public class Prescription
    {
        public int PrescriptionID { get; set; }
        public int StaffID { get; set; }
        public int PatientID { get; set; }
        public DateTime Date { get; set; }

        public Prescription() { }

        public Prescription(int prescriptionID, int staffID, int patientID, DateTime date)
        {
            PrescriptionID = prescriptionID;
            StaffID = staffID;
            PatientID = patientID;
            Date = date;
        }

        public static int InsertPrescription(PrescriptionDTO newP)
        {
            string sqlInsert = @"INSERT INTO PRESCRIPTION(STAFFID, PATIENTID, DATE)
                                VALUES (@StaffID, @PatientID, @Date)";

            NpgsqlParameter[] npgsqlParameters = {
                new NpgsqlParameter("@StaffID", newP.StaffID),
                new NpgsqlParameter("@PatientID", newP.PatientID),
                new NpgsqlParameter("@Date", newP.Date)
            };

            return NpgSqlResult.ExecuteNonQuery(sqlInsert, npgsqlParameters);
        }

        public static int UpdatePrescription(PrescriptionDTO updateP)
        {
            string sqlUpdate = @"UPDATE PRESCRIPTION
                                SET PATIENTID = @PatientID, DATE = @Date
                                WHERE PRESCRIPTIONID = @PrescriptionID";

            NpgsqlParameter[] npgsqlParameters = {
                new NpgsqlParameter("@PrescriptionID", updateP.PrescriptionID),
                new NpgsqlParameter("@PatientID", updateP.PatientID),
                new NpgsqlParameter("@Date", updateP.Date)
            };

            return NpgSqlResult.ExecuteNonQuery(sqlUpdate, npgsqlParameters);
        }

        public static int DeletePrescription(int prescriptionID)
        {
            string sqlDelete = @"DELETE FROM PRESCRIPTION
                                WHERE PRESCRIPTIONID = @PrescriptionID";

            NpgsqlParameter[] npgsqlParameters = {
                new NpgsqlParameter("@PrescriptionID", prescriptionID)
            };

            return NpgSqlResult.ExecuteNonQuery(sqlDelete, npgsqlParameters);
        }

        public static List<PrescriptionDTO> GetListPrescription()
        {
            List<PrescriptionDTO> prescriptionList = new List<PrescriptionDTO>();

            string sqlSelect = @"SELECT PRESCRIPTIONID, STAFFID, PATIENTID, DATE
                                FROM PRESCRIPTION";

            DataTable dataTable = NpgSqlResult.ExecuteQuery(sqlSelect);

            foreach (DataRow row in dataTable.Rows)
            {
                PrescriptionDTO prescription = new PrescriptionDTO
                {
                    PrescriptionID = Convert.ToInt32(row["PRESCRIPTIONID"]),
                    StaffID = Convert.ToInt32(row["STAFFID"]),
                    PatientID = Convert.ToInt32(row["PATIENTID"]),
                    Date = Convert.ToDateTime(row["DATE"])
                };

                prescriptionList.Add(prescription);
            }

            return prescriptionList;
        }

        public static PrescriptionDTO GetPrescription(int prescriptionID)
        {
            PrescriptionDTO newPrescription = new PrescriptionDTO();

            string sqlSelect = @"SELECT PRESCRIPTIONID, STAFFID, PATIENTID, DATE
                                FROM PRESCRIPTION
                                WHERE PRESCRIPTIONID = @PrescriptionID";

            NpgsqlParameter[] npgsqlParameters = {
                new NpgsqlParameter("@PrescriptionID", prescriptionID)
            };

            DataTable dataTable = NpgSqlResult.ExecuteQuery(sqlSelect, npgsqlParameters);

            if (dataTable.Rows.Count > 0)
            {
                newPrescription.PrescriptionID = Convert.ToInt32(dataTable.Rows[0]["PRESCRIPTIONID"]);
                newPrescription.StaffID = Convert.ToInt32(dataTable.Rows[0]["STAFFID"]);
                newPrescription.PatientID = Convert.ToInt32(dataTable.Rows[0]["PATIENTID"]);
                newPrescription.Date = Convert.ToDateTime(dataTable.Rows[0]["DATE"]);
            }

            return newPrescription;
        }

        public static int GetPrescriptionInsertedID()
        {
            string sqlSelect = @"SELECT CURRVAL(pg_get_serial_sequence('PRESCRIPTION', 'PRESCRIPTIONID')) AS last_value";

            object ob = NpgSqlResult.ExecuteScalar(sqlSelect);

            return Convert.ToInt32(ob);
        }

        public static int GetPatientIDInPrescription(int prescriptionID)
        {
            string sqlSelect = @"SELECT PATIENTID
                                FROM PRESCRIPTION
                                WHERE PRESCRIPTIONID = @PrescriptionID";

            NpgsqlParameter[] npgsqlParameters = {
                new NpgsqlParameter("@PrescriptionID", prescriptionID)
            };

            object ob = NpgSqlResult.ExecuteScalar(sqlSelect, npgsqlParameters);

            return Convert.ToInt32(ob);
        }
    }
}
