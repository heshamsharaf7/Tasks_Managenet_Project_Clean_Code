using System;
using System.Collections.Generic;
using System.Text;
using UrTask.Application.DTOs.ContactDto;
using UrTask.Application.IUC.BaseUsecases;

namespace UrTask.Application.IUC
{
   public interface IContactUC: IBaseGetAll<ContactGetDto>, IBaseAdd<ContactAddDto>
    {
    }
}
