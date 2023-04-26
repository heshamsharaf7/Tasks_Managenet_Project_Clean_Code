using UrTask.Domain.Entities;
using UrTask.Domain.IRepositires.BaseRepository;

namespace UrTask.Domain.IRepositires
{
    public interface IMajorRepo : IBaseAddRepo<MajorMdl>, IBaseUpdateRepo<MajorMdl>
        , IBaseGetByIdRepo<MajorMdl>, IBaseGetAllRepo<MajorMdl>, IBaseDeleteRepo<int>
    {
        MajorMdl GetForExists(string name, object id = null);

    }
}
