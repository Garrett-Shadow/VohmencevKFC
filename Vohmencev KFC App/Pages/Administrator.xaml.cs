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

namespace Vohmencev_KFC_App.Pages
{
    /// <summary>
    /// Логика взаимодействия для Administrator.xaml
    /// </summary>
    public partial class Administrator : Page
    {
        private Database.Vohmencev_KFCEntities Connection;
        public Database.Staff SelectedEmployee { get; set; }
        public Database.Ingridients SelectedIngridient { get; set; }
        public List<Database.Staff> Employees { get; set; }
        public List<Database.Ingridients> AllIngredients { get; set; }
        public List<Database.Ingridients> DishRecipe { get; set; }
        public List<Database.Positions> Roles { get; set; }
        public List<Database.DishType> DishTypes { get; set; }
        private HashSet<Database.Ingridients> IngredientsHashSet { set; get; }
        private HashSet<Database.Recipe> RecipeHashSet { set; get; }


        public Administrator()
        {
            InitializeComponent();
            Connection = Pages.Connector.GetModel();
            IngredientsHashSet = new HashSet<Database.Ingridients>();
            RecipeHashSet = new HashSet<Database.Recipe>();
            Roles = Connection.Positions.ToList();
            RoleCombo.ItemsSource = Roles;
            DishTypes = Connection.DishType.ToList();
            DishTypeCombo.ItemsSource = DishTypes;
            DataContext = this;
            StaffListUpdate();
            IngridientListUpdate();
        }

        //Управление сотрудниками

        private void StaffAddButton_Click(object sender, RoutedEventArgs e)
        {
            if (StaffLogin == null || StaffPassword == null || StaffNameText == null || RoleCombo.SelectedIndex == -1)
            {
                MessageBox.Show("Не все поля заполнены!");
                return;
            }
            var NewEmployee = new Database.Staff();
            NewEmployee.StaffLogin = StaffLogin.Text.Trim();
            NewEmployee.StaffPassword = StaffPassword.Text.Trim();
            NewEmployee.FullName = StaffNameText.Text.ToString();
            NewEmployee.Position = (RoleCombo.SelectedItem as Database.Positions).PositionName;
            Connection.Staff.Add(NewEmployee);
            Connection.SaveChanges();
            StaffListUpdate();
            StaffNameText.Text = "";
            StaffLogin.Text = "";
            StaffPassword.Text = "";
            RoleCombo.SelectedIndex = -1;
            SelectedEmployee = null;
            MessageBox.Show("Новый сотрудник успешно добавлен!");
        }

        private void StaffRefreshButton_Click(object sender, RoutedEventArgs e)
        {
            if (StaffLogin == null || StaffPassword == null || StaffNameText == null || RoleCombo.SelectedIndex == -1)
            {
                MessageBox.Show("Не все поля заполнены!");
                return;
            }
            Connection.SaveChanges();
            MessageBox.Show("Данные сотрудника успешно обновлены!");
        }

        private void StaffDropButton_Click(object sender, RoutedEventArgs e)
        {
            StaffAddButton.IsEnabled = true;
            StaffRefreshButton.IsEnabled = false;
            StaffDropButton.IsEnabled = false;
            StaffList.SelectedIndex = -1;
            StaffNameText.Text = "";
            StaffLogin.Text = "";
            StaffPassword.Text = "";
            RoleCombo.SelectedIndex = -1;
            SelectedEmployee = null;
            StaffBindingUpdate();
        }

        private void StaffListUpdate()
        {
            Employees = Connection.Staff.OrderBy(emp => new { emp.FullName }).ToList();
            StaffList.ItemsSource = Employees;
        }

        private void StaffListSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (StaffList.SelectedIndex != -1)
            {
                StaffAddButton.IsEnabled = false;
                StaffRefreshButton.IsEnabled = true;
                StaffDropButton.IsEnabled = true;
                SelectedEmployee = StaffList.SelectedItem as Database.Staff;
                StaffBindingUpdate();
            }
            else
            {
                StaffAddButton.IsEnabled = true;
                StaffRefreshButton.IsEnabled = false;
                StaffDropButton.IsEnabled = false;
                StaffList.SelectedIndex = -1;
                StaffNameText.Text = "";
                StaffLogin.Text = "";
                StaffPassword.Text = "";
                RoleCombo.SelectedIndex = -1;
                SelectedEmployee = null;
                StaffBindingUpdate();
            }
        }

        private void StaffBindingUpdate()
        {
            StaffNameText.GetBindingExpression(TextBox.TextProperty)?.UpdateTarget();
            StaffLogin.GetBindingExpression(TextBox.TextProperty)?.UpdateTarget();
            StaffPassword.GetBindingExpression(TextBox.TextProperty)?.UpdateTarget();
            RoleCombo.GetBindingExpression(ComboBox.SelectedItemProperty)?.UpdateTarget();
        }

        //Добавление блюд

