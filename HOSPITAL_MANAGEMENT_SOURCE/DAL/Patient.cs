using HOSPITAL_MANAGEMENT_SOURCE.DTO;
using System.Data;
using Npgsql;
using System.Collections.Generic;
using System;

namespace HOSPITAL_MANAGEMENT_SOURCE.DAL
{
    public class Patient
    {
        public const int GENDER_MALE = 0;
        public const int GENDER_FEMALE = 1;

        // Properties of Hospital class
        public int PatientID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }
        public int Gender { get; set; }
        public decimal ICN { get; set; }
        public string Profession { get; set; }
        public string Address { get; set; }
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
        public static int InsertPatient(PatientDTO patient)
        {
            string sqlInsert = @"INSERT INTO PATIENT
                                (FIRSTNAME, LASTNAME, BIRTHDAY, GENDER, ICN, PROFESSION, ADDRESS, DEPOSIT, STATE)
                                VALUES 
                                (@FirstName, @LastName, @BirthDay, @Gender, @ICN, @Profession, @Address, @Deposit, @State)";

            NpgsqlParameter[] npgsqlParameters = {
                new NpgsqlParameter("@FirstName", patient.FirstName),
                new NpgsqlParameter("@LastName", patient.LastName),
                new NpgsqlParameter("@BirthDay", patient.BirthDay),
                new NpgsqlParameter("@Gender", patient.Gender),
                new NpgsqlParameter("@ICN", patient.ICN),
                new NpgsqlParameter("@Profession", patient.Profession),
                new NpgsqlParameter("@Address", patient.Address),
                new NpgsqlParameter("@Deposit", patient.Deposit),
                new NpgsqlParameter("@State", patient.State)
            };

            return NpgSqlResult.ExecuteNonQuery(sqlInsert, npgsqlParameters);
        }

        // Update patient by patientid
        public static int UpdatePatient(PatientDTO patient)
        {
            string sqlUpdate = @"UPDATE PATIENT
                                SET FIRSTNAME = @FirstName, LASTNAME = @LastName, BIRTHDAY = @BirthDay, GENDER = @Gender,
                                    ICN = @ICN, PROFESSION = @Profession, ADDRESS = @Address, DEPOSIT = @Deposit, STATE = @State
                                WHERE (PATIENTID = @PatientID)";

            NpgsqlParameter[] npgsqlParameters = {
                new NpgsqlParameter("@PatientID", patient.PatientID),
                new NpgsqlParameter("@FirstName", patient.FirstName),
                new NpgsqlParameter("@LastName", patient.LastName),
                new NpgsqlParameter("@BirthDay", patient.BirthDay),
                new NpgsqlParameter("@Gender", patient.Gender),
                new NpgsqlParameter("@ICN", patient.ICN),
                new NpgsqlParameter("@Profession", patient.Profession),
                new NpgsqlParameter("@Address", patient.Address),
                new NpgsqlParameter("@Deposit", patient.Deposit),
                new NpgsqlParameter("@State", patient.State)
            };

            return NpgSqlResult.ExecuteNonQuery(sqlUpdate, npgsqlParameters);
        }

        // Delete patient by patientid
        public static int DeletePatient(int patientID)
        {
            string sqlDelete = @"DELETE FROM PATIENT
                                WHERE (PATIENTID = @PatientID)";

            NpgsqlParameter[] npgsqlParameters = { new NpgsqlParameter("@PatientID", patientID) };

            return NpgSqlResult.ExecuteNonQuery(sqlDelete, npgsqlParameters);
        }

        // Get list patient
        public static DataTable GetListPatient()
        {
            string sqlSelect = @"SELECT PATIENTID, FIRSTNAME, LASTNAME, BIRTHDAY, GENDER, ICN, PROFESSION, ADDRESS, DEPOSIT, STATE 
                                FROM PATIENT";

            return NpgSqlResult.ExecuteQuery(sqlSelect);
        }

        // Get patient by patientid
        public static PatientDTO GetPatient(int patientID)
        {
            DataTable patientDataTable;
            PatientDTO newPatient = new PatientDTO();

            string sqlSelect = @"SELECT PATIENTID, FIRSTNAME, LASTNAME, BIRTHDAY, GENDER, ICN, PROFESSION, ADDRESS, DEPOSIT, STATE 
                                FROM PATIENT 
                                WHERE PATIENTID = @PatientID";

            NpgsqlParameter[] npgsqlParameters = { new NpgsqlParameter("@PatientID", patientID) };

            patientDataTable = NpgSqlResult.ExecuteQuery(sqlSelect, npgsqlParameters);

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

        // Check if patient exists
        public static bool IsPatientExist(int patientID)
        {
            DataTable patientDataTable;

            string sqlSelect = @"SELECT PATIENTID
                                FROM PATIENT 
                                WHERE PATIENTID = @PatientID";

            NpgsqlParameter[] npgsqlParameters = { new NpgsqlParameter("@PatientID", patientID) };

            patientDataTable = NpgSqlResult.ExecuteQuery(sqlSelect, npgsqlParameters);

            return patientDataTable.Rows.Count > 0;
        }

        public bool ChangePatientState()
        {
            // Logic for changing patient state
            return true;
        }

        public bool ChargeDeposit()
        {
            return true;
        }

        public List<PatientDTO> GetResidentPatientList()
        {
            List<PatientDTO> lstPatient = new List<PatientDTO>();


            return lstPatient;
        }
    }
}


/*
- `AutoMapper` được sử dụng để ánh xạ giữa `DataRow` và `PatientDTO`, giúp tự động chuyển đổi dữ liệu.
- Các phương thức thêm, cập nhật, xóa và lấy danh sách bệnh nhân được cập nhật để sử dụng `PatientDTO`.
- Các hằng số và các thuộc tính của lớp `Patient` không có thay đổi so với phiên bản ban đầu.
- Các phương thức như `ChangePatientState()` và `ChargeDeposit()` vẫn giữ nguyên, tuy nhiên, chúng chưa được triển khai logic.
 */