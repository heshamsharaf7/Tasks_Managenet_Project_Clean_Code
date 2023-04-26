using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using UrTask.Data.CustomException;
using UrTask.Data.DAL;
using UrTask.Data.DRY.Models;
using UrTask.Data.Extensions;
using UrTask.Domain.Entities;
using UrTask.Domain.IRepositires;

namespace UrTask.Data.Repository
{
    public class ContactRepImp : IContactRepo
    {
        internal const string tableName = DRY.SchemaDB.GetSchemaName + "contactTb";
        private readonly IDbStrategy db;
        private Type type = typeof(TaskRepImp);
        public ContactRepImp(IDbStrategy _dbStrategy)
        {
            db = _dbStrategy ?? throw new DALFundsException(nameof(_dbStrategy));
        }
        public Tuple<bool, object> Add(ContactMdl entity)
        {
            try
            {
                using (IDbConnection cn = db.GetConnection())
                {
                    var maxId = cn.GetMax<MaxId>(tableName);
                    int id = maxId.id + 1;
                    var dp = new DynamicParameters();
                    dp.Add("@id", id);
                    dp.Add("@name", entity.Name);
                    dp.Add("@phoneNumber", entity.PhoneNumber);
                    dp.Add("@message",entity.Message );
                    dp.Add("@enterdDate", DateTime.Now);
                    


                    int result = cn.Insert(tableName
                        , "id, name, phoneNumber, message, enterdDate"
                        , "@id, @name, @phoneNumber, @message, @enterdDate"
                        , dp);
                    return Tuple.Create(result > 0, (object)result);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("{Repo} Add method error :" + type, ex);
            }
        }

        public IEnumerable<ContactMdl> GetAll()
        {
            try
            {
                using (IDbConnection cn = db.GetConnection())
                {
                    return cn.GetAll<ContactMdl>(tableName);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("{Repo} All method error :" + type, ex);
            }
        }
    }
}
