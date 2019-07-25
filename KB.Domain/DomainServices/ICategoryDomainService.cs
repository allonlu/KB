using KB.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace KB.Domain.DomainServices
{
    public interface ICategoryDomainService:IDomainService
    {
        Category Add(Category category);
        Category Update(Category category);
        int Delete(Category category);
        int Delete(int id);
        IQueryable<Category> GetAll(Expression<Func<Category, bool>> predicate);
        Category Get(int id);
        IQueryable<Article> GetArticles(int category);
    }
}
