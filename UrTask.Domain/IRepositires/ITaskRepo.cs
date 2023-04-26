using System.Collections.Generic;
using UrTask.Domain.Entities;
using UrTask.Domain.IRepositires.BaseRepository;

namespace UrTask.Domain.IRepositires
{
   public interface ITaskRepo :IBaseAddRepo<TaskMdl>,IBaseDeleteRepo<int>,IBaseGetAllRepo<TaskMdl>, IBaseGetByIdRepo<TaskMdl>,IBaseUpdateRepo<TaskMdl>
    {
        //IEnumerable<taskindexdto> GetAllIndex();
        bool SetStatues(int id, int statues);
        bool UpdatePrice(int id, double price);
        IEnumerable<TaskMdl> GetAllByUserId(int userId);
        IEnumerable<TaskMdl> GetAllBySearch(string searchStatement);

    }
}
