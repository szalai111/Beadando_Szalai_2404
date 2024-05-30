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
using Org.BouncyCastle.Asn1.X509;
using System.Reflection.Metadata.Ecma335;

namespace Beadando_Szalai_2404.View
{
    /// <summary>
    /// Interaction logic for EmployeeWindow.xaml
    /// </summary>
    public partial class EmployeeWindow : Window
    {
        private EmployeeRepository employeeRepository = null;
        private List<Employee> selectEmployees;
        private Op operation = Op.No;

        enum Op
        {
            Add, //INSERT
            Upd, //UPDATE
            No //Not set
        }
        public EmployeeWindow()
        {
            InitializeComponent();

            //Repository connect

            employeeRepository = new EmployeeRepository(new RestaurantContext());

            //

            LoadEmployeesGrid();

            //Disable Boxes

            NameTextBox.IsEnabled = false;
            SalaryTextBox.IsEnabled = false;

            if (user.jogosultsag == "A")
            {
                New_Btn.Visibility = Visibility.Hidden;
                Save_Btn.Visibility = Visibility.Hidden;
                Update_Btn.Visibility = Visibility.Hidden;
                Delete_Btn.Visibility = Visibility.Hidden;
                EmployeeDataGrid.IsEnabled = false;
            }
        }

        private void LoadEmployeesGrid()
        {
            Cursor = Cursors.Wait;
            selectEmployees = employeeRepository.GetEmployees();
            EmployeeDataGrid.ItemsSource = selectEmployees;
            Cursor = Cursors.Arrow;
        }


        private void New_Btn_Click(object sender, RoutedEventArgs e)
        {
            NameTextBox.IsEnabled = true;
            SalaryTextBox.IsEnabled = true;
            NameTextBox.Text = "";
            SalaryTextBox.Text = "";
            operation = Op.Add;
            NameTextBox.Focus();
        }

        private void Save_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (operation == Op.Add && NameTextBox.Text != "" && SalaryTextBox.Text != "")
            {
                employeeRepository.InsertEmployee(new Employee
                {
                    Name = NameTextBox.Text,
                    Salary = SalaryTextBox.Text,
                    Password = "BasePassword",
                    Access = "0"
                    
                });

                employeeRepository.Save();

                LoadEmployeesGrid();

                NameTextBox.IsEnabled = false;
                SalaryTextBox.IsEnabled = false;
                NameTextBox.Text = "";
                SalaryTextBox.Text = "";
                operation = Op.No;
                //set focus
                NameTextBox.Focus();
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

                employeeRepository.GetEmployeesById(selectEmployees[EmployeeDataGrid.SelectedIndex].Id);
                employeeRepository.DeleteEmployees(selectEmployees[EmployeeDataGrid.SelectedIndex].Id);
                employeeRepository.Save();
                LoadEmployeesGrid();
                NameTextBox.Text = "";
                SalaryTextBox.Text = "";
                NameTextBox.IsEnabled = false;
                SalaryTextBox.IsEnabled = false;
                operation = Op.No;
            }
            else
            {
                MessageBox.Show("The Operation is not DELETE");
            }
        }

        private void dataGrid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (selectEmployees.Count != 0 && EmployeeDataGrid.SelectedIndex < selectEmployees.Count)
            {
                NameTextBox.Text = selectEmployees[EmployeeDataGrid.SelectedIndex].Name;
                SalaryTextBox.Text = selectEmployees[EmployeeDataGrid.SelectedIndex].Salary;
                NameTextBox.IsEnabled = true;
                SalaryTextBox.IsEnabled = true;
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
                Employee employee_update = employeeRepository.GetEmployeesById(selectEmployees[EmployeeDataGrid.SelectedIndex].Id);
                employeeRepository.GetEmployeesById(selectEmployees[EmployeeDataGrid.SelectedIndex].Id);
                employee_update.Name = NameTextBox.Text;
                employee_update.Salary = SalaryTextBox.Text;
                employeeRepository.UpdateEmployee(employee_update);
                employeeRepository.Save();
                LoadEmployeesGrid();
                NameTextBox.Text = "";
                SalaryTextBox.Text = "";
                NameTextBox.IsEnabled = false;
                SalaryTextBox.IsEnabled = false;
                operation = Op.No;
            }
            else
            {
                MessageBox.Show("The Operation is not UPDATE");
            }
        }
    }
}
