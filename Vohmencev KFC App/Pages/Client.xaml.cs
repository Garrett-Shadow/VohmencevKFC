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
    /// Логика взаимодействия для Client.xaml
    /// </summary>
    public partial class Client : Page
    {
        Database.Vohmencev_KFCEntities Connection = new Database.Vohmencev_KFCEntities();
        double CartSum;

        public Client()
        {
            InitializeComponent();
            LoadMenu();
        }

        public void LoadMenu()
        {
            var Menu = Connection.Dishes.ToList();
            foreach (var Dishes in Menu)
            {
                MenuList.Items.Add(Dishes.DishName);
            }
        }

        //Кнопка ДОБАВИТЬ В КОРЗИНУ
        private void MenuAddButton_Click(object sender, RoutedEventArgs e)
        {
            var Dishes = Connection.Dishes.ToList();
            if (MenuList.SelectedIndex != -1)
            {
                string Dish = this.MenuList.SelectedItem.ToString();
                ShoppingCartList.Items.Add(Dish);
                foreach (var DishesPrice in Dishes)
                {
                    if (Dish == DishesPrice.DishName)
                    {
                        double Price = Convert.ToDouble(DishesPrice.Price);
                        CartSum = CartSum + Price;
                        CartSumLabel.Content = "Сумма: " + CartSum.ToString() + " руб.";
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите блюдо!");
            }
        }

        //Кнопка СДЕЛАТЬ ЗАКАЗ
        private void CartReadyButton_Click(object sender, RoutedEventArgs e)
        {
            if (ShoppingCartList.Items.Count < 0)
            {
                MessageBox.Show("Корзина пуста!");
            }
            else
            {
                Database.Orders NewOrder = new Database.Orders();
                int NewPaycheck;
                string NewStatus = "Готовится, ожидайте";
                var LastOrder = Connection.Orders.OrderBy(o => o.OrderPaycheck).ToList().LastOrDefault();
                if (LastOrder == null)
                {
                    NewPaycheck = 1;
                }
                else
                {
                    NewPaycheck = LastOrder.OrderPaycheck + 1;
                }
                NewOrder.OrderPaycheck = NewPaycheck;
                NewOrder.OrderDate = DateTime.Today;
                NewOrder.OrderStatus = NewStatus;
                Connection.Orders.Add(NewOrder);
                Database.OrderContent NewOrdersContent = new Database.OrderContent();
                NewOrdersContent.Paycheck = NewPaycheck;
                NewOrdersContent.Dish = ShoppingCartList.Items.ToString();
                NewOrdersContent.DishStatus = NewStatus;
                Connection.OrderContent.Add(NewOrdersContent);
                Connection.SaveChanges();
                ShoppingCartList.Items.Clear();
                MessageBox.Show("Благодарим вас за заказ!");
            }
        }

        //Кнопка УБРАТЬ ИЗ КОРЗИНЫ
        private void CartRemoveButton_Click(object sender, RoutedEventArgs e)
        {
            var Dishes = Connection.Dishes.ToList();
            if (ShoppingCartList.SelectedIndex != -1)
            {
                string Dish = this.ShoppingCartList.SelectedItem.ToString();
                foreach (var DishesPrice in Dishes)
                {
                    if (Dish == DishesPrice.DishName)
                    {
                        double Price = Convert.ToDouble(DishesPrice.Price);
                        CartSum = CartSum - Price;
                        CartSumLabel.Content = "Сумма: " + CartSum.ToString() + " руб.";
                    }
                }
                this.ShoppingCartList.Items.RemoveAt(this.ShoppingCartList.SelectedIndex);
                MessageBox.Show("Блюдо убрано из корзины!");
            }
            else
            {
                MessageBox.Show("Выберите блюдо, которое хотите убрать!");
            }
        }
    }
}
