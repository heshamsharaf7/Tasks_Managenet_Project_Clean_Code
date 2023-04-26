using System.Data;

namespace UrTask.Data.DAL
{
    public interface IDbStrategy
    {
        IDbConnection GetConnection();
        //IDbConnection GetConnection(string connectionString);
    }
}
