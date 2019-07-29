using Comm100.Constants;
using KB.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KB.Application.Dto.Articles
{
    public class UpdateArticleDto
    {
        [Required]
        [MaxLength(StringLength.MaxNameLength)]
        public string Title { get; set; }

        [MaxLength(StringLength.MaxNameLength)]
        public string Description { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public ArticleStateEnum State { get; set; }
    }
}
