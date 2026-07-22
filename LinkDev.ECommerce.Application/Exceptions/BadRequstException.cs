using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.ECommerce.Application.Exceptions
{
    public class BadRequstException : ApplicationException
    {
        public BadRequstException(string? message)
            : base(message)
        {
            
        }
    }
}
