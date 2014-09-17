namespace ATM.DataAccess
{
    using System;

    public class ATMException : ApplicationException
    {
        public ATMException()
        {
        }

        public ATMException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public ATMException(string message)
            : this(message, null)
        {
        }
    }
}