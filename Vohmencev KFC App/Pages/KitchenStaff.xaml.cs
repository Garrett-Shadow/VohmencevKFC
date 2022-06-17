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
    /// Логика взаимодействия для KitchenStaff.xaml
    /// </summary>
    public partial class KitchenStaff : Page
    {
        Database.Vohmencev_KFCEntities Connection = new Database.Vohmencev_KFCEntities();
        public KitchenStaff()
        {
            InitializeComponent();
            LoadOrders();
        }

        //Список заказов
        void LoadOrders()
        {
            var Orders = Connection.OrderContent.ToList();
            foreach (var Dishes in Orders)
            {
                if (Dishes.DishStatus == "Готовится, ожидайте")
                {
                    OrdersList.Items.Add(Dishes.Dish);
                }
            }
        }

        //Кнопка ВЫБРАТЬ
        private void OrdersStartButton_Click(object sender, RoutedEventArgs e)
        {
            if (DishNameLabel.Content != "")
            {
                MessageBox.Show(DishNameLabel.Content + " уже готовится!");
            }
            else
            {
                var Recipe = Connection.Recipe.ToList();
                RecipeList.Items.Clear();
                if (OrdersList.SelectedIndex != -1)
                {
                    string Dish = this.OrdersList.SelectedItem.ToString();
                    DishNameLabel.Content = this.OrdersList.SelectedItem.ToString();
                    OrdersList.Items.RemoveAt(OrdersList.SelectedIndex);
                    foreach (var Ingridients in Recipe)
                    {
                        if (Dish == Ingridients.Dishes.DishName)
                        {
                            RecipeList.Items.Add(Ingridients.Ingridients.IngridientName);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Выберите блюдо!");
                }
            }
        }

        //Кнопка ГОТОВО
        private void ReadyButton_Click(object sender, RoutedEventArgs e)
        {
            if (DishNameLabel.Content == "")
            {
                MessageBox.Show("Ничего не готовится!");
            }
            else
            {
                Database.OrderContent DishReady = new Database.OrderContent();
                DishReady.DishStatus = "Готово к выдаче";
                Connection.SaveChanges();
                DishNameLabel.Content = "";
                RecipeList.Items.Clear();
                MessageBox.Show("Блюдо готово!");
            }
        }

        //Кнопка ОТМЕНА
        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (DishNameLabel.Content == "")
            {
                MessageBox.Show("Ничего не готовится!");
            }
            else
            {
                var Cancel = DishNameLabel.Content;
                OrdersList.Items.Add(Cancel.ToString());
                DishNameLabel.Content = "";
                RecipeList.Items.Clear();
                MessageBox.Show("Блюдо отменено!");
            }
        }

        private void StaffBackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.PageClass.GetMainPage());
        }
    }
}
