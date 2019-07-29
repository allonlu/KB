﻿
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

namespace KB.Domain.DomainServices
{
    public class ArticleDomainService : DomainServiceBase, IArticleDomainService
    {
        private IRepository<Article> _articleRepository;

        [Mandatory]
        public IArticleTagDomainService ArticleTagDomainService { get; set; }

        [Mandatory]
        public ITagDomainService TagDomainService { get; set; }

        [Mandatory]
        public ICategoryDomainService CategoryDomainService { get; set; }
        public ArticleDomainService(
            IRepository<Article> articleRepository
            )
        {
            _articleRepository = articleRepository;
        }

        public int Delete(int articleId)
        {
            var delCount=  _articleRepository.Delete(articleId);
            delCount += ArticleTagDomainService.DeleteByArticle(articleId);
            return delCount;
        }

        public int Delete(Article entity)
        {
            var delCount = _articleRepository.Delete(entity);
            return delCount;

        }

        public Article Get(int id)
        {
            var entity = _articleRepository.Get(id);
            if (entity == null)
                throw new EntityNotFoundException(id) {EntityType = typeof(Article) };
            return entity;
        }

        public IQueryable<Article> GetAll(Expression<Func<Article, bool>> predicate)
        {
            return _articleRepository.GetAll(predicate);
        }

        public Article Add(Article entity)
        {
            return _articleRepository.Insert(entity);
        }

        public bool Public(Article article)
        {
            if (CategoryDomainService.Get(article.CategoryId).State != CategoryStateEnum.Audited)
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
    }
}
