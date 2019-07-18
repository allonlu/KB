using KB.Domain.Entities;
using KB.Domain.Repositories;
using KB.Domain.Uow;
using System;
using System.Linq;
using System.Transactions;

namespace KB.Domain.DomainServices
{
    public class ArticleDomainService : DomainServiceBase, IArticleDomainService
    {
        private IRepository<Article> _articleRepository;


        public ArticleDomainService(
            IRepository<Article> articleRepository,
            IUnitOfWorkManager unitOfWorkManager
            ):base(unitOfWorkManager)
        {
            _articleRepository = articleRepository;
        }

        public int Delete(int articleId)
        {
            var delCount=  _articleRepository.Delete(articleId);
            return delCount;
        }

        public int Delete(Article entity)
        {
            var delCount = _articleRepository.Delete(entity);
            return delCount;

        }

        public Article Get(int id)
        {
            return _articleRepository.Get(id);
        }

        public IQueryable<Article> GetAll()
        {
            return _articleRepository.GetAll();
        }

        public Article Insert(Article entity)
        {
            return _articleRepository.Insert(entity);
        }

        public Article Update(Article entity)
        {
            return _articleRepository.Update(entity);
        }
    }
}
