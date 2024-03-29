﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using Comm100.Application.Services;
using Comm100.Runtime;
using KB.Application.Dto.Tags;
using KB.Domain.DomainServices;
using KB.Domain.Entities;
using KB.Infrastructure.Runtime.Authorization;
using System.Collections.Generic;
using System.Linq;

namespace KB.Application.AppServices
{
    public class TagAppService : AppServiceBase, ITagAppService
    {
        private ITagDomainService _tagDomainService;
        public TagAppService(ITagDomainService tagDomainService
            
            )
        {
            _tagDomainService = tagDomainService;
        }

        [Permission("Tag.Delete")]
        public int Delete(int tagId)
        {
            return _tagDomainService.Delete(tagId);
        }
        [Permission("Tag.Get")]
        public TagDto Get(int tagId)
        {
            return Mapper.Map<TagDto>(_tagDomainService.Get(tagId));
        }
        [Permission("Tag.Get")]
        public IList<TagDto> GetList(QueryTagInput dto)
        {
            return _tagDomainService.GetAll(t => t.Name.Contains(dto.Name))
                        .ProjectTo<TagDto>()
                        .ToList();
        }
        [Permission("Tag.Add")]
        public TagDto Add(AddTagDto dto)
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
