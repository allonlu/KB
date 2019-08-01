
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Transactions;
using KB.Domain.Entities;
using Comm100.Domain.Services;
using Comm100.Domain.Repository;
using Comm100.Domain.Ioc;
using Comm100.Domain.Uow;
using Comm100.Runtime.Exception;
using System.Collections.Generic;
using KB.Domain.DomainServices.Dto;
using Comm100.Extension;
using Comm100.Runtime.Dto;

namespace KB.Domain.DomainServices
{
    public class ArticleDomainService : DomainServiceBase, IArticleDomainService
    {
        private readonly IRepository<Article> _articleRepository;
        private readonly IRepository<ArticleTag> _articleTagRepository;

        public virtual ICategoryDomainService CategoryDomainService { get; set; }

        public ArticleDomainService(IRepository<Article> articleRepository,
            IRepository<ArticleTag> articleTagRepository)
        {
            this._articleRepository = articleRepository;
            this._articleTagRepository = articleTagRepository;
        }

        public int Delete(int articleId)
        {
            var delCount=  _articleRepository.Delete(articleId);
            delCount += _articleTagRepository.Delete(e => e.ArticleId == articleId);
            return delCount;
        }

        public int Delete(Article entity)
        {
            var delCount = Delete(entity.Id);

            return delCount;

        }

        public Article Get(int id)
        {
            var entity = _articleRepository.Get(id);
            if (entity == null)
                throw new EntityNotFoundException(id) {EntityType = typeof(Article) };
            return entity;
        }

        public IPagedResult<Article> GetList(string keywords, int tagId, int categoryId, 
            Paging paging)
        {
            var query = _articleRepository.GetAll();

            query = query
                .WhereIf(e => e.CategoryId == categoryId, dto.CategoryId.HasValue)
                .WhereIf(e => e.Title.Contains(keywords), !string.IsNullOrEmpty(keywords))
                .WhereIf(e => e.Tags.Contains( t => t.Id == tagId), tagId.HasValue);

            var totalCount = query.Count();

            return new PagedResultDto<Article>(totalCount, 
                query.SoringAndPaging(soring, paging).ToList());
        }

        public Article Add(Article entity)
        {
            return _articleRepository.Insert(entity);
        }

        public bool Publish(Article article)
        {
            if (CategoryDomainService.Get(article.CategoryId).State != CategoryStateEnum.Public)
            {
                throw new Comm100Exception(100101, "Article本身的状态不正确，不能进行此操作！");
            }
            if (article.State!=ArticleStateEnum.Audited)
            {
                throw new Comm100Exception(100100,"Article本身的状态不正确，不能进行此操作！");
            }
            article.State = ArticleStateEnum.Publish;
            _articleRepository.Update(article);
            return true;
        }

        public Article Update(Article entity)
        {
            return _articleRepository.Update(entity);
        }

        public IQueryable<Article> GetAll(Expression<Func<Article, bool>> predicate = null)
        {
            return _articleRepository.GetAll(predicate);
        }
    }
}
