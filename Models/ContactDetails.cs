using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAdminApp.Models
{
    internal class ContactDetails
    {
        public int ContactDetailsID { get; set; }
        public string Type { get; set; }

        public ContactDetails(int id , string type) { 
        
            ContactDetailsID = id;
            Type = type;
        }


        public static ContactDetails CreateNewContactDetail(int id , string type)
        {
            return new ContactDetails(id, type);
        }

        public override string ToString()
        {
            return $"Contact Details ID : {ContactDetailsID}\n" +
                $"Type of Contact Info : {Type}\n";
        }

    }
}
