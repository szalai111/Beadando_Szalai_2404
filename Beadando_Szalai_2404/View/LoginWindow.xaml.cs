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
using Beadando_Szalai_2404.View;
using System.Windows.Controls.Primitives;

namespace Beadando_Szalai_2404.View
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private EmployeeRepository loginRepository = null;
        private List<Employee> selectEmployees;
        public LoginWindow()
        {
            loginRepository = new EmployeeRepository(new RestaurantContext());
            InitializeComponent();
            selectEmployees = loginRepository.GetEmployees();
        }

        private void register_btn_Click(object sender, RoutedEventArgs e)
        {
            Register regisztarciosablak = new Register();
            regisztarciosablak.ShowDialog();
        }

        private void login_btn_Click(object sender, RoutedEventArgs e)
        {
            selectEmployees = loginRepository.GetEmployees();
            Employee login = loginRepository.GetEmployeeByName(Login_textBox.Text);
            if (login != null) 
            {
                if (login.Password == Login_passwordBox.Password)
                {
                    MessageBox.Show("Sikeres bejelenkezés!");
                    user.jogosultsag = login.Access;
                    //MainWindow menu = new MainWindow();
                    //menu.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Hibás jelszó");
                }
            }
            else
            {
                MessageBox.Show("Hibás felhasználónév");
            }
        }
    }
}
