
using Comm100.Constants;
using Comm100.Runtime.Dto;
using KB.Domain.DomainServices.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KB.Application.Dto.Articles
{
   public class QueryArticleInput:SortingAndPagedRequestDto,IQueryArticleDto
    {
        public int? ArticleId { get; set; }

        [MaxLength(StringLength.MaxNameLength)]
        public string Title { get; set; }
        public int? CategoryId { get; set; }
    }
}
