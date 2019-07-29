using Comm100.Constants;
using Comm100.Domain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KB.Domain.Entities
{
    public class Category : BaseSiteEntity, IDeletion
    {
        [Required]
        [MaxLength(StringLength.MaxNameLength)]
        public string Name { get; set; }


        [Required]
        public CategoryStateEnum State { get; set; }


        public bool IsDeleted { get; set; }

        //public virtual ICollection<Article> Articles { get; set; }


    }
}
