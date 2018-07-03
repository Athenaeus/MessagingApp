using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagingAPP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**************************************************");
            Console.WriteLine("************** Messaging Application  ************");
            Console.WriteLine("**************************************************");
            Console.WriteLine("\n");
            Console.WriteLine("*** Welcome ***");
            bool flag = false;

            do
            {
                Console.Write("Press 'L' or 'l' for login : ");

                var input = Console.ReadKey();

                switch (input.Key) //Switch on Key enum
                {
                    case ConsoleKey.L:
                        flag = true;
                        LoginScreen objLoginScreen = new LoginScreen();
                        objLoginScreen.ShowScreen();
                        break;
                    
                    default:
                        Console.WriteLine("\nWrong Key Pressed. Please try again!");
                        flag = false;
                        break;
                }

            } while (!flag);

            Console.WriteLine("\n");
            Console.ReadKey();
        }
    }
}
