using System;


namespace UrTask.Domain.IRepositires.BaseRepository
{
    public interface IBaseAddRepo<T> where T : class, new()
    {
        Tuple<bool, object> Add(T entity);
    }
}
