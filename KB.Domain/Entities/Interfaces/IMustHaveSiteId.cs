using System;
using System.Collections.Generic;
using System.Text;

namespace KB.Domain.Entities
{
    public interface IMustHaveSiteId: IBelongToSite
    {
       int SiteId { get; set; }
    }
}
