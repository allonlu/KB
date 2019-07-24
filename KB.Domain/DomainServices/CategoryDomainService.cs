using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using KB.Domain.Entities;
using KB.Domain.Repositories;
using KB.Domain.Uow;
using KB.Infrastructure.Ioc;

namespace KB.Domain.DomainServices
{

    public class CategoryDomainService :DomainServiceBase, ICategoryDomainService, IDomainService
    {
        private IRepository<Category> _repository;

        [Mandatory]
        public IArticleDomainService ArticleDomainService { get; set; }
        public CategoryDomainService(IRepository<Category> repository,IUnitOfWorkManager unitOfWorkManager):base(unitOfWorkManager)
        {
            _repository = repository;
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
            return _repository.Get(id);
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
            return ArticleDomainService.GetAll(e => e.CategoryId == categoryId);
        }
    }
}
