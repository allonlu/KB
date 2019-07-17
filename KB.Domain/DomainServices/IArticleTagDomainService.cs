using KB.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KB.Domain.DomainServices
{
    public interface IArticleTagDomainService : IDomainService
    {
        IQueryable<ArticleTag> GetAll();
        ArticleTag Get(int articleId, int tagId);
        IQueryable<Tag> GetTags(int articleId);
        IQueryable<Article> GetArticles(int tagId);
        ArticleTag Insert(ArticleTag entity);

        void AddTags(int articleId, IList<Tag> tags);
        void AddTag(int articleId, Tag tag);
        void AddTag(int articleId, int tagId);


        int Delete(int id);
        int Delete(int articleId, int tagId);


    }
}
