using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repository
{
    public class MajorRepository : GenericRepository<Major>, IMajorRepository
    {

        public MajorRepository(DataContext context) : base(context)
        {
                
        }
       
    }
}
