using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAdminApp.Models
{
    internal class Contacts
    {
        public int ContactID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public bool IsActive { get; set; }

        public List<ContactDetails> ContactDetails { get; set; } = new List<ContactDetails>();

        public Contacts(int contactID, string fName, string lName)
        {
            ContactID = contactID;
            FName = fName;
            LName = lName;
            IsActive = true;
        }

        public static Contacts AddContacts(int contactID, string fName, string lName)
        {
            return new Contacts(contactID, fName, lName);
        }

        public override string ToString()
        {
            return $"Contact ID : {ContactID}\n" +
                $"First Name : {FName}\n" +
                $"Last Name : {LName}\n" +
                $"Contact still active ? : {IsActive}\n";
        }
    }
}
