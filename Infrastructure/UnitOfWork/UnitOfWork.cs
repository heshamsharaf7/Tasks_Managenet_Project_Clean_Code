using Core.Entities;
using Core.Interfaces;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.UnitOfWork
{
   public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        public IMajorRepository Major { get; private set; }

        public UnitOfWork(DataContext context)
        {
            _context = context;

            Major = new MajorRepository(_context);
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

       
    }
}
