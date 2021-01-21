using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public interface IBaseRepo<T>
    {
        IEnumerable<T> FindAll();
        T FindById(object id);
        void Create(T entity);
        void Update(T entity);
        void Remove(T entity);
    }
}
