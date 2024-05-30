using System;
using System.Collections.Generic;
using System.Linq;
using Beadando_Szalai_2404.Repository;
using Beadando_Szalai_2404.Model;
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
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        private RegisterRepository registerRepository = null;
        private Op operation = Op.Add;

        enum Op
        {
            Add, //INSERT
            Upd, //UPDATE
            No //Not set
        }
        public Register()
        {
            InitializeComponent();

            registerRepository = new RegisterRepository(new RestaurantContext());

            //Emlékeztető jelszó megadására admin fiók létrehozása esetén
        }

        private void Register_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (operation == Op.Add && Employee_name_textBox.Text != "" && Salary_textBox.Text != "" && Register_passwordBox.Password != "" && user_rights_comboBox.Text != "")
            {
                registerRepository.InsertEmployeeRegister(new Employee
                {
                    Name = Employee_name_textBox.Text,
                    Salary = Salary_textBox.Text,
                    Password = Register_passwordBox.Password,
                    Access = user_rights_comboBox.Text
                });

                registerRepository.Save();
                this.Close();
            }

            else
            {
                MessageBox.Show("Nem töltött ki adatokat vagy helytelen adatokat adott meg.");
            }
        }
    }
}
