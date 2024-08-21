using UserAdminApp.Models;
using UserAdminApp.Controller;

namespace UserAdminApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                UserPortal.UserApplication();
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
