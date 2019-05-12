using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Project.Back_End.Exceptions
{
    public class InfoExistException : Exception
    {
        public InfoExistException(string message) : base(message)
        {

        }
    }
}
