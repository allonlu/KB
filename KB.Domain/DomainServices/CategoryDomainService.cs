using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using KB.Domain.Entities;
using Comm100.Domain.Services;
using Comm100.Domain.Repository;
using Comm100.Domain.Ioc;
using Comm100.Domain.Uow;
using Comm100.Runtime.Exception;

namespace KB.Domain.DomainServices
{

    public class CategoryDomainService :DomainServiceBase, ICategoryDomainService
    {
        private readonly IRepository<Category> _repository;
        private readonly IRepository<Article> _articleRepository;

        [Mandatory]
        public  IArticleDomainService ArticleDomainService { get; set; }
        public CategoryDomainService(IRepository<Category> repository, IRepository<Article> articleRepository)
        {
            this._repository = repository;
            this._articleRepository = articleRepository;
        }
        public int Delete(Category category)
        {
           return _repository.Delete(category);
        }

        public int Delete(int id)
        {
            return _repository.Delete(id);
        }

        public Category Get(int id)
        {
            var entity= _repository.Get(id);
            if (entity == null)
                throw new EntityNotFoundException(id, typeof(Category));
            entity.Articles = ArticleDomainService.GetAll(e => e.CategoryId == entity.Id).ToList();
            return entity;
        }



        public IQueryable<Category> GetAll(Expression<Func<Category,bool>> predicate)
        {
            return _repository.GetAll(predicate);
        }

        public Category Add(Category category)
        {
            return _repository.Insert(category);
        }

        public Category Update(Category category)
        {
            return _repository.Update(category);
        }

        public IQueryable<Article> GetArticles(int categoryId)
        {
            return _articleRepository.GetAll(e => e.CategoryId == categoryId);
        }
    }
}
