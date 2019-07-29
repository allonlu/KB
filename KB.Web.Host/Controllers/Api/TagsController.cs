using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KB.Application.AppServices;
using KB.Application.Dto.Tags;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Comm100.Extension;

namespace KB.Web.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class TagsController : ControllerBase
    {
        private readonly ITagAppService _tagAppService;

        public TagsController(ITagAppService tagAppService)
        {
            this._tagAppService = tagAppService;
        }
        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            return _tagAppService.Delete(id);
        }
        [HttpGet("{id}")]
        public TagDto Get(int id)
        {
            return _tagAppService.Get(id);
        }
        [HttpGet()]
        public IList<TagDto> GetList(QueryTagInput dto)
        {
            return _tagAppService.GetList(dto);
        }
        [HttpPost]
        public TagDto Add(AddTagDto dto)
        {
            return _tagAppService.Add(dto);
        }
        [HttpPut]
        public TagDto Update(TagDto dto)
        {
            return _tagAppService.Update(dto);
        }
        [HttpPut("{id}")]
        public TagDto Update(int id,UpdateTagDto dto)
        {
            var tagDto = dto.MapTo<TagDto>();
            tagDto.Id = id;
            return _tagAppService.Update(tagDto);
        }
    }
}