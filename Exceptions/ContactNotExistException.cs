using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAdminApp.Exceptions
{
    internal class ContactNotExistException:Exception
    {
        public ContactNotExistException(string message):base(message) { }
    }
}
