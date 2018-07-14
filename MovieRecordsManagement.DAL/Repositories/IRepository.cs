using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieRecordsManagement.DAL.Repositories
{
    public interface IRepository<T>
    {
        void Add(T item);
        void DeleteById(Guid id);
        IQueryable<T> GetAll();
        T FindById(Guid id);
        void Update(T entity);
    }
}
