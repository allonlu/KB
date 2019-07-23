namespace KB.Domain.Entities
{
    using KB.Infrastructure.Constant;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class Article :BaseSiteEntity
    {


        [Required]
        [MaxLength(Constant.MaxNameLength)]
        public string Title { get; set; }
        [MaxLength(Constant.MaxDescLength)]
        public string Description { get; set; }
        public ArticleStateEnum State { get; set; }
        public virtual ICollection<ArticleTag> ArticleTags { get; set; }
        public virtual Category Category { get; set; }

    }
}
