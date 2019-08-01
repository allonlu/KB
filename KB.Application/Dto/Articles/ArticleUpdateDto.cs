using Comm100.Constants;
using KB.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KB.Application.Dto.Articles
{
    public class ArticleUpdateDto
    {
        [Required]
        [MaxLength(StringLength.MaxNameLength)]
        public string title { get; set; }

        [MaxLength(StringLength.MaxContentLength)]
        public string content { get; set; }

        [Required]
        public int categoryId { get; set; }

        public string[] tags { get; set; }

        public EnumArticleState state { get; set; }
    }
}
