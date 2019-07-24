using AutoMapper;
using AutoMapper.QueryableExtensions;
using KB.Application.Dto.Tags;
using KB.Domain.DomainServices;
using KB.Domain.Entities;
using KB.Domain.Uow;
using KB.Infrastructure.Runtime.Authorization;
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

        [Permission("Tag.Delete")]
        public int Delete(int tagId)
        {
            return _tagDomainService.Delete(tagId);
        }
        [Permission("Tag.Read")]
        public TagDto Get(int tagId)
        {
            return Mapper.Map<TagDto>(_tagDomainService.Get(tagId));
        }
        [Permission("Tag.Read")]
        public IList<TagDto> GetList(QueryTagInput dto)
        {
            return _tagDomainService.GetAll(t => t.Name.Contains(dto.Name))
                        .ProjectTo<TagDto>()
                        .ToList();
        }
        [Permission("Tag.Insert")]
        public TagDto Insert(AddTagDto dto)
        {
            var entity = _tagDomainService.Insert(Mapper.Map<Tag>(dto));
            return Mapper.Map<TagDto>(entity);
        }
        [Permission("Tag.Update")]
        public TagDto Update(TagDto dto)
        {
            var entity = _tagDomainService.Update(Mapper.Map<Tag>(dto));
            return Mapper.Map<TagDto>(entity);

        }
    }
}
