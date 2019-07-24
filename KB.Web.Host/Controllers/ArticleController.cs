using KB.Application.AppServices;
using KB.Application.Dto.Articles;
using KB.Application.Dto.Tags;
using KB.Infrastructure.ActionResult;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace KB.Web.Host.Controllers
{
    public class ArticleController : ControllerBase
    {
        private IArticleAppService _articleAppService;
        private readonly ICategoryAppService _categoryAppService;

        public ArticleController(IArticleAppService articleAppService,ICategoryAppService categoryAppService)
        {
            this._articleAppService = articleAppService;
            this._categoryAppService = categoryAppService;
        }
        // GET: Article
        public IActionResult Index()
        {
            
                var list = _articleAppService.GetListWithTags(new QueryArticleInput());
                return View(list);
            


        }

        [HttpGet]
        public IActionResult Add()
        {
            var selelctItems = _categoryAppService.GetList().Select(e =>new SelectListItem(e.Name,e.Id.ToString())).AsEnumerable();

  
            return View(selelctItems);
        }
        [HttpPost]
        public IActionResult Add(AddArticleDto dto)
        {
           

                var list = _articleAppService.Add(dto);
                return RedirectToAction("Index");
           
        }
        public IActionResult GetList(QueryArticleInput dto)
        {
                var list = _articleAppService.GetList(dto);
                return Json(ActionResultHelper.Success(list));
        }
        [HttpPost("Article/AddTag/{articleId}")]
        public IActionResult AddTag(int articleId, AddTagDto dto)
        {
          
            _articleAppService.AddTag(articleId, dto);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
       
            _articleAppService.Delete(id);
            return RedirectToAction("Index");
        }
        public IActionResult RemoveTag(ArticleTagDto dto)
                
        {
            
            _articleAppService.DeleteTag(dto);
            return RedirectToAction("Index");
        }
        public IActionResult Get(int id)
        {
         
               var article = _articleAppService.Get(id);
               return Json(ActionResultHelper.Success(article));
            
        }
    }
}