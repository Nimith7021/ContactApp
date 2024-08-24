using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAdminApp.Exceptions;
using UserAdminApp.Models;
using UserAdminApp.Services;

namespace UserAdminApp.Repo
{
    internal class AdminManagement
    {
        public static List<User> users = new List<User>();



        

        public static void AddAdmin(User user)
        {
            users.Add(user);
        } 
        public static void AddUser(int adminId,int id, string fname, string lname, bool isAdmin)
        {
            var adminUser = users.Where(user => user.UserId == adminId).FirstOrDefault();
            if (adminUser == null || adminUser.IsAdmin != true)
                throw new AdminAccessException("Operations can only be performed by Admin");

            if (adminUser.IsActive != true)
                throw new OperationDeniedException("Operation denied because the user is deactivated");
            User newUser = User.AddNewUser(id, fname, lname, isAdmin);
            users.Add(newUser);
        }

        public static List<User> DisplayAllUser(int adminId)
        {
            var adminUser = users.Where(user => user.UserId == adminId).FirstOrDefault();
            if (adminUser == null || adminUser.IsAdmin != true)
                throw new AdminAccessException("Operations can only be performed by Admin");

            if (adminUser.IsActive != true)
                throw new OperationDeniedException("Operation denied because the user is deactivated");

            if (users.Count == 0)
                throw new EmptyListException("User List is Empty!!");
            return users;
        }

        public static void UpdateUser(int adminId,int id,string fname,string lname,bool isAdmin)
        {
            var adminUser = users.Where(user=>user.UserId==adminId).FirstOrDefault();
            if(adminUser==null || adminUser.IsAdmin != true)
                throw new AdminAccessException("Operations can only be performed by Admin");
            
            if (adminUser.IsActive != true)
                throw new OperationDeniedException("Operation denied because the user is deactivated");
            
            var userToBeUpdated = users.Where(user=>user.UserId==id).FirstOrDefault();
            if (userToBeUpdated == null || userToBeUpdated.IsActive != true)
                throw new OperationDeniedException("Operation denied because the user is deactivated");
            
            userToBeUpdated.FName = fname;
            userToBeUpdated.LName = lname;
            userToBeUpdated.IsAdmin = isAdmin;
            
        }

        public static void DeleteUser(int adminId,int id) {

            var adminUser = users.Where(user => user.UserId == adminId).FirstOrDefault();
            if (adminUser == null || adminUser.IsAdmin != true)
                throw new AdminAccessException("Operations can only be performed by Admin");

            if (adminUser.IsActive != true)
                throw new OperationDeniedException("Operation denied because the user is deactivated");

            var userToBeDeleted = users.Where(user => user.UserId == id).FirstOrDefault();
            if (userToBeDeleted != null && userToBeDeleted.IsActive==true)
            {
                userToBeDeleted.IsActive = false;
            }
            else
            {
                throw new UserNotFoundException("User not found!!!");          //second exception can also be done here
            }
        }

        public static List<User> DisplayActiveUsers()
        {
            var user = users.Where(x => x.IsActive).ToList();  //true condition check
            if (user.Count==0)
            {
                throw new EmptyListException("No active users");
            }

            return user;
        }

        public static List<User> DisplayInactiveUsers()
        {
            var user = users.Where(x => !x.IsActive).ToList();  //false condition check
            if (user.Count==0)
            {
                throw new EmptyListException("No Inactive users");
            }

            return user;
        }

      
    }
}
