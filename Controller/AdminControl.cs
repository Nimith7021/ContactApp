using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using UserAdminApp.Exceptions;
using UserAdminApp.Models;
using UserAdminApp.Repo;
using UserAdminApp.Services;

namespace UserAdminApp.Controller
{
    internal class AdminControl
    {
        
        public static void AdminAccessMenu()
        {

            //AdminManagement.ManageUsers();

            while (true) {
            Console.WriteLine($"Welcome To Admin Portal :\n" +
                $"Which operation do you wish to perform?\n" +
                $"1.Create a new User\n" +
                $"2.Display all user Details\n" +
                $"3.Update User Details\n" +
                $"4.Delete user details\n" +
                $"5.Back To User Portal\n");

            
                try
                {
                    Console.WriteLine("Enter your choice:");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    DoAdminTask(choice);
                }
                catch(AdminAccessException ae)
                {
                    Console.WriteLine(ae.Message);
                }catch(EmptyListException ule)
                {
                    Console.WriteLine(ule.Message);
                }catch(OperationDeniedException ode)
                {
                    Console.WriteLine(ode.Message);
                }catch(UserNotFoundException ufe)
                {
                    Console.WriteLine(ufe.Message);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static void DoAdminTask(int choice)
        {
            switch (choice)
            {
                case 1:
                    Add();
                    break;
                case 2:
                    Display();
                    break;
                case 3:
                    UpdateUserDetails();
                    break;
                case 4:
                    DeleteUserDetails();
                    break;
                case 5:
                   // AdminManagement.ExitAdminPanel();
                    UserMenu.UserApplication();
                    break;
                default:
                    Console.WriteLine("Enter a valid choice");
                    break;
            }
        }

        public static void Add()
        {
            Console.WriteLine("Enter the admin Id");
            int adminId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter your user ID:");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter your First Name :");
            string fname = Console.ReadLine();
            Console.WriteLine("Enter your Last Name:");
            string lname = Console.ReadLine();
            Console.WriteLine("Is user an Admin ?");
            bool isAdmin = Convert.ToBoolean( Console.ReadLine() );
            AdminManagement.AddUser(adminId,id, fname, lname, isAdmin);
            Console.WriteLine("User Added Successfully");

        }

        public static void Display()
        {
            Console.WriteLine("Enter the id of the admin");
            int adminId = Convert.ToInt32(Console.ReadLine());
            var users = AdminManagement.DisplayAllUser(adminId);
            users.ForEach(x => Console.WriteLine(x));
        }

        public static void UpdateUserDetails()
        {
            Console.WriteLine("Enter the id of the admin");
            int adminId = Convert.ToInt32( Console.ReadLine());
            Console.WriteLine("Enter the id of the user to be updated");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the first name");
            string fname = Console.ReadLine();
            Console.WriteLine("Enter the last name");
            string lname = Console.ReadLine();
            Console.WriteLine("Enter the admin status");
            bool isAdmin = Convert.ToBoolean(Console.ReadLine() );
            AdminManagement.UpdateUser(adminId,id, fname, lname,isAdmin);
            Console.WriteLine("Successful Updation!");
        }

        public static void DeleteUserDetails()
        {
            Console.WriteLine("Enter the id of the admin");
            int adminId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the id");
            int id = Convert.ToInt32(Console.ReadLine());
            AdminManagement.DeleteUser(adminId,id);
            Console.WriteLine("Successful Deletion!!");
        }

        public static void CreateInitialAdmin()
        {
            if(!AdminManagement.HasUserRecords())
            {
                Console.WriteLine("Enter the admin Id");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the first Name of Admin");
                string fname = Console.ReadLine();
                Console.WriteLine("Enter the Last name of Admin");
                string lname = Console.ReadLine();
                User initialAdmin = new User(id, fname, lname, true);
                AdminManagement.AddInitialAdmin(initialAdmin);
                Console.WriteLine("Initial Admin Added Successfully");
            }    
        }
    }
}
