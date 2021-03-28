using System;

namespace Trimailov
{
    public class TrimailovException : Exception
    {
        public TrimailovException(string message)
        : base(message)
        { }
    }
}
