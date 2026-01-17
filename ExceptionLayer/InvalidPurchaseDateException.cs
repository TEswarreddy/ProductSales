using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionLayer
{
    public class InvalidPurchaseDateException : ApplicationException
    {
        public InvalidPurchaseDateException(string msg) : base(msg){ }
    }
}
