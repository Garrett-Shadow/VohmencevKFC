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
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Page
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private void AuthorizeButton_Click(object sender, RoutedEventArgs e)
        {
            if (Pages.Connector.Authorize(LoginText.Text, PasswordText.Password) == true)
            {
                var profile = Pages.Connector.GetMyProfile();
                if (profile == null)
                {
                    MessageBox.Show("Ошибка авторизации");
                    return;
                }

                var userRole = profile.Position;

                switch (userRole)
                {
                    case "Администратор":
                        NavigationService.Navigate(Pages.PageClass.GetAdministrator());
                        break;
                    case "Повар":
                        NavigationService.Navigate(Pages.PageClass.GetMainPage());
                        break;
                    default: return;
                }
            }
            else
            {
                MessageBox.Show("Неверный логин/пароль");
            }
        }
    }
}
