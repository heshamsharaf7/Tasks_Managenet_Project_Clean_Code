using System.Collections.Generic;
using System.Linq;
using UrTask.Application.Configuration;
using UrTask.Application.DTOs.General;
using UrTask.Domain.Entities;
using UrTask.Domain.IRepositires;

namespace UrTask.Application.DTOs.StatuesDto
{
   public class MajorValueDto: ValueIdDto
    {
        public  List<MajorValueDto> GetAll()
        {
            IMajorRepo _repo = DependenciesIOC.GetInstanceUC<IMajorRepo>();
            var lstMdl = _repo.GetAll();
            return _GetAll(lstMdl.ToList());
        }
        internal List<MajorValueDto> fromModel(List<MajorMdl> lstMdl)
        {
            return _GetAll(lstMdl);
        }
        private  List<MajorValueDto> _GetAll(IList<MajorMdl> lstMdl)
        {
            var lst = new List<MajorValueDto>();
            foreach (var item in lstMdl)
            {
                lst.Add(new MajorValueDto() { id = item.Id, name = item.Name });
            }
            return lst;
        }
    }
}
