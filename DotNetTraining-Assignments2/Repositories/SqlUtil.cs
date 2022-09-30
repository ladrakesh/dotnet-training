using System.Data;
using System.Data.SqlClient;

namespace DotNetTraining_Assignments2.Repositories
{

    public class SqlUtil
    {
        private readonly IConfiguration _config;
        private SqlConnection sqlConnection;
        public SqlUtil(IConfiguration config)
        {
            _config = config;
            sqlConnection = new SqlConnection(GetConnectionString());
        }

        private string GetConnectionString()
        {
            return _config.GetValue<string>("ConnectionStrings:localserver");
        }

        public SqlConnection GetSqlConnection()
        {
            sqlConnection.ConnectionString = GetConnectionString();
            if (sqlConnection.State != ConnectionState.Open)
            {
                sqlConnection.Open();
            }

            return sqlConnection;
        }
       
    }
}
