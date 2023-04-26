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
   public class AnswerFileRepImp : IAnswerFileRepo
    {
        internal const string tableName = DRY.SchemaDB.GetSchemaName + "deliveryFilesTb";
        private readonly IDbStrategy db;
        private Type type = typeof(TaskFileRepImp);
        public AnswerFileRepImp(IDbStrategy _dbStrategy)
        {
            db = _dbStrategy ?? throw new DALFundsException(nameof(_dbStrategy));
        }
        public Tuple<bool, object> Add(DeliveryFilesMdl entity)
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
                    dp.Add("@deliveryId", entity.DeliveryId);
                    dp.Add("@enterdDate", entity.EnterdDate);


                    int result = cn.Insert(tableName
                        , "Id, path, deliveryId, enterdDate"
                        , "@id, @path, @deliveryId, @enterdDate"
                        , dp);
                    return Tuple.Create(result > 0, (object)result);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("{Repo} Add method error :" + type, ex);
            }
        }

        public IEnumerable<DeliveryFilesMdl> GetByAnswerId(int deliveryId)
        {
            try
            {
                using (IDbConnection cn = db.GetConnection())
                {
                    var dp = new DynamicParameters();
                    dp.Add("@deliveryId", deliveryId);
                    return cn.GetAllBy<DeliveryFilesMdl>(tableName
                        , "deliveryId = @deliveryId"
                        , new { deliveryId = deliveryId });
                }
            }
            catch (Exception ex)
            {
                throw new Exception("{Repo} All method error :" + type, ex);
            }
        }
    }
}
