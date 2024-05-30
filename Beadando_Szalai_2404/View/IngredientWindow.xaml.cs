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
    /// Interaction logic for IngredientWindow.xaml
    /// </summary>
    public partial class IngredientWindow : Window
    {
        private IngredientRepository ingredientRepository = null;
        private List<Ingredient> selectIngredients;
        private Op operation = Op.No;

        enum Op
        {
            Add, //INSERT
            Upd, //UPDATE
            No //Not set
        }
        public IngredientWindow()
        {
            InitializeComponent();

            //Repository connect

            ingredientRepository = new IngredientRepository(new RestaurantContext());

            //

            LoadIngredientsGrid();

            //Disable Boxes

            IngredientNameTextBox.IsEnabled = false;
            AmountTextBox.IsEnabled = false;

            if (user.jogosultsag == "A")
            {
                New_Btn.Visibility = Visibility.Hidden;
                Save_Btn.Visibility = Visibility.Hidden;
                Update_Btn.Visibility = Visibility.Hidden;
                Delete_Btn.Visibility = Visibility.Hidden;
                IngredientDataGrid.IsEnabled = false;
            }
        }

        private void LoadIngredientsGrid()
        {
            Cursor = Cursors.Wait;
            selectIngredients = ingredientRepository.GetIngredient();
            IngredientDataGrid.ItemsSource = selectIngredients;
            Cursor = Cursors.Arrow;
        }


        private void New_Btn_Click(object sender, RoutedEventArgs e)
        {
            IngredientNameTextBox.IsEnabled = true;
            AmountTextBox.IsEnabled = true;
            IngredientNameTextBox.Text = "";
            AmountTextBox.Text = "";
            operation = Op.Add;
            IngredientNameTextBox.Focus();
        }

        private void Save_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (operation == Op.Add && IngredientNameTextBox.Text != "" && AmountTextBox.Text != "")
            {
                ingredientRepository.InsertIngredient(new Ingredient
                {
                    IngredientName = IngredientNameTextBox.Text,
                    Amount = AmountTextBox.Text,
                });

                ingredientRepository.Save();

                LoadIngredientsGrid();

                IngredientNameTextBox.IsEnabled = false;
                AmountTextBox.IsEnabled = false;
                IngredientNameTextBox.Text = "";
                AmountTextBox.Text = "";
                operation = Op.No;
                //set focus
                IngredientNameTextBox.Focus();
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

                ingredientRepository.GetIngredientsById(selectIngredients[IngredientDataGrid.SelectedIndex].Id);
                ingredientRepository.DeleteIngredients(selectIngredients[IngredientDataGrid.SelectedIndex].Id);
                ingredientRepository.Save();
                LoadIngredientsGrid();
                IngredientNameTextBox.Text = "";
                AmountTextBox.Text = "";
                IngredientNameTextBox.IsEnabled = false;
                AmountTextBox.IsEnabled = false;
                operation = Op.No;
            }
            else
            {
                MessageBox.Show("The Operation is not DELETE");
            }
        }

        private void dataGrid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (selectIngredients.Count != 0 && IngredientDataGrid.SelectedIndex < selectIngredients.Count)
            {
                IngredientNameTextBox.Text = selectIngredients[IngredientDataGrid.SelectedIndex].IngredientName;
                AmountTextBox.Text = selectIngredients[IngredientDataGrid.SelectedIndex].Amount;
                IngredientNameTextBox.IsEnabled = true;
                AmountTextBox.IsEnabled = true;
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
                Ingredient ingredient_update = ingredientRepository.GetIngredientsById(selectIngredients[IngredientDataGrid.SelectedIndex].Id);
                ingredientRepository.GetIngredientsById(selectIngredients[IngredientDataGrid.SelectedIndex].Id);
                ingredient_update.IngredientName = IngredientNameTextBox.Text;
                ingredient_update.Amount = AmountTextBox.Text;
                ingredientRepository.UpdateIngredient(ingredient_update);
                ingredientRepository.Save();
                LoadIngredientsGrid();
                IngredientNameTextBox.Text = "";
                AmountTextBox.Text = "";
                IngredientNameTextBox.IsEnabled = false;
                AmountTextBox.IsEnabled = false;
                operation = Op.No;
            }
            else
            {
                MessageBox.Show("The Operation is not UPDATE");
            }
        }
    }
}
