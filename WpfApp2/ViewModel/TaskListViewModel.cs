using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows.Data;
using WpfApp2.Commnds;
using WpfApp2.View;
using System.Windows;
using Domain.Models;
using Domain.Contracts;

namespace WpfApp2.ViewModel
{
    public class TaskListViewModel : INotifyPropertyChanged
    {

        private IEnumerable<TaskListModel> taskList;
        private TaskListModel taskListSelectedRow = new TaskListModel();
        ITaskList taskListDbContext;
        IItem itemDbContext;

        public TaskListViewModel(ITaskList _taskListDbContext, IItem _itemDbContext)
        {
            this.taskListDbContext = _taskListDbContext;
            this.itemDbContext = _itemDbContext;

            GetData();
        }

        public void GetData()
        {
            TaskLists = taskListDbContext.FindAll();
        }

        public IEnumerable<TaskListModel> TaskLists
        {
            get { return taskList; }
            set 
            {
                if (value != taskList)
                {
                    taskList = value;
                    NotifyPropertyChanged("TaskLists");
                }
            }
        }


        //para mag update yung changes
        #region INotifyPropertyChanged Members  

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
        //end para mag update ang changes

        public RelayCommand DeleteCommand
        {
            get
            {
                return new RelayCommand(p => Delete(p));
            }
        }

        public RelayCommand UpdateCommands
        {
            get
            {
                return new RelayCommand(p => Updates(p));
            }
        }

        public RelayCommand AddCommands
        {
            get
            {
                return new RelayCommand(p => Add(p));
            }
        }
        public RelayCommand ViewCommands
        {
            get
            {
                return new RelayCommand(p => View(p));
            }
        }

        public void Delete(object o)
        {
            taskListSelectedRow = taskListDbContext.FindById(o);
            taskListDbContext.Remove(taskListSelectedRow);
            MessageBox.Show(taskListSelectedRow.Name + " has been Deleted", "Deleted", MessageBoxButton.OK, MessageBoxImage.Information);
            GetData();
        }

        public void Updates(object o)
        {
            taskListSelectedRow = taskListDbContext.FindById(o);
            AddUpdateTaskView cuo = new AddUpdateTaskView(taskListDbContext, taskListSelectedRow, "Update");
            cuo.ShowDialog();
            GetData();
        }

        public void Add(object o)
        {
            AddUpdateTaskView cuo = new AddUpdateTaskView(taskListDbContext, taskListSelectedRow, "Add");
            cuo.ShowDialog();
            GetData();
        }

        public void View(object o)
        {
            taskListSelectedRow = taskListDbContext.FindById(o);
            ItemsView vi = new ItemsView(itemDbContext, taskListSelectedRow);
            vi.ShowDialog();
            GetData();
  
        }

        public class RelayCommand : ICommand
        {
            private Action<object> action;
            private Func<bool> canFuncPerform;
            public event EventHandler CanExecuteChanged;
            public RelayCommand(Action<object> executeMethod)
            {
                action = executeMethod;
            }
            public RelayCommand(Action<object> executeMethod, Func<bool> canExecuteMethod)
            {
                action = executeMethod;
                canFuncPerform = canExecuteMethod;
            }
            public void RaiseCanExecuteChanged()
            {
                CanExecuteChanged(this, EventArgs.Empty);
            }
            public bool CanExecute(object parameter)
            {
                if (canFuncPerform != null)
                {
                    return canFuncPerform();
                }

                if (action != null)
                {
                    return true;
                }

                return false;
            }

            public void Execute(object parameter)
            {
                if (action != null)
                {
                    action(parameter);
                }
            }
        }

        /*

               public class RelayCommand : ICommand
        {
            readonly Action<object> _execute;
            readonly Predicate<object> _canExecute;

            #region Constructors

            /// <summary>
            /// Creates a new command.
            /// </summary>
            /// <param name="execute">The execution logic.</param>
            /// <param name="canExecute">The execution status logic.</param>
            public RelayCommand(Action<object> execute, Predicate<object> canExecute = null)
            {
                _execute = execute ?? throw new ArgumentNullException(nameof(execute));
                _canExecute = canExecute;
            }
            #endregion // Constructors

            #region ICommand Members
            [DebuggerStepThrough]
            public bool CanExecute(object parameter)
            {
                //For Vs 2015+ 
                return _canExecute?.Invoke(parameter) ?? true;
                //For Vs 2013-
                return _canExecute != null ? _canExecute.Invoke(parameter) : true;
            }

            /// <summary>
            /// Can execute changed event handler.
            /// </summary>
            public event EventHandler CanExecuteChanged
            {
                add => CommandManager.RequerySuggested += value;
                remove => CommandManager.RequerySuggested -= value;
            }

            public void Execute(object parameter)
            {
                _execute(parameter);
            }
            #endregion // ICommand Members
        }
        */
    }
}
