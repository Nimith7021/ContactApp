using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAdminApp.Exceptions
{
    internal class OperationDeniedException:Exception
    {
        public OperationDeniedException(string message):base(message) 
        {
            
        }
    }
}
