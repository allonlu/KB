using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace KB.Infrastructure.Exceptions
{
    public class EntityNotFoundException : MyException
    {
        public Type EntityType { get; set; }
        public int Id { get; set; }
        private static string formatMessage = "数据不存在";

        public EntityNotFoundException()
        {

        }
        public EntityNotFoundException(int errorCode) : base(errorCode, formatMessage)
        {
            
        }

        public EntityNotFoundException(int errorCode, Exception innerException) : base(errorCode, formatMessage, innerException)
        {
        }
    }
}
