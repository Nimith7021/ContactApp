using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAdminApp.Exceptions;
using UserAdminApp.Models;

namespace UserAdminApp.Repo
{
    internal class StaffManagement
    {

        public static void AddStaff(User user)
        {
            AdminManagement.users.Add(user);
        }

        public static void AddContact(int userId ,int contactId)
        {
            var user = AdminManagement.users.Where(user=>user.UserId==userId).FirstOrDefault();
            if (user == null || user.IsActive == false)
                throw new OperationDeniedException("User is deactivated");
            Contacts newContacts = Contacts.AddContacts(contactId,user.FName,user.LName);
            user.Contacts.Add(newContacts);
            
        }

        public static List<Contacts> DisplayContacts(int id)
        {
            var user = AdminManagement.users.Where(user=>user.UserId==id).FirstOrDefault();
            if (user == null)
            {
                throw new UserNotFoundException("User doesn't exist");
            }
            if (user.Contacts.Count == 0)
                throw new EmptyListException("Contact List is Empty");
            return user.Contacts;
        }

        public static void UpdateContact(int userId,int contactId,string lname)
        {
            var user = AdminManagement.users.Where(user => user.UserId == userId).FirstOrDefault();
            if (user == null)
                throw new UserNotFoundException("User does not exist");
            if (user.IsActive == false)
                throw new OperationDeniedException("User got Deactivated");
            var contact=user.Contacts.Where(contact => contact.ContactID == contactId).FirstOrDefault();
            if (contact.IsActive == false)
                throw new OperationDeniedException("Contact is Deactivated Can't Perform Operations");
            if (contact == null)
                throw new ContactNotExistException("Contact doesn't exist");
            contact.LName = lname;
        }

        public static void DeleteContact(int userId , int contactId)
        {
            var user = AdminManagement.users.Where(user => user.UserId == userId).FirstOrDefault();
            if (user == null)
                throw new UserNotFoundException("User does not exist");
            if (user.IsActive != true)
            {
                throw new OperationDeniedException("User has been Deactivated");
            }
            var contact = user.Contacts.Where(contact => contact.ContactID == contactId).FirstOrDefault();
            if (contact == null)
                throw new ContactNotExistException("Contact doesn't exist");
            contact.IsActive = false;
        }

        public static void AddContactDetails(int userId,int contactId,int detailId,string type)
        {
            var user = AdminManagement.users.Where(user=>user.UserId==userId).FirstOrDefault();
            if (user == null || user.IsActive == false)
                throw new OperationDeniedException("User Deactivated");
            var contact = user.Contacts.Where(contact=>contact.ContactID==contactId).FirstOrDefault();
            if (contact == null || contact.IsActive == false)
                throw new OperationDeniedException("Contact has been deactivated");
            var newContactDetails = ContactDetails.CreateNewContactDetail(detailId, type);
            contact.ContactDetails.Add(newContactDetails);
        }

        public static List<ContactDetails> DisplayDetails(int userId,int contactId)
        {
            var user = AdminManagement.users.Where(user => user.UserId == userId).FirstOrDefault();
            if (user == null || user.IsActive == false)
                throw new OperationDeniedException("User Deactivated");
            var contact = user.Contacts.Where(contact => contact.ContactID == contactId).FirstOrDefault();
            if (contact == null || contact.IsActive == false)
                throw new OperationDeniedException("Contact has been deactivated");
            if (contact.ContactDetails.Count == 0)
                throw new EmptyListException("Contact List Is Empty");
            return contact.ContactDetails;
        }

        public static void UpdateDetails(int userId , int contactId,int detailId,string type)
        {
            var user = AdminManagement.users.Where(user => user.UserId == userId).FirstOrDefault();
            if (user == null || user.IsActive == false)
                throw new OperationDeniedException("User Deactivated");
            var contact = user.Contacts.Where(contact => contact.ContactID == contactId).FirstOrDefault();
            if (contact == null || contact.IsActive == false)
                throw new OperationDeniedException("Contact has been deactivated");
            var details = contact.ContactDetails.
                Where(detail => detail.ContactDetailsID == detailId).FirstOrDefault();
            if (details == null)
            {
                throw new ContactDetailNotFoundException("Contact Details Not Found");
            }

            details.Type = type;

        }

        public static void DeleteDetails(int userId, int contactId, int detailId)
        {
            var user = AdminManagement.users.Where(user => user.UserId == userId).FirstOrDefault();
            if (user == null || user.IsActive == false)
                throw new OperationDeniedException("User Deactivated");
            var contact = user.Contacts.Where(contact => contact.ContactID == contactId).FirstOrDefault();
            if (contact == null || contact.IsActive == false)
                throw new OperationDeniedException("Contact has been deactivated");
            var details = contact.ContactDetails.
                Where(detail => detail.ContactDetailsID == detailId).FirstOrDefault();
            if (details == null)
            {
                throw new ContactDetailNotFoundException("Contact Details Not Found");
            }

            contact.ContactDetails.Remove(details);
        }


    }
}
