using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAdminApp.Repo;
using UserAdminApp.Models;
using UserAdminApp.Exceptions;

namespace UserAdminApp.Controller
{
    internal class StaffControl
    {
        public static void StaffAccessMenu()
        {
            while (true)
            {
                Console.WriteLine("Welcome to the Staff Control Application:\n" +
                "Which Operation would you like to perform?\n" +
                "1.Create a new Contact\n" +
                "2.Display all Contact Info\n" +
                "3.Update Contact Information\n" +
                "4.Delete Contact Records\n" +
                "5.Create a new Contact Detail\n" +
                "6.Display all records\n" +
                "7.Update contact Detals\n" +
                "8.Delete Contact Detail Records\n" +
                "9.Exit Staff Portal\n");

           
            
                try
                {
                    Console.WriteLine("Enter your choice\n");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    DoStaffTask(choice);
                }
                catch (ContactDetailNotFoundException cdnfe)
                {
                    Console.WriteLine(cdnfe.Message);
                }
                catch (UserNotFoundException unf)
                {
                    Console.WriteLine(unf.Message);
                }
                catch (EmptyListException ele)
                {
                    Console.WriteLine(ele.Message);
                }
                catch (ContactNotExistException cne)
                {
                    Console.WriteLine(cne.Message);
                }
                catch (OperationDeniedException ode)
                {
                    Console.WriteLine(ode.Message);
                }
                catch (Exception ex) { 
                    Console.WriteLine(ex.Message);
                }
        }

        }

        public static void DoStaffTask(int choice)
        {
            switch (choice)
            {
                case 1:
                    AddContact();
                    break;
                case 2:
                    Display();
                    break;
                case 3:
                    Update();
                    break;
                case 4:
                    Delete();
                    break;
                case 5:
                    AddContactDetail();
                    break;
                case 6:
                    DisplayDetail();
                    break;
                case 7:
                    UpdateDetail();
                    break;
                case 8:
                    DeleteDetail();
                    break;
                case 9:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Enter a valid Choice");
                    break;
            }
        }

        public static void AddContact() {

            Console.WriteLine("Enter your User Id");
            int userId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter your contact ID:");
            int id = Convert.ToInt32(Console.ReadLine());
            StaffManagement.AddContact(userId,id);
            Console.WriteLine("Contact Added Successfully");
        }

        public static void Display()
        {
            Console.WriteLine("Enter the user Id");
            int id = Convert.ToInt32(Console.ReadLine());
            var contacts = StaffManagement.DisplayContacts(id);
            contacts.ForEach(contact => Console.WriteLine(contact));
        }

        public static void Update()
        {
            Console.WriteLine("Enter the user Id");
            int userId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the contact Id");
            int contactId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the last name");
            string lname = Console.ReadLine();
            StaffManagement.UpdateContact(userId,contactId,lname);
            Console.WriteLine("Updation Successful!!!");
        }

        public static void Delete()
        {
            Console.WriteLine("Enter the user Id");
            int userId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the contact Id");
            int contactId = Convert.ToInt32(Console.ReadLine());
            StaffManagement.DeleteContact(userId,contactId);
            Console.WriteLine("Deletion Successful!!");
        }

        public static void AddContactDetail()
        {
            Console.WriteLine("Enter the user Id");
            int userId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the contact Id");
            int contactId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the contact detail Id");
            int detailId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the type of detail(Number/Email)?");
            string type = Console.ReadLine();
            StaffManagement.AddContactDetails(userId,contactId,detailId,type);
            Console.WriteLine("Contact Detail Added Successfully!!!");
        }

        public static void DisplayDetail() 
        {
            Console.WriteLine("Enter the user Id");
            int userId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the contact Id");
            int contactId = Convert.ToInt32(Console.ReadLine());
            var contactDetails = StaffManagement.DisplayDetails(userId, contactId);
            contactDetails.ForEach(details => Console.WriteLine(details));  

        }

        public static void UpdateDetail()
        {
            Console.WriteLine("Enter the user Id");
            int userId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the contact Id");
            int contactId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the contact Detail Id");
            int detailId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the type of Detail");
            string type = Console.ReadLine();
            StaffManagement.UpdateDetails(userId,contactId,detailId,type);
            Console.WriteLine("Successful deletion of Contact Details");
        }

        public static void DeleteDetail()
        {
            Console.WriteLine("Enter the user Id");
            int userId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the contact Id");
            int contactId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the contact Detail Id");
            int detailId = Convert.ToInt32(Console.ReadLine());
            StaffManagement.DeleteDetails(userId, contactId, detailId);
            Console.WriteLine("Successful Deletion Of Details");
        }
    }
}
