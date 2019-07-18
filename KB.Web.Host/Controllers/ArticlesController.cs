using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KB.Application.AppServices;
using KB.Application.Dto.Articles;
using KB.Application.Dto.Tags;
using KB.Infrastructure.ActionResult;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KB.Web.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private IArticleAppService _articleAppService;
        public ArticlesController(IArticleAppService articleAppService)
        {
            _articleAppService = articleAppService;
        }
        [HttpPost]
        public MyActionResult<ArticleDto> Add([FromBody] InsertArticleDto dto)
        {

            return Run(() =>
            {
                var entity = _articleAppService.Insert(dto);
                return ActionResultHelper.Success(entity);
            });
        }
        [HttpGet("find")]
        public MyActionResult<IList<ArticleDto>> GetList([FromQuery] ListArticleInputDto dto)
        {

            return Run(() =>
            {
                var list = _articleAppService.GetList(dto);
                return ActionResultHelper.Success(list);
            });

        }
        [HttpGet]
        public MyActionResult<IList<ArticleWithTagsDto>> GetListWithTags()
        {

            return Run(() =>
            {
                var list = _articleAppService.GetListWithTags();
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
        [HttpPost("{articleId}:AddTag")]
        public MyActionResult<bool> AddTag(int articleId, [FromBody] TagDto dto)
        {
            return Run(() =>
           {
               _articleAppService.AddTag(articleId, dto);

               return (ActionResultHelper.Success(true));

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
        [HttpDelete("{articleId}:RemoveTag")]
        public MyActionResult<bool> RemoveTag(int articleId, int tagId)

        {
           return  Run(() =>
            {
                _articleAppService.RemoveTag(new ArticleTagDto() { ArticleId = articleId, TagId = tagId });
                return ActionResultHelper.Success(true);

        });
        }
    }
}