using System;

namespace Roulette.Service.Exceptions
{
    [Serializable]
    public class RowInvalidException : Exception
    {
        public RowInvalidException() { }

        public RowInvalidException(string message)
            : base(message) { }

        public RowInvalidException(string message, Exception inner)
            : base(message, inner) { }
    }
}
