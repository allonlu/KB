using Comm100.Runtime.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace KB.Domain.DomainServices.Dto
{
    public interface IQueryArticleDto : ISortingAndPagedRequest { 
        int? ArticleId { get; set; }
        int? CategoryId { get; set; }
        string Title { get; set; }

    }
}
