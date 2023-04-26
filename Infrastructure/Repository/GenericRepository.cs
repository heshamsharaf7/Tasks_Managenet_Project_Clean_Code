using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Infrastructure.Repository
{
   public class GenericRepository<T> : IGenericRepositry<T> where T: class  
    {
        protected DataContext _dataContext;
        private DbSet<T> table = null;

        public GenericRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
            table = _dataContext.Set<T>();
        }
        public void Delete(object id)
        {
            T exisitng = GetById(id);
            table.Remove(exisitng);
        }

        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }

        public T GetById(object id)
        {
            return table.Find(id);
        }

        public void Insert(T entity)
        {
            table.Add(entity);
        }

        public void Update(T entity)
        {
            table.Attach(entity);
            _dataContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
