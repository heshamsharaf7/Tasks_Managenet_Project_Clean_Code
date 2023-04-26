using UrTask.Domain.Entities;
using UrTask.Domain.IRepositires.BaseRepository;

namespace UrTask.Domain.IRepositires
{
    public interface IuserRepo : IBaseAddRepo<UserMdl>, IBaseUpdateRepo<UserMdl>
        , IBaseGetByIdRepo<UserMdl>, IBaseGetAllRepo<UserMdl>, IBaseDeleteRepo<int>
    {
        UserMdl GetForExists(string email, object id = null);
        bool CloseAccount(int id);
        UserMdl GetByEmail(string email);

    }
}
