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
    public class UserRepImp : IuserRepo
    {
        internal const string tableName = DRY.SchemaDB.GetSchemaName + "userTb";
        private readonly IDbStrategy db;
        private Type type = typeof(MajorRepImp);
        public UserRepImp(IDbStrategy _dbStrategy)
        {
            db = _dbStrategy ?? throw new DALFundsException(nameof(_dbStrategy));
        }

        public Tuple<bool, object> Add(UserMdl entity)
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
                    dp.Add("@email", entity.Email);
                    dp.Add("@registerdDate", DateTime.Now);
                    dp.Add("@photo", entity.Photo);
                    dp.Add("@typeId", 2);
                    dp.Add("@majorId", entity.MajorId);
                    dp.Add("@password", entity.Password);
                    dp.Add("@closed", false);
                    dp.Add("@phoneNumber", entity.PhoneNumber);




                    int result = cn.Insert(tableName
                        , "id, name, email, registerdDate, photo,typeId, majorId, password, closed,phoneNumber"
                        , "@id, @name, @email, @registerdDate, @photo , @typeId , @majorId, @password, @closed, @phoneNumber"
                        , dp);
                    return Tuple.Create(result > 0, (object)result);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("{Repo} Add method error :" + type, ex);
            }
        }

        public bool CloseAccount(int id)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int entity_id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserMdl> GetAll()
        {
            try
            {
                using (IDbConnection cn = db.GetConnection())
                {
                    return cn.GetAll<UserMdl>(tableName);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("{Repo} All method error :" + type, ex);
            }
        }

        public UserMdl GetByEmail(string email)
        {
            try
            {
                using (IDbConnection cn = db.GetConnection())
                {
                    var dp = new DynamicParameters();
                    dp.Add("@email", email);
                    return cn.GetSingleBy<UserMdl>(tableName
                        , "email = @email"
                        , new { email = email });
                }
            }
            catch (Exception ex)
            {
                throw new Exception("{Repo} All method error :" + type, ex);
            }
        }

        public UserMdl GetById(object id)
        {
            try
            {
                using (IDbConnection cn = db.GetConnection())
                {
                    var dp = new DynamicParameters();
                    dp.Add("@id", id);
                    return cn.GetSingleBy<UserMdl>(tableName
                        , "id = @id"
                        , new { id = id });
                }
            }
            catch (Exception ex)
            {
                throw new Exception("{Repo} All method error :" + type, ex);
            }
        }

        public UserMdl GetForExists(string email, object id = null)
        {
            throw new NotImplementedException();
        }

        public bool Update(UserMdl entity)
        {
            try
            {
                using (IDbConnection cn = db.GetConnection())
                {
                    //var dp = CustomMapping.Mapping(entity);
                    var dp = new DynamicParameters();
                    dp.Add("@id", entity.Id);
                    dp.Add("@name", entity.Name);
                    dp.Add("@email", entity.Email);
                    dp.Add("@phoneNumber", entity.PhoneNumber);
                    dp.Add("@password", entity.Password);

                    int result = cn.Update(tableName
                        , "name=@name,   email=@email,phoneNumber=@phoneNumber,password=@password"
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
