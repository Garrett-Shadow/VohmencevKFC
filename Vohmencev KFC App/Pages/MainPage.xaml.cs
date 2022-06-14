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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void ClientButton_Click(object sender, RoutedEventArgs e)
        {
            AppLabel.Visibility = Visibility.Collapsed;
            AppLogo.Visibility = Visibility.Collapsed;
            ClientButton.Visibility = Visibility.Collapsed;
            StaffButton.Visibility = Visibility.Collapsed;
            NavigationService.Navigate(Pages.PageClass.GetClient());
        }

        private void StaffButton_Click(object sender, RoutedEventArgs e)
        {
            AppLabel.Visibility = Visibility.Collapsed;
            AppLogo.Visibility = Visibility.Collapsed;
            ClientButton.Visibility = Visibility.Collapsed;
            StaffButton.Visibility = Visibility.Collapsed;
            NavigationService.Navigate(Pages.PageClass.GetKitchenStaff());
        }
    }
}
