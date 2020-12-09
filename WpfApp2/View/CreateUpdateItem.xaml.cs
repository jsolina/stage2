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
using System.Windows;
using Domain.Contracts;
using Domain.Models;

namespace WpfApp2.View
{
    /// <summary>
    /// Interaction logic for CreateUpdateItem.xaml
    /// </summary>
    public partial class CreateUpdateItem : Window
    {

        TaskList taskListModel = new TaskList();
        Item itemModel = new Item();

        private IItem item;

        string updateOrAdd;

        public CreateUpdateItem(IItem _item, Item _itemModel, TaskList _taskListModel, string _updateOrAdd)
        {
            this.item = _item;

            InitializeComponent();
            updateOrAdd = _updateOrAdd;
            taskListModel = _taskListModel;

            //UpdateOrAddType.DataContext = new SelectedRow() { UpdateOrAdd = updateOrAdd + " Task" };

            if (updateOrAdd == "Update")
            {
                itemModel = _itemModel;
                name.Text = itemModel.ItemName;
                desc.Text = itemModel.ItemDetails;
                status.Text = itemModel.Status;
            }
        }

        private void Submit(object s, RoutedEventArgs e)
        {
            itemModel.ItemName = name.Text;
            itemModel.ItemDetails = desc.Text;
            itemModel.Status = status.Text;
            if (updateOrAdd == "Add")
            {
                itemModel.IdTask = taskListModel.Id;
                item.Create(itemModel);
                MessageBox.Show("Item has been Added", "Added");
            }
            /*
            if (updateOrAdd == "Update")
            {
                dbContext.Update(selectedRowItem);
                dbContext.SaveChanges();
                MessageBox.Show("Item has been Updated", "Updated");
            }
            */
            this.Close();
        }

    }
}
