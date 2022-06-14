using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vohmencev_KFC_App.Pages
{
    public static class PageClass
    {
        public static Client client;
        public static KitchenStaff staff;
        private static Authorization authorization;
        private static SuperUserRegistration superuserregistration;
        private static Administrator administrator;
        private static MainPage mainpage;

        public static Authorization GetAuthorization()
        {
            if (authorization == null)
            {
                authorization = new Authorization();
            }
            return authorization;
        }

        public static SuperUserRegistration GetSuperUserRegistration()
        {
            if (superuserregistration == null)
            {
                superuserregistration = new SuperUserRegistration();
            }

            return superuserregistration;
        }

        public static Administrator GetAdministrator()
        {
            if (administrator == null)
            {
                administrator = new Administrator();
            }
            return administrator;
        }

        public static Client GetClient()
        {
            if (client == null)
            {
                client = new Client();
            }
            return client;
        }

        public static KitchenStaff GetKitchenStaff()
        {
            if (staff == null)
            {
                staff = new KitchenStaff();
            }
            return staff;
        }

        public static MainPage GetMainPage()
        {
            if (mainpage == null)
            {
                mainpage = new MainPage();
            }
            return mainpage;
        }
    }
}
