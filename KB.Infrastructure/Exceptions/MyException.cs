using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace KB.Infrastructure.Exceptions
{
    public class MyException : Exception
    {
        public int ErrorCode { get; private set; }

        public MyException(int errorCode)
        {
            ErrorCode = errorCode;
        }

        public MyException(int errorCode,string message) : base(message)
        {
            ErrorCode = errorCode;
        }

        public MyException(int errorCode,string message, Exception innerException) : base(message, innerException)
        {
            ErrorCode = errorCode;
        }

        protected MyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
