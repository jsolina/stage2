using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastracture.Contracts
{
    public interface IBaseServices<T>
    {
        IEnumerable<T> FindAllTask();
        T FindTaskById(int id);
        void CreateTask(T entity);    
        void UpdateTask(T entity);
        void RemoveTask(T entity);
    }
}
