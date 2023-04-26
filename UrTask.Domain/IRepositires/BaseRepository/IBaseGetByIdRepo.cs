

namespace UrTask.Domain.IRepositires.BaseRepository
{
    public interface IBaseGetByIdRepo<T> where T : class, new()
    {
        T GetById(object id);
    }
}
