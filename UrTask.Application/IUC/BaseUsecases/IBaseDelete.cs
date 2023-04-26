using System;
using System.Collections.Generic;
using System.Text;
using UrTask.Application.Utils.FinalResults;

namespace UrTask.Application.IUC.BaseUsecases
{
   public interface IBaseDelete
    {
        ServicesResultsDto Delete(int id);
    }
}
