using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;
using Dapper;

namespace UrTask.Data.Extensions
{
    public static class CRUDExtensions
    {
        public static int Insert(this IDbConnection cnn, string tableName, string tableColumns, string values, object param, IDbTransaction transaction = null)
        {
            StringBuilder query = new StringBuilder();
            query.Append("INSERT INTO ");
            query.Append(tableName);
            query.Append(" (");
            query.Append(tableColumns);
            query.Append(") VALUES (");
            query.Append(values);
            query.Append(")");
            return cnn.Execute(query.ToString(), param);
        }
        public static T InsertScalar<T>(this IDbConnection cnn, string tableName, string tableColumns, string values, object param, IDbTransaction transaction = null)
        {
            StringBuilder query = new StringBuilder();
            query.Append("INSERT INTO ");
            query.Append(tableName);
            query.Append(" (");
            query.Append(tableColumns);
            query.Append(") VALUES (");
            query.Append(values);
            query.Append("); Select Cast (Scope_Identity() as int)");
            return cnn.ExecuteScalar<T>(query.ToString(), param);
        }
        public static int Update(this IDbConnection cnn, string tableName, string tableColumnsWithValues, string where, object param, IDbTransaction transaction = null)
        {
            StringBuilder query = new StringBuilder();
            query.Append("Update ");
            query.Append(tableName);
            query.Append(" set ");
            query.Append(tableColumnsWithValues);
            query.Append(" WHERE ");
            query.Append(where);
            //var query = "Update " + tableName + " set "+ tableColumns +"  WHERE "+ where;
            return cnn.Execute(query.ToString(), param);
        }
        public static int Delete(this IDbConnection cnn, string tableName, string where, object param, IDbTransaction transaction = null)
        {
            var query = "Delete FROM " + tableName + "  WHERE " + where;
            return cnn.Execute(query, param);
        }
        public static int DeleteAll(this IDbConnection cnn, string tableName, IDbTransaction transaction = null)
        {
            var query = "Delete FROM " + tableName;
            return cnn.Execute(query, null);
        }

        public static IEnumerable<T> GetAll<T>(this IDbConnection cnn, string tableName, string tableColumns = "*", IDbTransaction transaction = null, int? commandTimeout = default(int?), CommandType? commandType = default(CommandType?))
        {
            //var query = "SELECT "+ tableColumns+" FROM " + tableName;
            StringBuilder query = new StringBuilder();
            query.Append("SELECT ");
            query.Append(tableColumns);
            query.Append(" FROM ");
            query.Append(tableName);
            return cnn.Query<T>(query.ToString(), commandType: CommandType.Text);
        }
        public static IEnumerable<T> GetAllBy<T>(this IDbConnection cnn, string tableName, string where, object param, string tableColumns = "*", IDbTransaction transaction = null, int? commandTimeout = default(int?), CommandType? commandType = default(CommandType?))
        {
            StringBuilder query = new StringBuilder();
            query.Append("SELECT ");
            query.Append(tableColumns);
            query.Append(" FROM ");
            query.Append(tableName);
            query.Append(" WHERE ");
            query.Append(where);
            return cnn.Query<T>(query.ToString(), param, commandType: CommandType.Text);
        }
        public static T GetSingleBy<T>(this IDbConnection cnn, string tableName, string where, object param, string tableColumns = "*", IDbTransaction transaction = null, int? commandTimeout = default(int?), CommandType? commandType = default(CommandType?))
        {
            //return cn.Query<ManagerTitleMdl>("SELECT * FROM " + tableName + " WHERE id=@ID", new { ID = id }).SingleOrDefault();
            StringBuilder query = new StringBuilder();
            query.Append("SELECT ");
            query.Append(tableColumns);
            query.Append(" FROM ");
            query.Append(tableName);
            query.Append(" WHERE ");
            query.Append(where);
            return cnn.Query<T>(query.ToString(), param, commandType: CommandType.Text).SingleOrDefault();
        }
        public static T GetFirstBy<T>(this IDbConnection cnn, string tableName, string where, object param, string tableColumns = "*", IDbTransaction transaction = null, int? commandTimeout = default(int?), CommandType? commandType = default(CommandType?))
        {
            //return cn.QueryFirst<ManagerTitle>("SELECT * FROM "+ tableName+" WHERE id=@id", new { id = id });
            StringBuilder query = new StringBuilder();
            query.Append("SELECT ");
            query.Append(tableColumns);
            query.Append(" FROM ");
            query.Append(tableName);
            query.Append(" WHERE ");
            query.Append(where);
            return cnn.QueryFirst<T>(query.ToString(), param, commandType: CommandType.Text);
        }
        public static T GetMax<T>(this IDbConnection cnn, string tableName, string nameColumn = "id", IDbTransaction transaction = null, int? commandTimeout = default(int?), CommandType? commandType = default(CommandType?))
        {
            //return cn.Query<MaxId>("select MAX(id) AS id from "+tableName);
            StringBuilder query = new StringBuilder();
            query.Append("SELECT MAX(");
            query.Append(nameColumn);
            query.Append(") AS id FROM ");
            query.Append(tableName);
            return cnn.Query<T>(query.ToString(), commandType: CommandType.Text).SingleOrDefault();
        }

        public static T GetMaxBy<T>(this IDbConnection cnn, string tableName, string where, object param, string nameColumn = "id", IDbTransaction transaction = null, int? commandTimeout = default(int?), CommandType? commandType = default(CommandType?))
        {
            StringBuilder query = new StringBuilder();
            query.Append("SELECT MAX(");
            query.Append(nameColumn);
            query.Append(") AS id FROM ");
            query.Append(tableName);
            query.Append(" WHERE ");
            query.Append(where);
            return cnn.Query<T>(query.ToString(), param, commandType: CommandType.Text).SingleOrDefault();
        }

        public static IEnumerable<T> CustomSqlQuery<T>(this IDbConnection cnn, string sql, CommandType? commandType = default(CommandType?))
        {
            
            return cnn.Query<T>(sql.ToString(), commandType: CommandType.Text);
        }
    }

}
