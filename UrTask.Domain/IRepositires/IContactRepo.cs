using System;
using System.Collections.Generic;
using System.Text;
using UrTask.Domain.Entities;
using UrTask.Domain.IRepositires.BaseRepository;

namespace UrTask.Domain.IRepositires
{
   public interface IContactRepo: IBaseAddRepo<ContactMdl>,IBaseGetAllRepo<ContactMdl>
    {
    }
}
