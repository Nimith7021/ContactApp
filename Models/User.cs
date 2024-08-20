using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAdminApp.Models
{
    internal class User
    {
        public int UserId { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }

        public bool IsAdmin { get; set; }
        public bool IsActive { get; set; }

        public List<Contacts> Contacts { get; set; } = new List<Contacts>();

        public User(int id , string fname , string lname , bool isAdmin)
        {
            UserId = id;
            FName = fname;
            LName = lname;
            IsAdmin = isAdmin;
            IsActive= true;

        }

        public static User AddNewUser(int id, string fname, string lname, bool isAdmin)
        {
            return new User(id, fname, lname, isAdmin);
        }

        public override string ToString()
        {
            return $"User Id : {UserId}\n" +
                $"First Name : {FName}\n" +
                $"Last Name : {LName}\n" +
                $"Is User an Admin ? : {IsAdmin}\n" +
                $"Is User Active ? : {IsActive}\n";
        }


    }
    }

