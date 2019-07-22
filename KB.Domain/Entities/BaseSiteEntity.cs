using System;
using System.Collections.Generic;
using System.Text;

namespace KB.Domain.Entities
{
    public class BaseSiteEntity : IEntity, IMustHaveSiteId
    {
        public int Id { get; set; }
        public int SiteId { get ; set ; }
    }
}
