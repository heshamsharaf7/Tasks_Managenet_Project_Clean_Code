using System.Collections.Generic;

namespace UrTask.Domain.IRepositires.BaseRepository
{
    public interface IBaseGetAllRepo<T> where T : class, new()
    {
        IEnumerable<T> GetAll();
    }
}
