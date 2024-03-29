﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using KB.Domain.Entities;
using Comm100.Domain.Services;
using Comm100.Domain.Repository;
using Comm100.Domain.Ioc;
using Comm100.Domain.Uow;
using Comm100.Runtime.Exception;

namespace KB.Domain.DomainServices
{
    public class ArticleTagDomainService :DomainServiceBase, IArticleTagDomainService
    {
        public readonly IRepository<ArticleTag> _repository;
        private readonly IRepository<Article> _articleRepository;

        public IArticleDomainService ArticleDomainService { get; set; }
        public ITagDomainService TagDomainService { get; set; }
        public ArticleTagDomainService(IRepository<ArticleTag> repository, IRepository<Article> articleRepository)
        {
            this._repository = repository;
            this._articleRepository = articleRepository;
        }

        public Tag AddTag(int articleId, Tag tag)
        {
         
               var t=  AddTag(ValidateArticle(articleId), tag);
                return t;
            
        }
        private Article ValidateArticle(int articleId)
        {
          
           return  ArticleDomainService.Get(articleId);

        }
        public Tag AddTag(int articleId, int tagId)
        {
            if(_repository.Exists(e=>e.ArticleId==articleId && e.TagId == tagId))
            {
                throw new Comm100Exception(200009,"关系已经存在，不允许重复添加！");
            }
             _repository.Insert(new ArticleTag() { ArticleId = articleId, TagId = tagId });
            return TagDomainService.Get(tagId);
        }

        public void AddTags(int articleId, IList<Tag> tags)
        {
          
             
                var article = ValidateArticle(articleId);

                foreach (var t in tags)
                {
                    AddTag(article, t);
                }

        
        }
        private Tag AddTag(Article article,Tag tag)
        {
            var newTag = TagDomainService.Insert(tag);

            return  AddTag(article.Id, newTag.Id);

        }
        public int Delete(ArticleTag entity)
        {
            return _repository.Delete(entity);
        
        }

        public int Delete(int id)
        {
            return _repository.Delete(id);

        }


        public int Delete(int articleId, int tagId)
        {
             var entity = this.Get(articleId, tagId);
            return _repository.Delete(entity);
        }

        public ArticleTag Get(int articleId, int tagId)
        {
            return _repository.GetAll(e => e.ArticleId == articleId && e.TagId == tagId).FirstOrDefault();
        }

        public IQueryable<Article> GetArticles(int tagId)
        {
            var query = from at in _repository.GetAll(e=>e.TagId == tagId)
                        join t in _articleRepository.GetAll(null) on at.ArticleId equals t.Id
                        select t;
            return query;
        }

        public IQueryable<Tag> GetTags(int articleId)
        {
            var query = from at in _repository.GetAll(e => e.ArticleId == articleId)
                        join t in TagDomainService.GetAll(null) on at.TagId equals t.Id
                        select t;
            return query;
        }

        public ArticleTag Add(ArticleTag entity)
        {
            return _repository.Insert(entity);
        }

        public IQueryable<ArticleTag> GetAll(Expression<Func<ArticleTag,bool>> predicate)
        {
            return _repository.GetAll(predicate);

        }

        public int DeleteByArticle(int articleId)
        {
            return _repository.Delete(e => e.ArticleId == articleId);
        }

        public int DeleteByTag(int tagId)
        {
            return _repository.Delete(e => e.TagId == tagId);
        }
    }
}
