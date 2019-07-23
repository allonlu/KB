using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KB.Domain.Entities;
using KB.Domain.Repositories;
using KB.Domain.Uow;

namespace KB.Domain.DomainServices
{
    public class CategoryDomainService :DomainServiceBase, ICategoryDomainService
    {
        private IRepository<Category> _repository;
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

        public IQueryable<Category> GetAll()
        {
            return _repository.GetAll();
        }

        public Category Insert(Category category)
        {
            return _repository.Insert(category);
        }

        public Category Update(Category category)
        {
            return _repository.Update(category);
        }
    }
}
