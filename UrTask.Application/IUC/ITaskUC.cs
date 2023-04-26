using System.Collections;
using System.Collections.Generic;
using UrTask.Application.DTOs.AnswersDto;
using UrTask.Application.DTOs.TaskDto;
using UrTask.Application.IUC.BaseUsecases;
using UrTask.Application.Utils.FinalResults;

namespace UrTask.Application.IUC
{
   public interface ITaskUC:IBaseAdd<TaskAddDto>, IBaseGetAll<TaskGetDto>, IBaseGetById<TaskDetailsDto>
    {
        //IList<taskindexdto> getindex();
        ServicesResultsDto SetStatues(int id, int statues);
        ServicesResultsDto UpdatePrice(int id, double price);
        IList<AnswerGetDto> GetAllAnswers(int taskId);
        IList<TaskGetDto> GetAllByUserId(int userId);
        IList<TaskGetDto> GetAllBySearchString(string searchString);

    }
}
