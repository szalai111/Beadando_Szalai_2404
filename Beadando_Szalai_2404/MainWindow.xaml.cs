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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Beadando_Szalai_2404.Model;
using Beadando_Szalai_2404.View;
using Mysqlx.Cursor;

namespace Beadando_Szalai_2404
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            if (user.jogosultsag == null)
            {
                LoginWindow bejelentkezoabalk = new LoginWindow();
                bejelentkezoabalk.ShowDialog();
            }
            else
            {
                this.Hide();
            }
        }

        private void Employees_Btn_Click(object sender, RoutedEventArgs e)
        {
            EmployeeWindow employeeWindow = new EmployeeWindow();
            employeeWindow.ShowDialog();
        }

        private void MenuItems_Btn_Click(object sender, RoutedEventArgs e)
        {
            MenuItemWindow menuitemWindow = new MenuItemWindow();
            menuitemWindow.ShowDialog();
        }

        private void Ingredients_Btn_Click(object sender, RoutedEventArgs e)
        {
            IngredientWindow ingredientWindow = new IngredientWindow();
            ingredientWindow.ShowDialog();
        }
    }
}
