using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility.Services.Session
{
    internal class SessionException : Exception
    {
        public SessionException(string message) : base(message) { }
    }
}
