using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagingAPP
{
    class ManageUsers
    {
        MessagingDBModel objDb = new MessagingDBModel();

        public void UsersManagement()
        {
            bool flag = false;

            do
            {
                Console.Clear();
                Console.WriteLine("*************** Users Management *************");
                Console.WriteLine("Select options from below:");
                Console.WriteLine("=> Create new User (Press 'n' or 'N'):");
                Console.WriteLine("=> Edit existing User (Press 'e' or 'E'):");
                Console.WriteLine("=> Delete existing User (Press 'd' or 'D'):");
                Console.WriteLine("=> View all existing Users (Press 'v' or 'V'):");
                Console.WriteLine("=> Back to Admin Screen (Press 'b' or 'B'):");

                var input = Console.ReadKey();

                switch (input.Key) //Switch on Key enum
                {
                    case ConsoleKey.N:
                        CreateUser(); // Create a new user
                        break;
                    case ConsoleKey.E:
                        EditUser(); // Edit a user
                        break;
                    case ConsoleKey.D:
                        DeleteUser(); // Delete a user
                        break;
                    case ConsoleKey.V:
                        ViewUsers(); // View all users
                        break;
                    case ConsoleKey.B:
                        flag = true;
                        break;
                    default:
                        Console.WriteLine("\nWrong Key Pressed. Please try again!");
                        break;
                }

            } while (!flag);

            AdminScreen objAdminScreen = new AdminScreen();
            objAdminScreen.ShowScreen();
        }

        private void ViewUsers()
        {
            Console.WriteLine("\n******************* All Users *************");

            List<User> usersList = objDb.Users.Where(P => P.UserType != "Super Admin").ToList();

            if (usersList.Count > 0)
            {
                foreach (User objUser in usersList)
                {
                    UserRole objRoles = objDb.UserRoles.SingleOrDefault(P => P.UserID == objUser.PKID);
                    Console.WriteLine(objUser.PKID + " | " + objUser.FullName + " | " + objUser.EmailAddress + " | " + objUser.Username + " | " + objUser.Password + " | " + objUser.CreationDate.ToString() + " | ( " + objRoles.ViewData.Trim() + " " + objRoles.EditData.Trim() + " " + objRoles.DeleteData.Trim() + " ) ");
                }

                Console.WriteLine("***************************************");
            }
            else
            {
                Console.WriteLine("No Users exist!");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void DeleteUser()
        {
            Console.WriteLine("\n******************* Delete a User *************");
            Console.Write("Enter a username / email address to delete: ");

            string input = Console.ReadLine();

            if (input == "" || input == null)
            {
                Console.WriteLine("\nUsername / email can't be empty");
            }
            else
            {
                User objUser = objDb.Users.SingleOrDefault(P => P.Username == input || P.EmailAddress == input);

                if (objUser != null)
                {
                    UserRole objRoles = objDb.UserRoles.SingleOrDefault(P => P.UserID == objUser.PKID);
                    objDb.UserRoles.Remove(objRoles);
                    objDb.Users.Remove(objUser);

                    int result = objDb.SaveChanges();

                    if (result > 0)
                    {
                        Console.WriteLine("\n***** Successfully Deleted Users *****");
                    }
                }
                else
                {
                    Console.WriteLine("\n User not exist!");
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        private void EditUser()
        {
            Console.WriteLine("\n******************* Edit a User *************");
            Console.Write("Enter a username / email address to edit: ");

            string input = Console.ReadLine();

            if (input == "" || input == null)
            {
                Console.WriteLine("\nUsername / email can't be empty");
            }
            else
            {
                User objUser = objDb.Users.SingleOrDefault(P => P.Username == input || P.EmailAddress == input);

                if (objUser != null)
                {
                    UserRole objRoles = objDb.UserRoles.SingleOrDefault(P => P.UserID == objUser.PKID);

                    Console.WriteLine("\n******************* User Information *************");
                    Console.WriteLine(objUser.PKID + " " + objUser.FullName + " " + objUser.EmailAddress + " " + objUser.Username + " " + objUser.Password + " " + objUser.CreationDate.ToString() + " | ( " + objRoles.ViewData.Trim() + " " + objRoles.EditData.Trim() + " " + objRoles.DeleteData.Trim() + " ) ");
                    Console.WriteLine("**************************************************");
                    Console.WriteLine("Update user info from below:");

                    Console.Write("\n1. Enter Full name of user: ");
                    string fullname = Console.ReadLine();

                    Console.Write("\n2. Enter email address of user: ");
                    string email = Console.ReadLine();

                    Console.Write("\n3. Enter username of user: ");
                    string username = Console.ReadLine();

                    Console.Write("\n4. Enter password of user: ");
                    string password = ConsolePassword.ReadPassword();

                    objUser.FullName = fullname;
                    objUser.EmailAddress = email;
                    objUser.Username = username;
                    objUser.Password = password;

                    Console.Write("\n*** 5. Select User Roles ***");
                    Console.Write("\nView Data Access (Enter 'y' or 'n'): ");
                    string viewAccess = Console.ReadLine();

                    Console.Write("\nEdit Data Access (Enter 'y' or 'n'): ");
                    string editAccess = Console.ReadLine();

                    Console.Write("\nDelete Data Access (Enter 'y' or 'n'): ");
                    string deleteAccess = Console.ReadLine();

                    objRoles.ViewData = viewAccess;
                    objRoles.EditData = editAccess;
                    objRoles.DeleteData = deleteAccess;

                    int result = objDb.SaveChanges();

                    if (result > 0)
                    {
                        Console.WriteLine("\n***** Successfully Updated User *****");
                    }
                }
                else
                {
                    Console.WriteLine("\n User not exist!");
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        private void CreateUser()
        {
            Console.WriteLine("\n******************* Create a new User *************");

            User objUser = new User();
            UserRole objRoles = new UserRole();

            Console.WriteLine("Enter user info below:");

            Console.Write("\n1. Enter Full name of user: ");
            string fullname = Console.ReadLine();

            Console.Write("\n2. Enter email address of user: ");
            string email = Console.ReadLine();

            Console.Write("\n3. Enter username of user: ");
            string username = Console.ReadLine();

            Console.Write("\n4. Enter password of user: ");
            string password = ConsolePassword.ReadPassword();

            objUser.FullName = fullname;
            objUser.EmailAddress = email;
            objUser.Username = username;
            objUser.Password = password;
            objUser.UserType = "User";
            objUser.CreationDate = System.DateTime.Now;
            objDb.Users.Add(objUser);

            int result = objDb.SaveChanges();

            if (result > 0)
            {
                Console.Write("\n*** 5. Select User Roles ***");
                Console.Write("\nView Data Access (Enter 'y' or 'n'): ");
                string viewAccess = Console.ReadLine();

                Console.Write("\nEdit Data Access (Enter 'y' or 'n'): ");
                string editAccess = Console.ReadLine();

                Console.Write("\nDelete Data Access (Enter 'y' or 'n'): ");
                string deleteAccess = Console.ReadLine();

                objRoles.UserID = objUser.PKID;
                objRoles.ViewData = viewAccess.Trim();
                objRoles.EditData = editAccess.Trim();
                objRoles.DeleteData = deleteAccess.Trim();

                objDb.UserRoles.Add(objRoles);

                result = objDb.SaveChanges();

                if (result > 0)
                {
                    Console.WriteLine("\n***** Successfully Created a new User *****");
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }
}
