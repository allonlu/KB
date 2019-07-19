using System;
using System.Collections.Generic;
using System.Text;

namespace KB.Infrastructure.Runtime.Authorization
{
    public class PermissionAttribute:Attribute
    {
        public string Name { get; private set; }
        public PermissionAttribute(string name)
        {
            Name = name;
        }
    }
}
