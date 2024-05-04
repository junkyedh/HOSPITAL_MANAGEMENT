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
    public class Patient
    {
        public const int GENDER_MALE = 0;
        public const int GENDER_FEMALE = 1;
        public static DataTable patientTable;
        //private static Patient tempPatient;

        // Properties of Hospital class
        public int PatientID { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public DateTime BirthDay { get; set; }
        public int Gender { get; set; }
        public decimal ICN { get; set; }
        public String Profession { get; set; }
        public String Address { get; set; }
        public decimal Deposit { get; set; }
        public int State { get; set; }

        // Default constructor
        public Patient() { }

        // Constructor set all properties
        public Patient(int patientID, string firstName, string lastName, DateTime birthDay,
            int gender, decimal iCN, string profession, string address, decimal deposit, int state)
        {
            PatientID = patientID;
            FirstName = firstName;
            LastName = lastName;
            BirthDay = birthDay;
            Gender = gender;
            ICN = iCN;
            Profession = profession;
            Address = address;
            Deposit = deposit;
            State = state;
        }

        // Insert new patient
        public static int InsertPatient(Patient patient)
        {
            string sqlInsert = @"INSERT INTO PATIENT
                                (FIRSTNAME, LASTNAME, BIRTHDAY, GENDER, ICN, PROFESSION, ADDRESS, DEPOSIT, STATE)
                                VALUES 
                                (@FirstName, @LastName, @BirthDay, @Gender, @ICN, @Profession, @Address, @Deposit, @State)";

            SqlParameter[] sqlParameters = { new SqlParameter("@FirstName", patient.FirstName),
                                           new SqlParameter("@LastName", patient.LastName),
                                           new SqlParameter("@BirthDay", patient.BirthDay),
                                           new SqlParameter("@Gender", patient.Gender),
                                           new SqlParameter("@ICN", patient.ICN),
                                           new SqlParameter("@Profession", patient.Profession),
                                           new SqlParameter("@Address", patient.Address),
                                           new SqlParameter("@Deposit", patient.Deposit),
                                           new SqlParameter("@State", patient.State)};

            return SqlResult.ExecuteNonQuery(sqlInsert, sqlParameters);
        }

        // Update patien by patientid
        public static int UpdatePatient(Patient patient)
        {
            string sqlUpdate = @"UPDATE PATIENT
                                SET FIRSTNAME = @FirstName, LASTNAME = @LastName, BIRTHDAY = @BirthDay, GENDER = @Gender,
                                    ICN = @ICN, PROFESSION = @Profession, ADDRESS = @Address, DEPOSIT = @Deposit, STATE = @State
                                WHERE (PATIENTID = @PatientID)";

            SqlParameter[] sqlParameters = { new SqlParameter("@PatientID", patient.PatientID),
                                           new SqlParameter("@FirstName", patient.FirstName),
                                           new SqlParameter("@LastName", patient.LastName),
                                           new SqlParameter("@BirthDay", patient.BirthDay),
                                           new SqlParameter("@Gender", patient.Gender),
                                           new SqlParameter("@ICN", patient.ICN),
                                           new SqlParameter("@Profession", patient.Profession),
                                           new SqlParameter("@Address", patient.Address),
                                           new SqlParameter("@Deposit", patient.Deposit),
                                           new SqlParameter("@State", patient.State)};

            return SqlResult.ExecuteNonQuery(sqlUpdate, sqlParameters);
        }

        // Delete patient by patientid
        public static int DeletePatient(int patientID)
        {
            string sqlDelete = @"DELETE FROM PATIENT
                                WHERE (PATIENTID = @PatientID)";

            SqlParameter[] sqlParameters = { new SqlParameter("@PatientID", patientID) };

            return SqlResult.ExecuteNonQuery(sqlDelete, sqlParameters);
        }

        // Get list patient
        public static DataTable GetListPatient()
        {
            string sqlSelect = @"SELECT PATIENTID, FIRSTNAME, LASTNAME, BIRTHDAY, GENDER, ICN, PROFESSION, ADDRESS, DEPOSIT, STATE 
                                FROM PATIENT";

            patientTable = SqlResult.ExecuteQuery(sqlSelect);

            return patientTable;
        }
        public static DataTable GetListPatientID()
        {
            string sqlSelect = @"SELECT PATIENTID
                                FROM PATIENT";

            patientTable = SqlResult.ExecuteQuery(sqlSelect);

            return patientTable;
        }
        // Get patient by patientid
        public static Patient GetPatient(int patientID)
        {
            DataTable patientDataTable;
            Patient newPatient = new Patient();

            string sqlSelect = @"SELECT PATIENTID, FIRSTNAME, LASTNAME, BIRTHDAY, GENDER, ICN, PROFESSION, ADDRESS, DEPOSIT, STATE 
                                FROM PATIENT 
                                WHERE PATIENTID = @PatientID";

            SqlParameter[] sqlParameters = { new SqlParameter("@PatientID", patientID) };

            patientDataTable = SqlResult.ExecuteQuery(sqlSelect, sqlParameters);

            // If select query have row then set to new patient
            if (patientDataTable.Rows.Count > 0)
            {
                newPatient.PatientID = Convert.ToInt32(patientDataTable.Rows[0]["PATIENTID"].ToString());
                newPatient.FirstName = (string)patientDataTable.Rows[0]["FIRSTNAME"];
                newPatient.LastName = (string)patientDataTable.Rows[0]["LASTNAME"];
                newPatient.BirthDay = (DateTime)patientDataTable.Rows[0]["BIRTHDAY"];
                newPatient.Gender = (int)patientDataTable.Rows[0]["GENDER"];
                newPatient.ICN = (decimal)patientDataTable.Rows[0]["ICN"];
                newPatient.Profession = (string)patientDataTable.Rows[0]["PROFESSION"];
                newPatient.Address = (string)patientDataTable.Rows[0]["ADDRESS"];
                newPatient.Deposit = (decimal)patientDataTable.Rows[0]["DEPOSIT"];
                newPatient.State = (int)patientDataTable.Rows[0]["STATE"];
            }

            return newPatient;
        }
        public static Boolean IsPatientExist(int patientID)
        {
            DataTable dtPatient = new DataTable();

            string sqlSelect = @"SELECT PATIENTID, FIRSTNAME, LASTNAME, BIRTHDAY, GENDER, ICN, PROFESSION, ADDRESS, DEPOSIT, STATE 
                                FROM PATIENT 
                                WHERE PATIENTID = @PatientID";

            SqlParameter[] sqlParameters = { new SqlParameter("@PatientID", patientID) };

            dtPatient = SqlResult.ExecuteQuery(sqlSelect, sqlParameters);

            if (dtPatient.Rows.Count > 0)
                return true;
            return false;
        }





        public Boolean ChangePatientState()
        {
            return true;
        }






        public Boolean ChargeDeposit()
        {
            return true;
        }

        public List<Patient> GetResidentPatientList()
        {
            List<Patient> lstPatient = new List<Patient>();

            return lstPatient;
        }
    }
}
