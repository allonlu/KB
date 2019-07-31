using Comm100.Runtime.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace KB.Domain.DomainServices.Dto
{
    public class QueryArticleDto : SortingAndPagingRequestDto {
        public int? ArticleId { get; set; }
        public int? CategoryId { get; set; }
        public string Title { get; set; }

    }
}
