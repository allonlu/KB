using AutoMapper;
using AutoMapper.QueryableExtensions;
using KB.Application.Dto.Tags;
using KB.Domain.DomainServices;
using KB.Domain.Entities;
using KB.Domain.Uow;
using System.Collections.Generic;
using System.Linq;

namespace KB.Application.AppServices
{
    public class TagAppService : AppServiceBase, ITagAppService
    {
        private ITagDomainService _tagDomainService;
        public TagAppService(ITagDomainService tagDomainService,
                            IUnitOfWorkManager unitOfWorkManager
            
            ):base(unitOfWorkManager)
        {
            _tagDomainService = tagDomainService;
        }

        public int Delete(int tagId)
        {
            Permission("Tag.Delete");
            return _tagDomainService.Delete(tagId);
        }

        public TagDto Get(int tagId)
        {
            Permission("Tag.Read");
            return Mapper.Map<TagDto>(_tagDomainService.Get(tagId));
        }

        public IList<TagDto> GetList(ListTagInputDto dto)
        {
            Permission("Tag.Read");
            return _tagDomainService.GetAll()
                        .Where(t => t.Name.Contains(dto.Name))
                        .ProjectTo<TagDto>()
                        .ToList();
        }

        public TagDto Insert(InsertTagDto dto)
        {
            Permission("Tag.Insert");
            var entity = _tagDomainService.Insert(Mapper.Map<Tag>(dto));
            return Mapper.Map<TagDto>(entity);
        }

        public TagDto Update(TagDto dto)
        {
            Permission("Tag.Update");
            var entity = _tagDomainService.Update(Mapper.Map<Tag>(dto));
            return Mapper.Map<TagDto>(entity);

        }
    }
}
