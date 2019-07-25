using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace KB.Infrastructure.Exceptions
{
    public class AuthorizationException : MyException
    {

        public AuthorizationException():base(ErrorCodes.NoAuthorization,ErrorMessages.NoAuthorization)
        {
        }





    }
}
