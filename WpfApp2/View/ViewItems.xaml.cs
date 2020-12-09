using Domain.Contracts;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace WpfApp2.View
{
    /// <summary>
    /// Interaction logic for ViewItems.xaml
    /// </summary>
    public partial class ViewItems : Window
    {
        TaskList taskListModel = new TaskList();
        Domain.Models.Item itemModel = new Domain.Models.Item();
        private IItem item;

        public ViewItems(IItem _item, TaskList _taskListModel)
        {
            InitializeComponent();
            this.item = _item;

            taskListModel = _taskListModel;

            headerItemName.Text = "Item List of Task: '" + taskListModel.Name + "'";

            GetItems();
        }

        private void GetItems()
        {
            ItemDG.ItemsSource = item.FindByFK(taskListModel.Id);
        }

        private void Add(object s, RoutedEventArgs e)
        {
            CreateUpdateItem cuo = new CreateUpdateItem(item, null, taskListModel, "Add");
            cuo.ShowDialog();
            GetItems();
        }

        private void Update(object s, RoutedEventArgs e)
        {
            itemModel = (s as FrameworkElement).DataContext as Item;
            CreateUpdateItem cuo = new CreateUpdateItem(item, itemModel, taskListModel, "Update");
            cuo.ShowDialog();
            GetItems();
        }

        private void Delete(object s, RoutedEventArgs e)
        {
            var rowToBeDeleted = (s as FrameworkElement).DataContext as Item;
            item.Remove(rowToBeDeleted);
            GetItems();
            MessageBox.Show(rowToBeDeleted.ItemName + " has been Deleted", "Item Deleted!");
        }
    }
}
