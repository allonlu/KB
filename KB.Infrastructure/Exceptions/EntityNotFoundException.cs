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

        public override string Message => string.Format(base.Message, EntityType.Name, Id);

        public EntityNotFoundException(int id, Type entityType) : this(id)
        {
            EntityType = entityType;

        }
        public EntityNotFoundException(int id) : base(ErrorCodes.EntityNotFound,ErrorMessages.EntityNotFound)
        {
            Id = id;
        }
    }
}
