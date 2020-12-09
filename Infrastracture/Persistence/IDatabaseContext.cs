using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Infrastracture.Persistence
{
    public interface IDatabaseContext
    {
        DbSet<TaskList> TaskLists { get; set; }
        DbSet<Item> Items { get; set; }
        void Save();

        /*
        protected void OnModelCreating();

        void GetTasks();
        */

    }
}
