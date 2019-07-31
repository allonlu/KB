
using Comm100.Constants;
using Comm100.Domain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
namespace KB.Domain.Entities
{
    [TableSwitch]
    public class Article : BaseSiteEntity
    {


        [Required]
        [MaxLength(StringLength.MaxNameLength)]
        public string Title { get; set; }
        [MaxLength(StringLength.MaxDescLength)]
        public string Description { get; set; }
        public ArticleStateEnum State { get; set; }
        public int CategoryId { get; set; }
        //public virtual ICollection<Tag> Tags { get; set; }
        public virtual Category Category { get; set; }

    }
}
