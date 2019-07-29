using System;
using System.Linq;
using System.Linq.Expressions;
using KB.Domain.Entities;
using Comm100.Domain.Services;

namespace KB.Domain.DomainServices
{
    public interface ITagDomainService : IDomainService
    {
        Tag Get(int tagId);
        IQueryable<Tag> GetAll(Expression<Func<Tag, bool>> predicate);
        Tag Insert(Tag entity);
        Tag Update(Tag entity);
        int Delete(int tagId);
        int Delete(Tag entity);

    }
}