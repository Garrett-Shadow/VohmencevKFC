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

namespace Vohmencev_KFC_App
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StaffButton_Click(object sender, RoutedEventArgs e)
        {
            AppLabel.Visibility = Visibility.Collapsed;
            AppLogo.Visibility = Visibility.Collapsed;
            ClientButton.Visibility = Visibility.Collapsed;
            StaffButton.Visibility = Visibility.Collapsed;
            //ClientButton_Copy.Visibility = Visibility.Visible;
            //StaffButton_Copy.Visibility = Visibility.Visible;
            MainFrame.NavigationService.Navigate(Pages.PageClass.staff);
        }

        private void ClientButton_Click(object sender, RoutedEventArgs e)
        {
            AppLabel.Visibility = Visibility.Collapsed;
            AppLogo.Visibility = Visibility.Collapsed;
            ClientButton.Visibility = Visibility.Collapsed;
            StaffButton.Visibility = Visibility.Collapsed;
            //ClientButton_Copy.Visibility = Visibility.Visible;
            //StaffButton_Copy.Visibility = Visibility.Visible;
            MainFrame.NavigationService.Navigate(Pages.PageClass.client);
        }
    }
}
