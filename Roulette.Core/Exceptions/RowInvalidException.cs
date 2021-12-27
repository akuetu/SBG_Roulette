using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette.Core.Exceptions
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
