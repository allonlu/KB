using System;
using System.Linq;
using System.Linq.Expressions;
using KB.Domain.Entities;

namespace KB.Domain.DomainServices
{
    public interface IArticleDomainService: IDomainService
    {
        Article Get(int id);
        IQueryable<Article> GetAll(Expression<Func<Article, bool>> predicate);
        int Delete(int articleId);
        int Delete(Article entity);
        Article Update(Article entity);
        Article Add(Article entity);
        bool Public(Article article);

    }
}