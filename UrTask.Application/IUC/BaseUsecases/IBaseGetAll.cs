using System;
using System.Collections.Generic;
using System.Text;

namespace UrTask.Application.IUC.BaseUsecases
{
   public interface IBaseGetAll<T> where T:class, new()
    {
        IList<T> GetAll();
    }
}
