using System;

namespace Core.Interfaces
{
   public interface IUnitOfWork: IDisposable
    {
        IMajorRepository Major { get; }



        int Save();

    }
}
