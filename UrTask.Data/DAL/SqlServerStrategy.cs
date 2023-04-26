using System.Data;
using System.Data.SqlClient;
using UrTask.Shared.Infrastructure.Settings;

namespace UrTask.Data.DAL
{
    public class SqlServerStrategy : IDbStrategy
    {
        public IDbConnection GetConnection()
        {
           var x= AppSettings.DataBaseSettings.ConnectionString;
            var cn = new SqlConnection(AppSettings.DataBaseSettings.ConnectionString);
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            return cn;
        }
        //public IDbConnection GetConnection(string connectionString)
        //{
        //    return new SqlConnection(connectionString);
        //}
    }

}
