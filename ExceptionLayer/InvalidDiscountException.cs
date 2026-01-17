using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionLayer
{
    public class InvalidDiscountException : ApplicationException
    {
        public InvalidDiscountException(string msg) : base(msg) { }
    }
}
