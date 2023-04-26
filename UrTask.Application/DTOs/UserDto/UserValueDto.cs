using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UrTask.Application.Configuration;
using UrTask.Application.DTOs.General;
using UrTask.Domain.Entities;
using UrTask.Domain.IRepositires;

namespace UrTask.Application.DTOs.UserDto
{
   public class UserValueDto: ValueIdDto
    {
        public List<UserValueDto> GetAll()
        {
            IuserRepo _repo = DependenciesIOC.GetInstanceUC<IuserRepo>();
            var lstMdl = _repo.GetAll();
            return _GetAll(lstMdl.ToList());
        }
        internal List<UserValueDto> fromModel(List<UserMdl> lstMdl)
        {
            return _GetAll(lstMdl);
        }
        private List<UserValueDto> _GetAll(IList<UserMdl> lstMdl)
        {
            var lst = new List<UserValueDto>();
            foreach (var item in lstMdl)
            {
                lst.Add(new UserValueDto() { id = item.Id, name = item.Name });
            }
            return lst;
        }
    }
}
