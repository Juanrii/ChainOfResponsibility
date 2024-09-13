using System;

namespace ChainOfResponsibility.Services.Security
{
    internal class SecurityException : Exception
    {
        public SecurityException(string message) : base(message) { }
    }
}
