using Domain.Contracts;
using Domain.Models;
using Infrastracture.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastracture.Repositories
{
    public class TaskListRepo : ITaskList
    {
        private IDatabaseContext _dbcontext;
            
        public TaskListRepo(IDatabaseContext context) => _dbcontext = context;

        public void Create(TaskListModel entity)
        {
            _dbcontext.TaskLists.Add(entity);
            _dbcontext.Save();
        }

        public IEnumerable<TaskListModel> FindAll()
        {
            return _dbcontext.TaskLists.OrderByDescending(i => i.Id).ToList();
        }

        public IEnumerable<TaskListModel> FindByFK()
        {
            throw new NotImplementedException();
        }

        public TaskListModel FindById(object id)
        {
            return _dbcontext.TaskLists.Where(d => d.Id.Equals(id)).FirstOrDefault();
        }

        public void Remove(TaskListModel entity)
        {
            _dbcontext.TaskLists.Remove(entity);
            _dbcontext.Save();
        }

        public void Update(TaskListModel entity)
        {
            _dbcontext.TaskLists.Update(entity);
            _dbcontext.Save();
        }
    }
}
