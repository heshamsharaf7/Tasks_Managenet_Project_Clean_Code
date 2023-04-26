
namespace UrTask.Domain.IRepositires.BaseRepository
{
    public interface IBaseUpdateRepo<T> where T : class, new()
    {
        bool Update(T entity);
    }
}
