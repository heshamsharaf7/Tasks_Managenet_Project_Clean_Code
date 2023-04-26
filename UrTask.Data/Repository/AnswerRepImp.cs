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
   public class AnswerRepImp : IAnswerRepo
    {
        internal const string tableName = DRY.SchemaDB.GetSchemaName + "deliveryTb";
        private readonly IDbStrategy db;
        private Type type = typeof(TaskRepImp);
        public AnswerRepImp(IDbStrategy _dbStrategy)
        {
            db = _dbStrategy ?? throw new DALFundsException(nameof(_dbStrategy));
        }
        public Tuple<bool, object> Add(DeliveryMdl entity)
        {
            try
            {
                using (IDbConnection cn = db.GetConnection())
                {
                    var maxId = cn.GetMax<MaxId>(tableName);
                    int id = maxId.id + 1;
                    var dp = new DynamicParameters();
                    dp.Add("@id", id);
                    dp.Add("@enterdDate", entity.EnterdDate);
                    dp.Add("@notes", entity.Notes);
                    dp.Add("@taskId", entity.TaskId);


                    int result = cn.Insert(tableName
                        , "id,  enterDate, notes,taskId"
                        , "@id, @enterdDate,@notes, @taskId"
                        , dp);
                    return Tuple.Create(result > 0, (object)id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("{Repo} Add method error :" + type, ex);
            }
        }

        public IEnumerable<DeliveryMdl> GetByTaskId(int taskId)
        {
            try
            {
                using (IDbConnection cn = db.GetConnection())
                {
                    var dp = new DynamicParameters();
                    dp.Add("@taskId", taskId);
                    return cn.GetAllBy<DeliveryMdl>(tableName
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
