using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastracture.Persistence
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<TaskListModel> TaskLists { get; set; }
        public DbSet<ItemModel> Items { get; set; }

        public void Save()
        {
            SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskListModel>().HasData(GetTasks());
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ItemModel>().HasData(GetItems());
            base.OnModelCreating(modelBuilder);
        }

        private TaskListModel[] GetTasks()
        {
            return new TaskListModel[]
            {
                new TaskListModel { Id = 1, Name = "Work", Description = "this is desc.."},
                new TaskListModel { Id = 2, Name = "Shopping", Description = "this is desc.."},
            };
        }
        private ItemModel[] GetItems()
        {
            return new ItemModel[]
            {
                new ItemModel { Id = 1, IdTask = 2, ItemName = "Buying some cookies", ItemDetails = "this is desc", Status = "Pending"},
                new ItemModel { Id = 2, IdTask = 2, ItemName = "Buying Bananas", ItemDetails = "We love bananas", Status = "Done"},
                new ItemModel { Id = 3, IdTask = 1, ItemName = "Work Assignment", ItemDetails = "this is details..", Status = "Done"},
            };
        }
    }
 }
