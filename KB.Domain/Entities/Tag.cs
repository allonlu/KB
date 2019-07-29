namespace KB.Domain.Entities
{
    using Comm100.Constants;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class Tag : BaseSiteEntity
    {
        [Required]
        [MaxLength(StringLength.MaxNameLength)]
        public string Name { get; set; }
        //public virtual ICollection<ArticleTag> ArticlesTags { get; set; }


    }
}
