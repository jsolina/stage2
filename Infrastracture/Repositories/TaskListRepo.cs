using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Infrastracture.Persistence;
using Domain.Contracts;
using Domain.Models;

namespace Infrastracture.Repositories
{
    public class TaskListRepo : ITaskList
    {
        private IDatabaseContext _dbcontext;

        public TaskListRepo(IDatabaseContext context) => _dbcontext = context;

        public void Create(TaskList entity)
        {
            //entity.idReminders = Guid.NewGuid();
            _dbcontext.TaskLists.Add(entity);
            _dbcontext.Save();
        }

        public IEnumerable<TaskList> FindAll()
        {
            return _dbcontext.TaskLists.OrderByDescending(i => i.Id).ToList();
        }

        public IEnumerable<TaskList> FindByFK()
        {
            throw new NotImplementedException();
        }

        public TaskList FindById(int id)
        {
            return _dbcontext.TaskLists.Where(d => d.Id.Equals(id)).FirstOrDefault();
        }

        public void Remove(TaskList entity)
        {
            _dbcontext.TaskLists.Remove(entity);
            _dbcontext.Save();
        }

        public void Update(TaskList entity)
        {
            _dbcontext.TaskLists.Update(entity);
            _dbcontext.Save();
        }
    }
}
