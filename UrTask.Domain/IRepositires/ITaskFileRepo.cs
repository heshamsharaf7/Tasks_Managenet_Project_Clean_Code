using UrTask.Domain.Entities;
using UrTask.Domain.IRepositires.BaseRepository;
using System.Collections.Generic;

namespace UrTask.Domain.IRepositires
{
   public interface ITaskFileRepo : IBaseAddRepo<TaskFilesMdl>
    {
        IEnumerable<TaskFilesMdl> GetByTaskId(int taskId);

    }
}
