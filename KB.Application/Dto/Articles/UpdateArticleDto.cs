using KB.Domain.Entities;
using KB.Infrastructure.Constant;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KB.Application.Dto.Articles
{
    public class UpdateArticleDto
    {
        [Required]
        [MaxLength(Constant.MaxNameLength)]
        public string Title { get; set; }

        [MaxLength(Constant.MaxNameLength)]
        public string Description { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public ArticleStateEnum State { get; set; }
    }
}
