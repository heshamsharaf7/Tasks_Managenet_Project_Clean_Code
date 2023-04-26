using System;
using System.Collections.Generic;
using System.Text;
using UrTask.Application.Utils.FinalResults;

namespace UrTask.Application.IUC.BaseUsecases
{
   public interface IBaseEdit<T> where T : class, new()
    {
        ServicesResultsDto Edit(int id, T entity);
    }
}
