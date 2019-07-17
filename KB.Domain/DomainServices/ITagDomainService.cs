using System.Linq;
using KB.Domain.Entities;

namespace KB.Domain.DomainServices
{
    public interface ITagDomainService : IDomainService
    {
        Tag Get(int tagId);
        IQueryable<Tag> GetAll();
        Tag Insert(Tag entity);
        Tag Update(Tag entity);
        int Delete(int tagId);
        int Delete(Tag entity);

    }
}