using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HOSPITAL_MANAGEMENT_SOURCE.DTO
{
    internal class Constant
    {
        public string PostgresConnection = "Host=ep-jolly-cherry-a5ub2x8e.us-east-2.aws.neon.tech;Username=hospital_management_owner;Password=sIFZ6kcA0iTj;Database=hospital_management";
        private string host = "localhost";
        private string port = "5432";
        private string username = "postgres";
        private string password = "postgres"; 
        private string dbName = "hospital_management"; 
        public Constant()
        {
            Ini MyIni = new Ini("config.ini");

            if (!MyIni.KeyExists("DBHOST", "HospitalManagement"))
            {
                MyIni.Write("DBHOST", "ep-jolly-cherry-a5ub2x8e.us-east-2.aws.neon.tech", "HospitalManagement");
            }
            if (!MyIni.KeyExists("DBPORT", "HospitalManagement"))
            {
                MyIni.Write("DBPORT", "5432", "HospitalManagement");
            }
            if (!MyIni.KeyExists("DBUSER", "HospitalManagement"))
            {
                MyIni.Write("DBUSER", "hospital_management_owner", "HospitalManagement");
            }
            if (!MyIni.KeyExists("DBPASS", "HospitalManagement"))
            {
                MyIni.Write("DBPASS", "sIFZ6kcA0iTj", "HospitalManagement");
            }
            if (!MyIni.KeyExists("DBNAME", "HospitalManagement"))
            {
                MyIni.Write("DBNAME", "hospital_management", "HospitalManagement");
            }

            this.host = MyIni.Read("DBHOST", "HospitalManagement");
            this.port = MyIni.Read("DBPORT", "HospitalManagement");
            this.username = MyIni.Read("DBUSER", "HospitalManagement");
            this.password = MyIni.Read("DBPASS", "HospitalManagement");
            this.dbName = MyIni.Read("DBNAME", "HospitalManagement");

            this.PostgresConnection = "Host=" + host + ";Port=" + port + ";Username=" + username + ";Password=" + password + ";Database=" + dbName;
        }
    }
}
