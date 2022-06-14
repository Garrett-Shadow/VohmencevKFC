using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vohmencev_KFC_App.Pages
{
    public static class Connector
    {
        private static Database.Staff StaffProfile;
        private static Database.Vohmencev_KFCEntities DatabaseConnector;

        public static Database.Vohmencev_KFCEntities GetModel()
        {
            if (DatabaseConnector == null)
            {
                DatabaseConnector = new Database.Vohmencev_KFCEntities();
            }

            return DatabaseConnector;
        }

        public static Database.Staff GetMyProfile()
        {
            return StaffProfile;
        }

        public static bool Authorize(string login, string password)
        {
            string getlogin = login.Trim();
            string getpassword = password.Trim();
            StaffProfile = GetModel().Staff.Where(Employee => Employee.StaffLogin == getlogin && Employee.StaffPassword == getpassword).FirstOrDefault();
            return StaffProfile != null;
        }
    }
}
