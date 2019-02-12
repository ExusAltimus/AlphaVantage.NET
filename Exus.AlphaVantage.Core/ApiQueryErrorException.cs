using System;
using System.Collections.Generic;
using System.Text;

namespace Exus.AlphaVantage.Core
{
    public class ApiQueryErrorException : Exception
    {
        public ApiQueryErrorException(string message): base(message)
        {

        }
    }
}
