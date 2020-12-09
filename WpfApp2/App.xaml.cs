using Domain.Contracts;
using Infrastracture.Contracts;
using Infrastracture.Persistence;
using Infrastracture.Repositories;
using Infrastracture.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfApp2.Model;
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
                option.UseSqlite("Data Source = Task2.db");
            });

            services.AddScoped<ITaskList, TaskListRepo>();
            services.AddScoped<IItem, ItemRepo>();
            services.AddScoped<ITaskListService, TaskListServices>();


            services.AddSingleton<Window1>();
            serviceProvider = services.BuildServiceProvider();
        }

        private void OnStartup(object s, StartupEventArgs e)
        {
            var mainWindow = serviceProvider.GetService<Window1>();
            mainWindow.Show();
        }
    }
}
