
using UrTask.Application.DTOs.MajorDto;
using UrTask.Application.IUC.BaseUsecases;

namespace UrTask.Application.IUC
{

    
   public interface IMajor : IBaseAdd<MajorAddDto>, IBaseDelete, IBaseEdit<MajorUpdateDto>, IBaseGetAll<MajorGetDto>, IBaseGetById<MajorGetDto>
    {
        MajorUpdateDto GetByIdUpdate(int id);
    }
}
