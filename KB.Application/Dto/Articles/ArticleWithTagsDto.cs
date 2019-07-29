using KB.Application.Dto.Tags;
using KB.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KB.Application.Dto.Articles
{
   public class ArticleWithTagsDto
    {
        public ArticleWithTagsDto()
        {
            Tags = new List<TagDto>();
        }
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public ArticleStateEnum State { get; set; }

        public IList<TagDto> Tags { get; set; }
    }
}
