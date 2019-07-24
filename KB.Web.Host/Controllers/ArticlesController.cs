using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using KB.Application.AppServices;
using KB.Application.Dto.Articles;
using KB.Application.Dto.Tags;
using KB.Infrastructure.ActionResult;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KB.Web.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class ArticlesController : ControllerBase
    {
        private IArticleAppService _articleAppService;
        public ArticlesController(IArticleAppService articleAppService)
        {
            _articleAppService = articleAppService;
        }
        [HttpPost]
        public MyActionResult<ArticleDto> Add([FromBody] AddArticleDto dto)
        {
                var entity = _articleAppService.Add(dto);
                return ActionResultHelper.Success(entity);
        }
        [HttpGet("~/api/[controller]:noTags")]
        public MyActionResult<IList<ArticleDto>> GetList([FromQuery] QueryArticleInput dto)
        {

            return Run(() =>
            {
                var list = _articleAppService.GetList(dto);
                return ActionResultHelper.Success(list);
            });

        }
        [HttpGet]
        public MyActionResult<IList<ArticleWithTagsDto>> GetListWithTags([FromQuery] QueryArticleInput dto)
        {

            return Run(() =>
            {
                var list = _articleAppService.GetListWithTags(dto);
                return ActionResultHelper.Success(list);
            });

        }
        [HttpGet("{id}")]
        public MyActionResult<ArticleDto> Get(int id)
        {

            return Run(() =>
            {
                var entity = _articleAppService.Get(id);
                return ActionResultHelper.Success(entity);
            });

        }

        [HttpDelete("{id}")]
        public MyActionResult<int> Delete(int id)
        {
            return Run(() =>
            {
                var d=_articleAppService.Delete(id);
                return (ActionResultHelper.Success(d));

            });
        }
        [HttpPost("{articleId}/tags")]
        public MyActionResult<TagDto> AddTag(int articleId, [FromBody] AddTagDto dto)
        {
            return Run(() =>
            {
               var t=  _articleAppService.AddTag(articleId, dto);

                return (ActionResultHelper.Success(t));

            });
        }
        [HttpPost("{articleId}/tags/{tagId}")]
        public MyActionResult<TagDto> AddTag(int articleId, int tagId)

        {
            return Run(() =>
            {
                var d = _articleAppService.AddTag(new ArticleTagDto() { ArticleId = articleId, TagId = tagId });
                return ActionResultHelper.Success(d);

            });
        }
        [HttpDelete("{articleId}/tags/{tagId}")]
        public MyActionResult<int> RemoveTag(int articleId, int tagId)

        {
           return  Run(() =>
            {
                var d =_articleAppService.DeleteTag(new ArticleTagDto() { ArticleId = articleId, TagId = tagId });
                return ActionResultHelper.Success(d);

        });
        }
        [HttpDelete("{articleId}/tags")]
        public MyActionResult<int> RemoveTag(int articleId)
        {
            return Run(() =>
            {
                var d = _articleAppService.DeleteTag(articleId);
                return ActionResultHelper.Success(d);

            });
        }
        [HttpGet("{articleId}/tags")]
        public MyActionResult<IList<TagDto>> GetTagsByArticle(int articleId)
        {
            return Run(() =>
            {
                var list = _articleAppService.GetTags(articleId);
                return ActionResultHelper.Success(list);

            });
        }
    }
}