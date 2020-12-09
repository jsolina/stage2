using Domain.Contracts;
using Domain.Models;
using Infrastracture.Persistence;
using System.Linq;
using System.Windows;
//using WpfApp2.Model;

namespace WpfApp2.View
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        TaskList taskListModel = new TaskList();
        private ITaskList taskList;
        private IItem item;

        public Window1(ITaskList _taskList, IItem _item)
        {
            InitializeComponent();
   
            this.taskList = _taskList;
            this.item = _item;

            GetTasks();
        }

        private void GetTasks()
        {
            OrderDG.ItemsSource = taskList.FindAll();
        }

        private void View(object s, RoutedEventArgs e)
        {
            taskListModel = (s as FrameworkElement).DataContext as TaskList;
            ViewItems vi = new ViewItems(item, taskListModel);
            vi.ShowDialog();
            GetTasks();
        }

        private void Add(object s, RoutedEventArgs e)
        {
            CreateUpdateTask cuo = new CreateUpdateTask(taskList, taskListModel, "Add");
            cuo.ShowDialog();
            GetTasks();
        }

        private void Update(object s, RoutedEventArgs e)
        {
            taskListModel = (s as FrameworkElement).DataContext as TaskList;
            CreateUpdateTask cuo = new CreateUpdateTask(taskList, taskListModel, "Update");
            cuo.ShowDialog();
            GetTasks();
        }

        private void Delete(object s, RoutedEventArgs e)
        {
            var rowToBeDeleted = (s as FrameworkElement).DataContext as TaskList;
            taskList.Remove(rowToBeDeleted);
            GetTasks();
            MessageBox.Show(rowToBeDeleted.Name + " has been Deleted", "Task Deleted!");
        }
    }

}
