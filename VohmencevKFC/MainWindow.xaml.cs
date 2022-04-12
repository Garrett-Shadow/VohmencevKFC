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

namespace VohmencevKFC
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadOrders();
        }

        //Список заказов
        void LoadOrders()
        {
            Database.Vohmencev_KFCEntities Connection = new Database.Vohmencev_KFCEntities();
            var Orders = Connection.OrderContent.ToList();
            foreach (var dishes in Orders)
            {
                if (dishes.DishStatus == "Готовится, ожидайте")
                {
                    OrdersList.Items.Add(dishes.Dishes.DishName);
                }

            }
        }

        //Кнопка ВЫБРАТЬ
        private void OrdersStartButton_Click(object sender, RoutedEventArgs e)
        {
            Database.Vohmencev_KFCEntities Connection = new Database.Vohmencev_KFCEntities();
            if (DishNameLabel.Content != "")
            {
                MessageBox.Show(DishNameLabel.Content + " уже готовится!");
            }
            else
            {
                string dish;
                var Recipe = Connection.Recipe.ToList();
                RecipeList.Items.Clear();
                if (OrdersList.SelectedIndex != -1)
                {
                    dish = this.OrdersList.SelectedItem.ToString();
                    DishNameLabel.Content = this.OrdersList.SelectedItem.ToString();
                    OrdersList.Items.RemoveAt(OrdersList.SelectedIndex);
                    foreach (var ingridients in Recipe)
                    {
                        if (dish == ingridients.Dishes.DishName)
                        {
                            RecipeList.Items.Add(ingridients.Ingridients.IngridientName);
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
            Database.Vohmencev_KFCEntities Connection = new Database.Vohmencev_KFCEntities();
            if (DishNameLabel.Content == "")
            {
                MessageBox.Show("Ничего не готовится!");
            }
            else
            {
                DishNameLabel.Content = "";
                RecipeList.Items.Clear();
                Database.OrderContent ready = new Database.OrderContent();
                ready.DishStatus = "Готово к выдаче";
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
                var cancel = DishNameLabel.Content;
                OrdersList.Items.Add(cancel.ToString());
                DishNameLabel.Content = "";
                RecipeList.Items.Clear();
                MessageBox.Show("Блюдо отменено!");
            }
        }
    }
}
