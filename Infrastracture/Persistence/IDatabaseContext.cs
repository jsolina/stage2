using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Infrastracture.Persistence
{
    public interface IDatabaseContext
    {
        DbSet<TaskListModel> TaskLists { get; set; }
        DbSet<ItemModel> Items { get; set; }
        void Save();

        /*
        protected void OnModelCreating();

        void GetTasks();
        */

    }
}
