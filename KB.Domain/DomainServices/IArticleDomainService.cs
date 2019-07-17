using System.Linq;
using KB.Domain.Entities;

namespace KB.Domain.DomainServices
{
    public interface IArticleDomainService: IDomainService
    {
        Article Get(int id);
        IQueryable<Article> GetAll();
        int Delete(int articleId);
        int Delete(Article entity);
        Article Update(Article entity);
        Article Insert(Article entity);

    }
}