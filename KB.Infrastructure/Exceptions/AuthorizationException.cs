using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace KB.Infrastructure.Exceptions
{
    public class AuthorizationException : MyException
    {

        public AuthorizationException()
        {
        }

        public AuthorizationException(int errorCode, string message) : base(errorCode, message)
        {
        }

        public AuthorizationException(int errorCode, string message, Exception innerException) : base(errorCode, message, innerException)
        {
        }

        protected AuthorizationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
