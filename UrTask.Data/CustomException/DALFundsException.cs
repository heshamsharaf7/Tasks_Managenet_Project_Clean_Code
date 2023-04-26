using System;

namespace UrTask.Data.CustomException
{
    public class DALFundsException : Exception
    {

        public DALFundsException()
        {
        }

        public DALFundsException(string message)
            : base(message)
        {
        }

        public DALFundsException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

}
