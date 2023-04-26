using System.Collections.Generic;
using System.Linq;
using UrTask.Application.Configuration;
using UrTask.Application.DTOs.General;
using UrTask.Domain.Entities;
using UrTask.Domain.IRepositires;

namespace UrTask.Application.DTOs.StatuesDto
{
   public class StatuesValueDto : ValueIdDto
    {
        public List<StatuesValueDto> GetAll()
        {
            ITaskStatuesRepo _repo = DependenciesIOC.GetInstanceUC<ITaskStatuesRepo>();
            var lstMdl = _repo.GetAll();
            return _GetAll(lstMdl.ToList());
        }
        internal List<StatuesValueDto> fromModel(List<TaskStatuesMdl> lstMdl)
        {
            return _GetAll(lstMdl);
        }
        private List<StatuesValueDto> _GetAll(IList<TaskStatuesMdl> lstMdl)
        {
            var lst = new List<StatuesValueDto>();
            foreach (var item in lstMdl)
            {
                lst.Add(new StatuesValueDto() { id = item.Id, name = item.Name });
            }
            return lst;
        }
    }
}
