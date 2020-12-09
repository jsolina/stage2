using Domain.Contracts;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp2.View
{
    /// <summary>
    /// Interaction logic for CreateUpdateTask.xaml
    /// </summary>
    public partial class CreateUpdateTask : Window
    {
        TaskList order = new TaskList();
        Domain.Models.TaskList taskListModel = new Domain.Models.TaskList();
        private ITaskList taskList;
        string updateOrAdd;

        public CreateUpdateTask(ITaskList _taskList, TaskList _taskListModel, string _updateOrAdd)
        {
            //this.dbContext = _dbContext;
            this.taskList = _taskList;

            InitializeComponent();
            updateOrAdd = _updateOrAdd;
            UpdateOrAddType.DataContext = new Model.SelectedRow() { UpdateOrAdd = updateOrAdd + " Task" };

            if (updateOrAdd == "Update")
            {
                taskListModel = _taskListModel;
                SelectedRowDetails.DataContext = taskListModel;

                name.Text = taskListModel.Name;
                desc.Text = taskListModel.Description;
            }
        }

        private void Submit(object s, RoutedEventArgs e)
        {
            taskListModel.Name = name.Text;
            taskListModel.Description = desc.Text;

            if (updateOrAdd == "Add")
            {                
                taskList.Create(taskListModel);
                MessageBox.Show("Task has been Added", "Added");
            }
            if (updateOrAdd == "Update")
            {
                taskList.Update(taskListModel);
                MessageBox.Show("Task has been Updated", "Updated");
            }
            this.Close();
        }
    }
}
