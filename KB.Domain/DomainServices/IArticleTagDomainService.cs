using KB.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KB.Domain.DomainServices
{
    public interface IArticleTagDomainService : IDomainService
    {
        IQueryable<ArticleTag> GetAll(Expression<Func<ArticleTag, bool>> predicate);
        ArticleTag Get(int articleId, int tagId);
        IQueryable<Tag> GetTags(int articleId);
        IQueryable<Article> GetArticles(int tagId);
        ArticleTag Add(ArticleTag entity);

        void AddTags(int articleId, IList<Tag> tags);
        Tag AddTag(int articleId, Tag tag);
        Tag AddTag(int articleId, int tagId);


        int Delete(int id);
        int DeleteByArticle(int articleId);
        int DeleteByTag(int tagId);

        int Delete(int articleId, int tagId);


    }
}
