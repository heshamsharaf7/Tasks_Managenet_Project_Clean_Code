using UrTask.Application.DTOs.TaskFileDto;
using UrTask.Application.IUC.BaseUsecases;

namespace UrTask.Application.IUC
{
    
  public  interface ITaskFileUC: IBaseAdd<TaskFileAddDto>
    {
        //TaskFileGetDto GetByTaskId(int taskId);
    }
}
