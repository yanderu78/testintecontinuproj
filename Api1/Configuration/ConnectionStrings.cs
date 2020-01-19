using System.Data.SqlClient;

namespace GoodtimeApi.Configuration
{
    public class ConnectionStrings
    {
        public ConnectionStrings()
        {
            SqlCon = new SqlConnectionStringBuilder()
                {
                    DataSource = "localhost",
                    InitialCatalog = "goodtime",
                    UserID = "root",
                    Password = "root"
                }.ConnectionString;
        }

        public string SqlCon;

        public string ApiDb { get; set; }




        public string Api2Db { get; set; }
    }
}