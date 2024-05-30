using Beadando_Szalai_2404.Repository;
using Beadando_Szalai_2404.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Beadando_Szalai_2404.View
{
    /// <summary>
    /// Interaction logic for MenuItemWindow.xaml
    /// </summary>
    public partial class MenuItemWindow : Window
    {
        private MenuItemRepository menuitemRepository = null;
        private List<Model.MenuItem> selectMenuItems;
        private Op operation = Op.No;

        enum Op
        {
            Add, //INSERT
            Upd, //UPDATE
            No //Not set
        }
        public MenuItemWindow()
        {
            InitializeComponent();

            //Repository connect

            menuitemRepository = new MenuItemRepository(new RestaurantContext());

            //

            LoadIngredientsGrid();

            //Disable Boxes

            MenuItemNameTextBox.IsEnabled = false;
            PriceTextBox.IsEnabled = false;
            if (user.jogosultsag == "A")
            {
                New_Btn.Visibility = Visibility.Hidden;
                Save_Btn.Visibility = Visibility.Hidden;
                Update_Btn.Visibility = Visibility.Hidden;
                Delete_Btn.Visibility = Visibility.Hidden;
                MenuItemDataGrid.IsEnabled = false;
            }
        }

        private void LoadIngredientsGrid()
        {
            Cursor = Cursors.Wait;
            selectMenuItems = menuitemRepository.GetMenuItem();
            MenuItemDataGrid.ItemsSource = selectMenuItems;
            Cursor = Cursors.Arrow;
        }


        private void New_Btn_Click(object sender, RoutedEventArgs e)
        {
            MenuItemNameTextBox.IsEnabled = true;
            PriceTextBox.IsEnabled = true;
            MenuItemNameTextBox.Text = "";
            PriceTextBox.Text = "";
            operation = Op.Add;
            MenuItemNameTextBox.Focus();
        }

        private void Save_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (operation == Op.Add && MenuItemNameTextBox.Text != "" && PriceTextBox.Text != "")
            {
                menuitemRepository.InsertMenuItem(new Model.MenuItem
                {
                    ItemName = MenuItemNameTextBox.Text,
                    Price = PriceTextBox.Text,
                });

                menuitemRepository.Save();

                LoadIngredientsGrid();

                MenuItemNameTextBox.IsEnabled = false;
                PriceTextBox.IsEnabled = false;
                MenuItemNameTextBox.Text = "";
                PriceTextBox.Text = "";
                operation = Op.No;
                //set focus
                MenuItemNameTextBox.Focus();
            }

            else
            {
                MessageBox.Show("Operation is not INSERT or the required fields are empty.");
            }
        }

        private void Delete_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (operation == Op.Upd)
            {

                menuitemRepository.GetMenuItemById(selectMenuItems[MenuItemDataGrid.SelectedIndex].Id);
                menuitemRepository.DeleteMenuItems(selectMenuItems[MenuItemDataGrid.SelectedIndex].Id);
                menuitemRepository.Save();
                LoadIngredientsGrid();
                MenuItemNameTextBox.Text = "";
                PriceTextBox.Text = "";
                MenuItemNameTextBox.IsEnabled = false;
                PriceTextBox.IsEnabled = false;
                operation = Op.No;
            }
            else
            {
                MessageBox.Show("The Operation is not DELETE");
            }
        }

        private void dataGrid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (selectMenuItems.Count != 0 && MenuItemDataGrid.SelectedIndex < selectMenuItems.Count)
            {
                MenuItemNameTextBox.Text = selectMenuItems[MenuItemDataGrid.SelectedIndex].ItemName;
                PriceTextBox.Text = selectMenuItems[MenuItemDataGrid.SelectedIndex].Price;
                MenuItemNameTextBox.IsEnabled = true;
                PriceTextBox.IsEnabled = true;
                operation = Op.Upd;
            }
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Update_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (operation == Op.Upd)
            {
                Model.MenuItem menuitem_update = menuitemRepository.GetMenuItemById(selectMenuItems[MenuItemDataGrid.SelectedIndex].Id);
                menuitemRepository.GetMenuItemById(selectMenuItems[MenuItemDataGrid.SelectedIndex].Id);
                menuitem_update.ItemName = MenuItemNameTextBox.Text;
                menuitem_update.Price = PriceTextBox.Text;
                menuitemRepository.UpdateMenuItem(menuitem_update);
                menuitemRepository.Save();
                LoadIngredientsGrid();
                MenuItemNameTextBox.Text = "";
                PriceTextBox.Text = "";
                MenuItemNameTextBox.IsEnabled = false;
                PriceTextBox.IsEnabled = false;
                operation = Op.No;
            }
            else
            {
                MessageBox.Show("The Operation is not UPDATE");
            }
        }
    }
}
