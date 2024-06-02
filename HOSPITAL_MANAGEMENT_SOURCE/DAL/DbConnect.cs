using HOSPITAL_MANAGEMENT_SOURCE.DTO;
using Npgsql;

namespace HOSPITAL_MANAGEMENT_SOURCE.DAL
{
    class DbConnect
    {
        private string strConn;

        public string StrConn
        {
            get { return strConn; }
            set { strConn = value; }
        }


        public NpgsqlConnection GetNpgsqlConnection()
        {
            return new NpgsqlConnection(StrConn);
        }
    }
}
