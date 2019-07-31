using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Comm100.Domain.Services;
using Comm100.Runtime.Dto;
using KB.Domain.DomainServices.Dto;
using KB.Domain.Entities;

namespace KB.Domain.DomainServices
{
    public interface IArticleDomainService: IDomainService
    {
        Article Get(int id);
        IQueryable<Article> GetAll(Expression<Func<Article, bool>> predicate =null);
        PagedResultDto<Article> GetList(IQueryArticleDto dto);
        int Delete(int articleId);
        int Delete(Article entity);
        Article Update(Article entity);
        Article Add(Article entity);
        bool Public(Article article);

    }
}