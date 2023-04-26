using UrTask.Domain.Entities;
using UrTask.Domain.IRepositires.BaseRepository;

namespace UrTask.Domain.IRepositires
{
   public interface ITaskStatuesRepo : IBaseAddRepo<TaskStatuesMdl>, IBaseDeleteRepo<int>, IBaseGetAllRepo<TaskStatuesMdl>, IBaseGetByIdRepo<TaskStatuesMdl>, IBaseUpdateRepo<TaskStatuesMdl>
    {
    }
}
