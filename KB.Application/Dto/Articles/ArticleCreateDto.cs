using Comm100.Constants;
using KB.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KB.Application.Dto.Articles
{
    public class ArticleCreateDto
    {
        [Required]
        [MaxLength(StringLength.MaxNameLength)]
        public string title { get; set; }

        [MaxLength(StringLength.MaxContentLength)]
        public string content { get; set; }

        [Required]
        public int categoryId { get; set; }

        public int[] tagIds { get; set; }
    }
}
