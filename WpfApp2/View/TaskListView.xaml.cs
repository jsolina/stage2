using System.Linq;
using System.Windows;
using WpfApp2.ViewModel;
using System.Windows.Input;
using Domain.Contracts;

namespace WpfApp2.View
{
    /// <summary>
    /// Interaction logic for TaskListVIew.xaml
    /// </summary>
    public partial class TaskListView : Window
    {
        private ITaskList taskListDbContext;
        private IItem itemDbContext;

        public TaskListView(ITaskList _taskListDbContext, IItem _itemDbContext)
        {
            this.taskListDbContext = _taskListDbContext;
            this.itemDbContext = _itemDbContext;

            InitializeComponent();

            var viewModel = new TaskListViewModel(taskListDbContext, itemDbContext);
            DataContext = viewModel;
        }
    }

}
