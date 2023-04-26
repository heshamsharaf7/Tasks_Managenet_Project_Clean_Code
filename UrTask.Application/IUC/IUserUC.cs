using UrTask.Application.DTOs.UserDto;
using UrTask.Application.IUC.BaseUsecases;

namespace UrTask.Application.IUC
{
   public interface IUserUC :  IBaseGetById<UserGetDto>, IBaseAdd<UserAddDto>,IBaseEdit<UserUpdateDto>,IBaseGetAll<UserGetDto>
    {
         UserGetDto GetByEmail(string email);
        UserUpdateDto GetByIdUpdate(int id);


    }
}
