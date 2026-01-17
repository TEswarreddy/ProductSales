using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionLayer
{
    public class InvalidGSTException : ApplicationException
    {
        public InvalidGSTException(string msg) : base(msg) { }
    }
}
