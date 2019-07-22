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
                var list = _articleAppService.GetListWithTags(new ListArticleInputDto());
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


            return Run(() =>
            {
                var list = _articleAppService.GetList(dto);
                return Json(ActionResultHelper.Success(list));
            });
            
        }
        [HttpPost("Article/AddTag/{articleId}")]
        public IActionResult AddTag(int articleId, InsertTagDto dto)
        {
            Run(()=>
            {
                _articleAppService.InsertTag(articleId, dto);

            });
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            Run(() =>
            {
                _articleAppService.Delete(id);

            });
            return RedirectToAction("Index");
        }
        public IActionResult RemoveTag(ArticleTagDto dto)
                
        {
            Run(()=>
            {
                _articleAppService.RemoveTag(dto);

            });
            return RedirectToAction("Index");
        }
        public IActionResult Get(int id)
        {
            return Run(() =>
            {
               var article = _articleAppService.Get(id);
               return Json(ActionResultHelper.Success(article));
            });
        }
    }
}