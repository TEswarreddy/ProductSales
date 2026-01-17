using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionLayer
{
    public class InvalidNameException : ApplicationException
    {
        public InvalidNameException(string message) : base(message) { }
    }
}
