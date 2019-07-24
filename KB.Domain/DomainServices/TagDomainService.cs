using KB.Domain.Entities;
using KB.Domain.Repositories;
using KB.Domain.Uow;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace KB.Domain.DomainServices
{
    public class TagDomainService :DomainServiceBase, ITagDomainService
    {
        private IRepository<Tag> _repository;
        public TagDomainService(IRepository<Tag> repository,
            IUnitOfWorkManager unitOfWorkManager
            ) : base(unitOfWorkManager)
        {
            _repository = repository;
        }

        public int Delete(int tagId)
        {
            var delCount= _repository.Delete(tagId) ;
            return delCount;
        }

        public int Delete(Tag entity)
        {
            var delCount = _repository.Delete(entity);
            return delCount;
        }

        public Tag Get(int tagId)
        {
            return _repository.Get(tagId);
        }

        public IQueryable<Tag> GetAll(Expression<Func<Tag, bool>> predicate)
        {
            return _repository.GetAll(predicate);
        }

        public Tag Insert(Tag entity)
        {
            //如果已经存在的名字，则直接使用这个实体，不创建。
            var e = _repository.GetAll(t => t.Name == entity.Name).FirstOrDefault();
            if (e != null)
                return e;

            return _repository.Insert(entity);
        }

        public Tag Update(Tag entity)
        {
            return _repository.Update(entity);
        }
    }
}
