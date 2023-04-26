using UrTask.Domain.Entities;
using UrTask.Domain.IRepositires.BaseRepository;
using System.Collections.Generic;

namespace UrTask.Domain.IRepositires
{
   public interface IAnswerFileRepo : IBaseAddRepo<DeliveryFilesMdl>
    {
        IEnumerable<DeliveryFilesMdl> GetByAnswerId(int deliveryId);


    }
}
