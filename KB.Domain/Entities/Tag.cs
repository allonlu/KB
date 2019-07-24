namespace KB.Domain.Entities
{
    using KB.Infrastructure.Constant;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class Tag : BaseSiteEntity
    {
        [Required]
        [MaxLength(Constant.MaxNameLength)]
        public string Name { get; set; }
        //public virtual ICollection<ArticleTag> ArticlesTags { get; set; }


    }
}
