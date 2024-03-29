﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Comm100.Extension;
using Comm100.Runtime.Dto;
using Comm100.Web.Controllers;
using KB.Application.AppServices;
using KB.Application.Dto.Articles;
using KB.Application.Dto.Tags;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KB.Web.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class ArticlesController : Comm100ControllerBase
    {
        private IArticleAppService _articleAppService;
        public ArticlesController(IArticleAppService articleAppService)
        {
            _articleAppService = articleAppService;
        }
        [HttpPost]
        public ArticleDto Add([FromBody] ArticleCreateDto dto)
        {
            return _articleAppService.Add(dto);
        }

        [HttpGet]
        public IPagedResult<ArticleDto> GetList([FromQuery] ArticleQueryDto dto)
        {
            return _articleAppService.GetList(dto);
        }

        [HttpGet("{id}")]
        public ArticleDto Get(int id)
        {
            return _articleAppService.Get(id);
        }

        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            return _articleAppService.Delete(id);
        }
        [HttpPost("{articleId}/tags")]
        public TagDto AddTag(int articleId, [FromBody] AddTagDto dto)
        {
            return _articleAppService.AddTag(articleId, dto);
        }
        [HttpPost("{articleId}/tags/{tagId}")]
        public TagDto AddTag(int articleId, int tagId)

        {
            return _articleAppService.AddTag(new ArticleTagDto() { ArticleId = articleId, TagId = tagId });
        }
        [HttpDelete("{articleId}/tags/{tagId}")]
        public int DeleteTag(int articleId, int tagId)
        {
            return _articleAppService.DeleteTag(articleId, tagId);
        }
        [HttpDelete("{articleId}/tags")]
        public int DeleteTag(int articleId)
        {
            return _articleAppService.DeleteTag(articleId);
        }
        [HttpGet("{articleId}/tags")]
        public IList<TagDto> GetTags(int articleId)
        {

            return _articleAppService.GetTags(articleId);


        }
        [HttpPut("{id}")]
        public ArticleDto Update(int id,[FromBody] AddArticleDto dto)
        {
            var articleDto = dto.MapTo<ArticleDto>();
            articleDto.Id = id;
            return _articleAppService.Update(articleDto);
        }
        [HttpPut]
        public ArticleDto Update([FromBody] ArticleDto dto)
        {
            return _articleAppService.Update(dto);
        }
    }
}