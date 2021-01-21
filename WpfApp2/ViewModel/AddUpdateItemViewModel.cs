using Domain.Contracts;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using WpfApp2.Commnds;

namespace WpfApp2.ViewModel
{
    public class AddUpdateItemViewModel : INotifyPropertyChanged
    {
        IItem dbContext;
        TaskListModel selectedRowTask = new TaskListModel();
        public ItemModel itemModels = new ItemModel();
        public ItemModelSelected itemModelSelected = new ItemModelSelected();

        //Command binding property for Button Click
        public SubmitCommandBinding SubmitClick { get; set; }

        string updateOrAdd;

        public AddUpdateItemViewModel(IItem _dbContext, TaskListModel _selectedRowTask, ItemModel _ItemModel, string _updateOrAdd)
        {
            SubmitClick = new SubmitCommandBinding(ShowMessage);
            SubmitClick.IsEnabled = true;

            this.dbContext = _dbContext;

            ItemModels = _ItemModel;
            selectedRowTask = _selectedRowTask;

            //gumamit ako ng panibagong model para hindi mag autoBind
            //pag ginamit ko kasi yung 'TaskListModels' para sa selectedRow ko, nag chachange yung dataValue sa DataGrid kahit hindi pa nag ttrigger uupdate
            ItemModelSelecteds.ItemName = ItemModels.ItemName;
            ItemModelSelecteds.ItemDetails = ItemModels.ItemDetails;
            ItemModelSelecteds.Status = ItemModels.Status;

            updateOrAdd = _updateOrAdd;
        }

        public ItemModel ItemModels
        {
            get { return itemModels; }
            set
            {
                itemModels = value;
                NotifyPropertyChanged("ItemModels");
            }
        }

        public ItemModelSelected ItemModelSelecteds
        {
            get { return itemModelSelected; }
            set
            {
                itemModelSelected = value;
                NotifyPropertyChanged("ItemModelSelecteds");
            }
        }

        /// <summary>
        /// Method to be called when property(value) is changed
        /// </summary>
        /// <param name="propertyName"></param>
        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        /// <summary>
        /// Property changed Event 
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;


        /// <summary>
        /// Actual method for display
        /// for button click event
        /// </summary>
        private void ShowMessage()
        {
            //change value to give notification of the click
            NotifyPropertyChanged("ItemModels");

            if (ItemModelSelecteds.ItemName != null)
            {
                ItemModels.ItemName = ItemModelSelecteds.ItemName;
                ItemModels.ItemDetails = ItemModelSelecteds.ItemDetails;
                ItemModels.Status = ItemModelSelecteds.Status;

                if (updateOrAdd == "Update")
                {
                    dbContext.Update(ItemModels);
                    MessageBox.Show("Item has been Updated", "Updated", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    ItemModels.IdTask = selectedRowTask.Id;
                    dbContext.Create(ItemModels);
                    MessageBox.Show("Item has been Added", "Added", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Item Name cannot be null/empty", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

    }
}
