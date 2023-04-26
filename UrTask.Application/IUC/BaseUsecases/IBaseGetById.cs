using System;
using System.Collections.Generic;
using System.Text;

namespace UrTask.Application.IUC.BaseUsecases
{
   public interface IBaseGetById<T> where T : class, new()
    {
        T GetById(int id);
    }
}
