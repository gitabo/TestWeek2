using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWeek2.Lib
{
    public class GoodException : Exception
    {
        public GoodException()
        {
        }

        public GoodException(string message): base(message)
        {
        }

        public GoodException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
