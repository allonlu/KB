using KB.Application.AppServices;
using KB.Application.Dto.Articles;
using KB.Application.Dto.Tags;
using KB.Infrastructure.ActionResult;
using Microsoft.AspNetCore.Mvc;

namespace KB.Web.Host.Controllers
{
    public class ArticleController : ControllerBase
    {
        private IArticleAppService _articleAppService;
        public ArticleController(IArticleAppService articleAppService)
        {
            _articleAppService = articleAppService;
        }
        // GET: Article
        public IActionResult Index()
        {
            return Run(() =>
            {
                var list = _articleAppService.GetListWithTags();
                return View(list);
            });


        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(InsertArticleDto dto)
        {
           

            return Run(() =>
            {
                var list = _articleAppService.Insert(dto);
                return RedirectToAction("Index");
            });
        }
        public IActionResult GetList(ListArticleInputDto dto)
        {
            //try
            //{
            //    var list= _articleAppService.GetList(dto);
            //    return Json(ActionResultHelper.Success(list));
            //}
            //catch(Exception e)
            //{
            //    Logger.Error(e.Message);
            //    return Json(ActionResultHelper.Fail(e));

            //}

            return Run(() =>
            {
                var list = _articleAppService.GetList(dto);
                return Json(ActionResultHelper.Success(list));
            });
            
        }
        [HttpPost("Article/AddTag/{articleId}")]
        public IActionResult AddTag(int articleId, TagDto dto)
        {
            return Run(() =>
            {
                _articleAppService.AddTag(articleId, dto);

                return RedirectToAction("Index");

            });
        }
        public IActionResult Get(int id)
        {
            return Run(() =>
            {
               var article = _articleAppService.Get(id);
               return Json(ActionResultHelper.Success(article));
            });
            //try
            //{
            //    var article = _articleAppService.Get(id);
            //    return Json(ActionResultHelper.Success(article));
            //}
            //catch (Exception e)
            //{
            //    Logger.Error(e.Message);
            //    return Json(ActionResultHelper.Fail(e));

            //}
        }
    }
}