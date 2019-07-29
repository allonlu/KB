using System;
using System.Linq;
using System.Linq.Expressions;
using Comm100.Domain.Services;
using KB.Domain.Entities;

namespace KB.Domain.DomainServices
{
    public interface IArticleDomainService: IDomainService
    {
        Article Get(int id);
        IQueryable<Article> GetAll(Expression<Func<Article, bool>> predicate=null);
        int Delete(int articleId);
        int Delete(Article entity);
        Article Update(Article entity);
        Article Add(Article entity);
        bool Public(Article article);

    }
}