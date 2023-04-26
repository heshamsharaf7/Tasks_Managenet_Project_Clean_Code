using System;
using System.Collections.Generic;
using System.Linq;
using UrTask.Application.DTOs.ContactDto;
using UrTask.Application.Enums.ResultsTypes;
using UrTask.Application.IUC;
using UrTask.Application.Utils.FinalResults;
using UrTask.Domain.Entities;
using UrTask.Domain.IRepositires;

namespace UrTask.Application.UC
{
    public class ContactUC : IContactUC
    {
        private readonly IContactRepo _rep;
        public ContactUC(IContactRepo rep)
        {
            _rep = rep;
        }
        public string title => throw new NotImplementedException();

        public ServicesResultsDto Add(ContactAddDto entity)
        {
            try
            {


                ContactMdl mdl = entity.toModel(entity);

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

        public IList<ContactGetDto> GetAll()
        {
            try
            {
                var items = _rep.GetAll().ToList();
                IList<ContactGetDto> entities = new ContactGetDto().fromModel(items);
                return entities;
            }
            catch (Exception e)
            {
                var x = e;
                ServicesResultsDRY.GetException();
                return new List<ContactGetDto>();
            }
        }
    }
}
