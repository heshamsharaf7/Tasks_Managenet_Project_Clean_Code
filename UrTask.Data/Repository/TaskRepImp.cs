using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using UrTask.Data.CustomException;
using UrTask.Data.DAL;
using UrTask.Data.DRY.Models;
using UrTask.Data.Extensions;
using UrTask.Domain.Entities;
using UrTask.Domain.IRepositires;

namespace UrTask.Data.Repository
{
    public class TaskRepImp : ITaskRepo
    {
        internal const string tableName = DRY.SchemaDB.GetSchemaName + "taskTb";
        private readonly IDbStrategy db;
        private Type type = typeof(TaskRepImp);
        public TaskRepImp(IDbStrategy _dbStrategy)
        {
            db = _dbStrategy ?? throw new DALFundsException(nameof(_dbStrategy));
        }
        public Tuple<bool, object> Add(TaskMdl entity)
        {
              try
            {
                using (IDbConnection cn = db.GetConnection())
                {
                    var maxId = cn.GetMax<MaxId>(tableName);
                    int id = maxId.id + 1;
                    var dp = new DynamicParameters();
                    dp.Add("@id", id);
                    dp.Add("@title", entity.title);
                    //dp.Add("@enterdDate", entity.EnterdDate.Date.ToString("yyyy-MM-dd HH:mm:ss"));
                    dp.Add("@enterdDate", entity.EnterdDate);
                    dp.Add("@dueDate", entity.DueDate);
                    //dp.Add("@dueDate", DateTime.Now);
                    dp.Add("@notes", entity.Notes);
                    //dp.Add("@remindMe", entity.RemindeMe);
                    dp.Add("@taskStatues", entity.TaskStatues);
                    dp.Add("@userId", entity.UserId);
                    //dp.Add("@endDate", Convert.ToDateTime(entity.endDate.Date.ToString("yyyy-MM-dd HH:mm:ss")));
                    //dp.Add("@endDate", DateTime.Now);
                    dp.Add("@price", entity.Price);


                    int result = cn.Insert(tableName
                        , "id, title, enterdDate, dueDate,notes,taskStatues,userId,price"
                        , "@id, @title, @enterdDate, @dueDate,@notes,@taskStatues,@userId,@price"
                        , dp);
                    return Tuple.Create(result > 0, (object)id );
                }
            }
            catch (Exception ex)
            {
                throw new Exception("{Repo} Add method error :" + type, ex);
            }
        }

        public bool Delete(int entity_id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TaskMdl> GetAll()
        {
            try
            {
                using (IDbConnection cn = db.GetConnection())
                {
                    return cn.GetAll<TaskMdl>(tableName);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("{Repo} All method error :" + type, ex);
            }
        }

        public IEnumerable<TaskMdl> GetAllBySearch(string searchStatement)
        {
            List<TaskMdl> tasks = new List<TaskMdl>();
            try
            {
                string sql = ("SELECT taskTb.id, taskTb.title,taskTb.enterdDate, taskTb.dueDate, taskTb.notes,taskTb.remindMe,taskTb.taskStatues,taskTb.userId,taskTb.endDate,taskTb.price FROM taskTb INNER JOIN taskFilesTb ON taskFilesTb.taskId = taskTb.id  where freetext(taskFilesTb.* ,'" + searchStatement + "') or  freetext(taskTb.* ,'" + searchStatement + "'); ");
                using (IDbConnection cn = db.GetConnection())
                {
                    return cn.CustomSqlQuery<TaskMdl>(sql);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("{Repo} All method error :" + type, ex);
            }

        }

        public IEnumerable<TaskMdl> GetAllByUserId(int userId)
        {
            try
            {
                using (IDbConnection cn = db.GetConnection())
                {
                    var dp = new DynamicParameters();
                    dp.Add("@userId", userId);
                    return cn.GetAllBy<TaskMdl>(tableName
                        , "userId = @userId"
                        , new { userId = userId });
                }
            }
            catch (Exception ex)
            {
                throw new Exception("{Repo} All method error :" + type, ex);
            }
        }

        //public IEnumerable<taskindexdto> GetAllIndex()
        //{
        //    string sql = "select taskTb.id, taskTb.title, taskTb.notes, taskTb.price, taskStatuesTb.name from taskTb, taskStatuesTb where taskStatuesTb.id =taskTb.taskStatues";
        //    try
        //    {
        //        using (IDbConnection cn = db.GetConnection())
        //        {
        //            return cn.CustomSqlQuery<taskindexdto>(sql).ToList();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("{Repo} All method error :" + type, ex);
        //    }
        //}

        public TaskMdl GetById(object id)
        {
            try
            {
                using (IDbConnection cn = db.GetConnection())
                {
                    var dp = new DynamicParameters();
                    dp.Add("@id", id);
                    return cn.GetSingleBy<TaskMdl>(tableName
                        , "id = @id"
                        , new { id = id });
                }
            }
            catch (Exception ex)
            {
                throw new Exception("{Repo} All method error :" + type, ex);
            }
        }

        public bool SetStatues(int id,int statues)
        {
            try
            {
                string sql = "";
                using (IDbConnection cn = db.GetConnection())
                {
                    //var dp = CustomMapping.Mapping(entity);
                    var dp = new DynamicParameters();
                    dp.Add("@id",id);
                    dp.Add("@taskStatues",statues);
                    if(statues==4)
                    {
                        dp.Add("@endDate", DateTime.Now);
                        sql = "taskStatues=@taskStatues,endDate=@endDate ";
                    }
                    else
                    {
                        sql = "taskStatues=@taskStatues";
                    }
                    

                    int result = cn.Update(tableName
                        , sql
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

        public bool Update(TaskMdl entity)
        {
            throw new NotImplementedException();
        }

        public bool UpdatePrice(int id, double price)
        {
            try
            {
                using (IDbConnection cn = db.GetConnection())
                {
                    //var dp = CustomMapping.Mapping(entity);
                    var dp = new DynamicParameters();
                    dp.Add("@id", id);
                    dp.Add("@price", price);


                    int result = cn.Update(tableName
                        , "price=@price"
                        , "id = @id"
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
