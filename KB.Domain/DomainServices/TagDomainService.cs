using KB.Domain.Entities;
using KB.Domain.Repositories;
using KB.Domain.Uow;
using System;
using System.Linq;

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
            return _repository.Delete(tagId) ;
        }

        public int Delete(Tag entity)
        {
            return _repository.Delete(entity);
        }

        public Tag Get(int tagId)
        {
            return _repository.Get(tagId);
        }

        public IQueryable<Tag> GetAll()
        {
            return _repository.GetAll();
        }

        public Tag Insert(Tag entity)
        {
            //如果已经存在的名字，则直接使用这个实体，不创建。
            var e = _repository.GetAll().FirstOrDefault(t => t.Name == entity.Name);
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
