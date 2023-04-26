using System;
using System.Collections.Generic;
using System.Text;
using UrTask.Application.Utils.FinalResults;

namespace UrTask.Application.IUC.BaseUsecases
{
   public  interface IBaseAdd<T> where T : class, new()
    {
        string title { get; }
        ServicesResultsDto Add(T entity);
    }
}
