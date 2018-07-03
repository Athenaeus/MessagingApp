using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagingAPP
{
    class AdminScreen
    {
        public void ShowScreen()
        {
            Console.Clear();
            Console.WriteLine("**************************************************");
            Console.WriteLine("*** Super Admin Screen ***");
            Console.WriteLine("**************************************************\n");
            bool flag = false;

            do
            {
                Console.WriteLine("Select any menu from below:");
                Console.WriteLine("=> User Management (Press 'u' or 'U'):");
                Console.WriteLine("=> Messages Data Management (Press 'm' or 'M'):");
                Console.WriteLine("=> Logout (Press 'o' or 'O'):");

                var input = Console.ReadKey();

                switch (input.Key) //Switch on Key enum
                {
                    case ConsoleKey.U:
                        flag = true;
                        UsersManagement(); // Show users management module
                        break;
                    case ConsoleKey.M:
                        flag = true;
                        DataManagement(); // Show users massages data module
                        break;
                    case ConsoleKey.O:
                        flag = true;
                        Logout(); // Logout
                        break;
                    default:
                        Console.WriteLine("\nWrong Key Pressed. Please try again!");
                        flag = false;
                        break;
                }

            } while (!flag);
        }

        private void Logout()
        {
            LoginScreen objLogin = new LoginScreen();
            objLogin.ShowScreen();
        }

        protected void UsersManagement()
        {
            ManageUsers objManageUsers = new ManageUsers();
            objManageUsers.UsersManagement();
        }

        protected void DataManagement()
        {
            ManageData objManageData = new ManageData();
            objManageData.AdminView();
        }
    }
}
