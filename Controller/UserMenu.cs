using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAdminApp.Models;
using UserAdminApp.Repo;

namespace UserAdminApp.Controller
{
    internal class UserMenu
    {
        public static void UserApplication()
        {

            AdminControl.CreateInitialAdmin();

            

            while (true) { 

            Console.WriteLine("Welcome to the User-Contact Application\n" +
                "Enter your choice:\n" +
                "Type 0 for Admin Access and 1 for Staff Access and 2 for exit \n");
            int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 0:
                        AdminControl.AdminAccessMenu();
                        break;
                    case 1:
                        StaffControl.StaffAccessMenu();
                        break;
                    case 2:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Enter a valid choice");
                        break;
                }
            }


        }
    }
}
