using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Models;
using Domain.Contracts;
using Infrastracture.Contracts;

namespace Infrastracture.Services
{
    public class TaskListServices : ITaskListService
    {
        private ITaskList _repoServices;
        public TaskListServices(ITaskList repo) => _repoServices = repo;
        public void CreateTask(TaskList entity)
        {
            _repoServices.Create(entity);
        }

        public IEnumerable<TaskList> FindAllTask()
        {
            return _repoServices.FindAll().OrderBy(c    => c.Id);
        }

        public TaskList FindTaskById(int id)
        {
            return _repoServices.FindById(id);
        }

        public void RemoveTask(TaskList entity)
        {
            _repoServices.Remove(entity);
        }

        public void samp()
        {
    
        }

        public void UpdateTask(TaskList entity)
        {
            _repoServices.Update(entity);
        }
    }   
}
