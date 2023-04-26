using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UrTask.Application.DTOs.MajorDto;
using UrTask.Application.IUC;
using UrTask.Application.Utils.FinalResults;
using UrTask.Domain.IRepositires;
using UrTask.Application.Enums.ResultsTypes;
using UrTask.Domain.Entities;

namespace UrTask.Application.UC
{
    public class MajorUC : IMajor
    {
        private readonly IMajorRepo _rep;
        public MajorUC(IMajorRepo rep)
        {
            _rep = rep;
        }
        public string title =>"صفحة التخصصات";

        public ServicesResultsDto Add(MajorAddDto entity)
        {
            try
            {


                MajorMdl mdl = entity.toModel(entity);

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

        public ServicesResultsDto Delete(int id)
        {
            try
            {
                var isDone = _rep.Delete(id);
                if (isDone)
                    return ServicesResultsDRY.GetSuccess();
                else return ServicesResultsDRY.GetError(ResultsTypes.None);
            }
            catch (Exception)
            {
                return ServicesResultsDRY.GetException();
            }
        }

        public ServicesResultsDto Edit(int id, MajorUpdateDto entity)
        {
            try
            {


                MajorMdl mdl = entity.toModel(id, entity);

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

        public IList<MajorGetDto> GetAll()
        {
            try
            {
                var items = _rep.GetAll().ToList();
                IList<MajorGetDto> entities = new MajorGetDto().fromModel(items);
                return entities;
            }
            catch (Exception e)
            {
                var x = e;
                ServicesResultsDRY.GetException();
                return new List<MajorGetDto>();
            }
        }

        public MajorGetDto GetById(int id)
        {
            try
            {
                var item = _rep.GetById(id);
                MajorGetDto entity = new MajorGetDto();
                return entity;
            }
            catch (Exception e)
            {
                var x = e;
                ServicesResultsDRY.GetException();
                return new MajorGetDto();
            }
        }

        public MajorUpdateDto GetByIdUpdate(int id)
        {
            try
            {
                var item = _rep.GetById(id);
                MajorUpdateDto entity = new MajorUpdateDto().fromModel(item);
                
                return entity;
            }
            catch (Exception e)
            {
                var x = e;
                ServicesResultsDRY.GetException();
                return new MajorUpdateDto();
            }
        }
    }
}
