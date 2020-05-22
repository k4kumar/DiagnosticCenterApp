using System.Data.SqlClient;
using System.Web.Configuration;

namespace ProjectApp.DAL.Gateway
{
    public class Gateway
    {
        public SqlConnection Connection { get; set; }
        public SqlCommand Command { get; set; }
        public string Query { get; set; }
        public SqlDataReader Reader { get; set; }


        private string connectionString = WebConfigurationManager.ConnectionStrings["ProjectDBConnectionstring"].ConnectionString;

        public Gateway()
        {
            Connection = new SqlConnection(connectionString);
        }

    }
}