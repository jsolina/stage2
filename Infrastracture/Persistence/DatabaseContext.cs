using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastracture.Persistence
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<TaskList> TaskLists { get; set; }
        public DbSet<Item> Items { get; set; }

        public void Save()
        {
            SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskList>().HasData(GetTasks());
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Item>().HasData(GetItems());
            base.OnModelCreating(modelBuilder);
        }

        private TaskList[] GetTasks()
        {
            return new TaskList[]
            {
                new TaskList { Id = 1, Name = "Work", Description = "this is desc.."},
                new TaskList { Id = 2, Name = "Shopping", Description = "this is desc.."},
            };
        }
        private Item[] GetItems()
        {
            return new Item[]
            {
                new Item { Id = 1, IdTask = 2, ItemName = "Buying some cookies", ItemDetails = "this is desc", Status = "Pending"},
                new Item { Id = 2, IdTask = 2, ItemName = "Buying Bananas", ItemDetails = "We love bananas", Status = "Done"},
                new Item { Id = 3, IdTask = 1, ItemName = "Work Assignment", ItemDetails = "this is details..", Status = "Done"},
            };
        }

    }
}
