using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UrTask.Application.DTOs.UserDto;
using UrTask.Application.Enums.ResultsTypes;
using UrTask.Application.IUC;
using UrTask.Application.Utils.FinalResults;
using UrTask.Domain.Entities;
using UrTask.Domain.IRepositires;

namespace UrTask.Application.UC
{
    public class UserUC : IUserUC
    {
        private readonly IuserRepo _rep;
        private readonly IHostingEnvironment _environment;

        public UserUC(IuserRepo rep, IHostingEnvironment environment)
        {
            _rep = rep;
            _environment = environment;
        }
        public string title => "حسابي الشخصي";
        public UserGetDto GetById(int id)
        {
            try
            {
                var item = _rep.GetById(id);
                var entity = new UserGetDto().fromModelONE(item);
                   
                return entity;
            }
            catch (Exception e)
            {
                var x = e;
                ServicesResultsDRY.GetException();
                return new UserGetDto();
            }
        }

        public UserGetDto GetByEmail(string email)
        {
            try
            {
                var item = _rep.GetByEmail(email);
                var entity = new UserGetDto().fromModelONE(item);

                return entity;
            }
            catch (Exception e)
            {
                var x = e;
                ServicesResultsDRY.GetException();
                return new UserGetDto();
            }
        }

        public ServicesResultsDto Add(UserAddDto entity)
        {
            try
            {
                if(entity.PhotoFiles==null)
                {
                    entity.Photo = "logo.png";
                }
                else
                {
                    string wwwPath = _environment.WebRootPath;
                    string contentPath = _environment.ContentRootPath;

                    string path = Path.Combine(_environment.WebRootPath, "Uploads");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    List<string> uploadedFiles = new List<string>();
                    
                        string fileName = Path.GetFileName(entity.PhotoFiles.FileName);
                        using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                        {
                            entity.PhotoFiles.CopyTo(stream);
                            entity.Photo = fileName;

                        }

                    
                }


                UserMdl mdl = entity.toModel(entity);
                var tupleAdd = _rep.Add(mdl);
                var isDone = tupleAdd.Item1;
                if (isDone)
                    return ServicesResultsDRY.GetSuccess();
                else return ServicesResultsDRY.GetError(ResultsTypes.None);
            }
            catch (Exception e)
            {
                var x = e;
                return ServicesResultsDRY.GetException();
            }
        }

        public ServicesResultsDto Edit(int id, UserUpdateDto entity)
        {
            try
            {


                UserMdl mdl = entity.toModel(id, entity);

                var isDone = _rep.Update(mdl);
                if (isDone)
                    return ServicesResultsDRY.GetSuccess();
                else return ServicesResultsDRY.GetError(ResultsTypes.None);
            }
            catch (Exception)
            {
                return ServicesResultsDRY.GetException();
            }
        }

        public UserUpdateDto GetByIdUpdate(int id)
        {
            try
            {
                var item = _rep.GetById(id);
                UserUpdateDto entity = new UserUpdateDto().fromModel(item);

                return entity;
            }
            catch (Exception e)
            {
                var x = e;
                ServicesResultsDRY.GetException();
                return new UserUpdateDto();
            }
        }

        public IList<UserGetDto> GetAll()
        {
            try
            {
                var items = _rep.GetAll().ToList();
                IList<UserGetDto> entities = new UserGetDto().fromModel(items);
                return entities;
            }
            catch (Exception e)
            {
                var x = e;
                ServicesResultsDRY.GetException();
                return new List<UserGetDto>();
            }
        }
    }
}
