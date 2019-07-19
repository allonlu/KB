using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KB.Domain.Entities;
using KB.Domain.Repositories;
using KB.Domain.Uow;

namespace KB.Domain.DomainServices
{
    public class ArticleTagDomainService :DomainServiceBase, IArticleTagDomainService
    {
        public IRepository<ArticleTag> _repository;
        public IArticleDomainService _articleDomainService;
        public ITagDomainService _tagDomainService;
        public ArticleTagDomainService(IRepository<ArticleTag> repository,
                                        IArticleDomainService articleDomainService,
                                        ITagDomainService tagDomainService,
                                        IUnitOfWorkManager unitOfWorkManager):base(unitOfWorkManager)
        {
            _repository = repository;
            _articleDomainService =articleDomainService;
            _tagDomainService = tagDomainService;
            _unitOfWorkManager = unitOfWorkManager;
        }

        public Tag AddTag(int articleId, Tag tag)
        {
            using (var uow = _unitOfWorkManager.Begin())
            {
     
               var t=  AddTag(ValidateArticle(articleId), tag);

                uow.Complete();
                return t;
            }
        }
        private Article ValidateArticle(int articleId)
        {
            ///数据库上锁
            var article = _articleDomainService.Get(articleId);
            if (article == null)
                throw new Exception("Article资源不存在！");
            return article;

        }
        public Tag AddTag(int articleId, int tagId)
        {
            if(_repository.Exists(e=>e.ArticleId==articleId && e.TagId == tagId))
            {
                throw new Exception("关系已经存在，不允许重复添加！");
            }
             _repository.Insert(new ArticleTag() { ArticleId = articleId, TagId = tagId });
            return _tagDomainService.Get(tagId);
        }

        public void AddTags(int articleId, IList<Tag> tags)
        {
            using (var uow = _unitOfWorkManager.Begin())
            {
                ///数据库上锁
                var article = ValidateArticle(articleId);

                foreach (var t in tags)
                {
                    AddTag(article, t);
                }

                uow.Complete();
            }
        }
        private Tag AddTag(Article article,Tag tag)
        {
            var newTag = _tagDomainService.Insert(tag);

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
            return _repository.GetAll().FirstOrDefault(e => e.ArticleId == articleId && e.TagId == tagId);
        }

        public IQueryable<Article> GetArticles(int tagId)
        {
            var query = from at in _repository.GetAll()
                        join t in _articleDomainService.GetAll() on at.ArticleId equals t.Id
                        where at.TagId == tagId
                        select t;
            return query;
        }

        public IQueryable<Tag> GetTags(int articleId)
        {
            var query = from at in _repository.GetAll()
                        join t in _tagDomainService.GetAll() on at.TagId equals t.Id
                        where at.ArticleId == articleId
                        select t;
            return query;
        }

        public ArticleTag Insert(ArticleTag entity)
        {
            return _repository.Insert(entity);
        }

        public IQueryable<ArticleTag> GetAll()
        {
            return _repository.GetAll();

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
