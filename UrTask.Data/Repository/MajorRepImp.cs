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
    public class MajorRepImp : IMajorRepo
    {
        internal const string tableName = DRY.SchemaDB.GetSchemaName + "majorTb";
        private readonly IDbStrategy db;
        private Type type = typeof(MajorRepImp);
        public MajorRepImp(IDbStrategy _dbStrategy)
        {
            db = _dbStrategy ?? throw new DALFundsException(nameof(_dbStrategy));
        }
        public Tuple<bool, object> Add(MajorMdl entity)
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
                    dp.Add("@notes", entity.Notes);
                    dp.Add("@date", entity.EnterdDate);


                    int result = cn.Insert(tableName
                        , "Id, Name, Notes, EnterdDate"
                        , "@id, @name, @notes, @date"
                        , dp);
                    return Tuple.Create(result > 0, (object)result);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("{Repo} Add method error :" + type, ex);
            }
        }

        public bool Delete(int entity_id)
        {
            try
            {
                using (IDbConnection cn = db.GetConnection())
                {
                    int result = cn.Delete(tableName, "id = @id", new { id = entity_id });
                    return (result > 0);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("{Repo} Delete method error :" + type, ex);
            }
        }

        public IEnumerable<MajorMdl> GetAll()
        {
            try
            {
                using (IDbConnection cn = db.GetConnection())
                {
                    return cn.GetAll<MajorMdl>(tableName);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("{Repo} All method error :" + type, ex);
            }
        }

        public MajorMdl GetById(object id)
        {
            try
            {
                using (IDbConnection cn = db.GetConnection())
                {
                    var dp = new DynamicParameters();
                    dp.Add("@id", id);
                    return cn.GetSingleBy<MajorMdl>(tableName
                        , "id = @id"
                        , new { id = id });
                }
            }
            catch (Exception ex)
            {
                throw new Exception("{Repo} All method error :" + type, ex);
            }
        }

        public MajorMdl GetForExists(string name, object id = null)
        {
            throw new NotImplementedException();
        }

        public bool Update(MajorMdl entity)
        {
            try
            {
                using (IDbConnection cn = db.GetConnection())
                {
                    //var dp = CustomMapping.Mapping(entity);
                    var dp = new DynamicParameters();
                    dp.Add("@id", entity.Id);
                    dp.Add("@name", entity.Name);
                    dp.Add("@notes", entity.Notes);
                    dp.Add("@date", entity.EnterdDate);

                    int result = cn.Update(tableName
                        , "Name=@name, Notes=@notes, EnterdDate=@date"
                        , "Id = @id"
                        , dp);
                    return (result > 0);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("{Repo} Update method error :" + type, ex);
            }
        }
    }
}
