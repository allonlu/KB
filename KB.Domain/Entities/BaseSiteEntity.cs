using Comm100.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace KB.Domain.Entities
{
    public class BaseSiteEntity : IEntity, IBelongToSite
    {
        public int Id { get; set; }
        public int SiteId { get ; set ; }
    }
}
