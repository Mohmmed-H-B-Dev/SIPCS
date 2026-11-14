using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIPCS.Common.Exceptions
{
    public class B_Exception : Exception
    {
        public B_Exception() { }

        public B_Exception(string message) : base(message) { }  
        public B_Exception(string message, Exception innerException) : base(message, innerException) { }
    }
}