        private void DishSaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (DishNameText == null)
            {
                MessageBox.Show("Необходимо ввести название!");
                return;
            }
            if (DishTypeCombo.SelectedIndex == -1)
            {
                MessageBox.Show("Необходимо выбрать категорию!");
                return;
            }
            if (DishPriceText == null)
            {
                MessageBox.Show("Необходимо ввести цену!");
                return;
            }
            string NewDishName = DishNameText.Text.ToString();
            decimal NewPrice = 0;
            if (decimal.TryParse(DishPriceText.Text.Trim(), out NewPrice) == false)
            {
                MessageBox.Show("Некорректно введена цена");
                return;
            }
            Database.Dishes NewDish = new Database.Dishes();
            NewDish.DishName = NewDishName;
            NewDish.DishType = (DishTypeCombo.SelectedItem as Database.DishType).TypeName;
            NewDish.Price = NewPrice;
            Connection.Dishes.Add(NewDish);
            foreach (var Item in RecipeHashSet)
            {
                Item.Dish = NewDishName;
                Connection.Recipe.Add(Item);
            }
            Connection.SaveChanges();
            DishNameText.Text = "";
            DishPriceText.Text = "";
            DishTypeCombo.SelectedIndex = -1;
            DishRecipe = new List<Database.Ingridients>();
            DishRecipeList.GetBindingExpression(ListBox.ItemsSourceProperty)?.UpdateTarget();
            MessageBox.Show("Новое блюдо и его рецепт успешно добавлены!");
        }

        private void DishDropButton_Click(object sender, RoutedEventArgs e)
        {
            DishNameText.Text = "";
            DishPriceText.Text = "";
            DishTypeCombo.SelectedIndex = -1;
            DishRecipe = new List<Database.Ingridients>();
            DishRecipeList.GetBindingExpression(ListBox.ItemsSourceProperty)?.UpdateTarget();

        }

        private void IngridientListUpdate()
        {
            AllIngredients = Connection.Ingridients.OrderBy(ing => ing.IngridientName).ToList();
            DishesIngridientsList.ItemsSource = AllIngredients;
            IngridientList.ItemsSource = AllIngredients;
            DishesIngridientsList.GetBindingExpression(ListBox.ItemsSourceProperty)?.UpdateTarget();
            IngridientList.GetBindingExpression(ListBox.ItemsSourceProperty)?.UpdateTarget();
        }

        private void DishesIngridientsListSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var SelectedDishIngredient = DishesIngridientsList.SelectedItem as Database.Ingridients;
            if (SelectedDishIngredient != null)
            {
                IngredientsHashSet.Add(SelectedDishIngredient);
                DishRecipe = IngredientsHashSet.ToList();
                RecipeHashSet.Add(new Database.Recipe() { Ingridients = SelectedDishIngredient });
                DishRecipeList.GetBindingExpression(ListBox.ItemsSourceProperty)?.UpdateTarget();
            }
            DishesIngridientsList.SelectedIndex = -1;
        }

        private void DishRecipeListSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var SelectedDishIngredient = DishRecipeList.SelectedItem as Database.Ingridients;
            if (SelectedDishIngredient != null)
            {
                IngredientsHashSet.Remove(SelectedDishIngredient);
                DishRecipe = IngredientsHashSet.ToList();
                RecipeHashSet.Remove(new Database.Recipe() { Ingridients = SelectedDishIngredient });
                DishRecipeList.GetBindingExpression(ListBox.ItemsSourceProperty)?.UpdateTarget();
            }
            DishRecipeList.SelectedIndex = -1;
        }

        //Управление ингридиентами

        private void IngridientAddButton_Click(object sender, RoutedEventArgs e)
        {
            if (IngridientNameText == null)
            {
                MessageBox.Show("Не все поля заполнены!");
                return;
            }
            var NewIngridient = new Database.Ingridients();
            NewIngridient.IngridientName = IngridientNameText.Text.ToString();
            Connection.Ingridients.Add(NewIngridient);
            Connection.SaveChanges();
            IngridientListUpdate();
            IngridientNameText.Text = "";
            SelectedIngridient = null;
            MessageBox.Show("Новый ингридиент успешно добавлен!");
        }

        private void IngridientRefreshButton_Click(object sender, RoutedEventArgs e)
        {
            if (IngridientNameText == null)
            {
                MessageBox.Show("Не все поля заполнены!");
                return;
            }
            Connection.SaveChanges();
            MessageBox.Show("Данные об ингридиенте успешно обновлены!");
        }

        private void IngridientDropButton_Click(object sender, RoutedEventArgs e)
        {
            IngridientAddButton.IsEnabled = true;
            IngridientRefreshButton.IsEnabled = false;
            IngridientDropButton.IsEnabled = false;
            StaffList.SelectedIndex = -1;
            IngridientNameText.Text = "";
            SelectedIngridient = null;
            IngridientsBindingUpdate();
        }
        private void IngridientListSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (IngridientList.SelectedIndex != -1)
            {
                IngridientAddButton.IsEnabled = false;
                IngridientRefreshButton.IsEnabled = true;
                IngridientDropButton.IsEnabled = true;
                SelectedIngridient = IngridientList.SelectedItem as Database.Ingridients;
                IngridientsBindingUpdate();
            }
            else
            {
                IngridientAddButton.IsEnabled = true;
                IngridientRefreshButton.IsEnabled = false;
                IngridientDropButton.IsEnabled = false;
                StaffList.SelectedIndex = -1;
                IngridientNameText.Text = "";
                SelectedIngridient = null;
                IngridientsBindingUpdate();
            }
        }

        private void IngridientsBindingUpdate()
        {
            IngridientNameText.GetBindingExpression(TextBox.TextProperty)?.UpdateTarget();
        }
    }
}
