using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using UrTask.Data.CustomException;
using UrTask.Data.DAL;
using UrTask.Data.DRY.Models;
using UrTask.Data.Extensions;
using UrTask.Domain.Entities;
using UrTask.Domain.IRepositires;

namespace UrTask.Data.Repository
{
   public class TaskFileRepImp : ITaskFileRepo
    {
        internal const string tableName = DRY.SchemaDB.GetSchemaName + "taskFilesTb";
        private readonly IDbStrategy db;
        private Type type = typeof(TaskFileRepImp);
        public TaskFileRepImp(IDbStrategy _dbStrategy)
        {
            db = _dbStrategy ?? throw new DALFundsException(nameof(_dbStrategy));
        }
        public Tuple<bool, object> Add(TaskFilesMdl entity)
        {
            try
            {
                using (IDbConnection cn = db.GetConnection())
                {
                    var maxId = cn.GetMax<MaxId>(tableName);
                    int id = maxId.id + 1;
                    var dp = new DynamicParameters();
                    dp.Add("@id", id);
                    dp.Add("@path", entity.Path);
                    dp.Add("@taskId", entity.TaskId);
                    dp.Add("@enterdDate", entity.EnterdDate);
                    dp.Add("@fileText", entity.FileText);


                    int result = cn.Insert(tableName
                        , "Id, path, taskId, enterdDate,fileText"
                        , "@id, @path, @taskId, @enterdDate,@fileText"
                        , dp);
                    return Tuple.Create(result > 0, (object)result);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("{Repo} Add method error :" + type, ex);
            }
        }

        public IEnumerable<TaskFilesMdl> GetByTaskId(int taskId)
        {
            try
            {
                using (IDbConnection cn = db.GetConnection())
                {
                    var dp = new DynamicParameters();
                    dp.Add("@taskId", taskId);
                    return cn.GetAllBy<TaskFilesMdl>(tableName
                        , "taskId = @taskId"
                        , new { taskId = taskId });

                }
            }
            catch (Exception ex)
            {
                throw new Exception("{Repo} All method error :" + type, ex);
            }
        }
    }
}
