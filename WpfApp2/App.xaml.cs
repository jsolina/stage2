using Domain.Contracts;
using Infrastracture.Persistence;
using Infrastracture.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfApp2.View;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider serviceProvider;

        public App()
        {
            ServiceCollection services = new ServiceCollection();
            /*

            services.AddDbContext<TaskListDbContext>(option =>
            {
                option.UseSqlite("Data Source = Task.db");
            });
            */

            services.AddDbContext<IDatabaseContext, DatabaseContext>(option =>
            {
                option.UseSqlite("Data Source = TodoApp2.db");
            });

            services.AddScoped<ITaskList, TaskListRepo>();
            services.AddScoped<IItem, ItemRepo>();
           // services.AddScoped<ITaskListService, TaskListServices>();


            services.AddSingleton<TaskListView>();
            serviceProvider = services.BuildServiceProvider();
        }

        private void OnStartup(object s, StartupEventArgs e)
        {
            var mainWindow = serviceProvider.GetService<TaskListView>();
            mainWindow.Show();
        }
    }
}
