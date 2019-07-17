namespace KB.Domain.Entities
{
    using KB.Infrastructure.Constant;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class Article : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(Constant.MaxNameLength)]
        public string Title { get; set; }
        [MaxLength(Constant.MaxDescLength)]
        public string Description { get; set;  }
    }
}
