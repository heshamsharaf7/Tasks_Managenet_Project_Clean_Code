using System.Collections.Generic;
using UrTask.Domain.Entities;
using UrTask.Domain.IRepositires.BaseRepository;

namespace UrTask.Domain.IRepositires 
{
   public interface IAnswerRepo : IBaseAddRepo<DeliveryMdl>
    {
        IEnumerable<DeliveryMdl> GetByTaskId(int taskId);
    }
}
