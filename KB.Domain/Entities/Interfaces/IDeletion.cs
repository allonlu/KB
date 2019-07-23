using System;
using System.Collections.Generic;
using System.Text;

namespace KB.Domain.Entities
{
    public interface IDeletion
    {
        bool IsDeleted { get; set; }
    }
}
