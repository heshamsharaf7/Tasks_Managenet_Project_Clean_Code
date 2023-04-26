using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using UrTask.Data.CustomException;
using UrTask.Data.DAL;
using UrTask.Data.Extensions;
using UrTask.Domain.Entities;
using UrTask.Domain.IRepositires;

namespace UrTask.Data.Repository
{
public    class TaskStatuesRepImp : ITaskStatuesRepo
    {
        internal const string tableName = DRY.SchemaDB.GetSchemaName + "taskStatuesTb";
        private readonly IDbStrategy db;
        private Type type = typeof(TaskStatuesRepImp);
        public TaskStatuesRepImp(IDbStrategy _dbStrategy)
        {
            db = _dbStrategy ?? throw new DALFundsException(nameof(_dbStrategy));
        }

        public Tuple<bool, object> Add(TaskStatuesMdl entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int entity_id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TaskStatuesMdl> GetAll()
        {
            try
            {
                using (IDbConnection cn = db.GetConnection())
                {
                    return cn.GetAll<TaskStatuesMdl>(tableName);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("{Repo} All method error :" + type, ex);
            }
        }

        public TaskStatuesMdl GetById(object id)
        {
            throw new NotImplementedException();
        }

        public bool Update(TaskStatuesMdl entity)
        {
            throw new NotImplementedException();
        }
    }
}
