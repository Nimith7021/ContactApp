using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAdminApp.Exceptions;
using UserAdminApp.Models;
using UserAdminApp.Repo;

namespace UserAdminApp.Controller
{
    internal class UserPortal
    {
        public static void UserApplication()
        {
            User admin1 = new User(1, "Nimith", "Shetty", true);
            User admin2 = new User(2, "John", "Doe", true);
            User staff1 = new User(3, "Ram", "Shetty", false);
            User staff2 = new User(4, "Ramesh", "Thevar", false);

            AdminManagement.AddAdmin(admin1);
            AdminManagement.AddAdmin(admin2);
            StaffManagement.AddStaff(staff1);
            StaffManagement.AddStaff(staff2);

            Console.WriteLine("Enter the userId:");
            int id = Convert.ToInt32(Console.ReadLine());
            var user = AdminManagement.users.Where(x => x.UserId == id).FirstOrDefault();
            if (user == null)
            {
                throw new UserNotFoundException("User doesn't exist");
            }
            if (user.IsAdmin)
            {
                AdminControl.AdminAccessMenu();
            }
            else
            {

                StaffControl.StaffAccessMenu();
            }
        }
    }
}
