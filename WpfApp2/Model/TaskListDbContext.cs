using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp2.Model
{
    public class TaskListDbContext : DbContext
    {
        public TaskListDbContext(DbContextOptions<TaskListDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<TaskList> Tasks { get; set; }
        public DbSet<Item> Items { get; set; }


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
