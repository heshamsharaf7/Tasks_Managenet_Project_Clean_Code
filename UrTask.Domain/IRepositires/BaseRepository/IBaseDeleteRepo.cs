using System;


namespace UrTask.Domain.IRepositires.BaseRepository
{
    public interface IBaseDeleteRepo<T> where T : struct
    {
        bool Delete(T entity_id);
    }
}
