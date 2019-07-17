using KB.Application.AppServices;
using KB.Application.Dto.Articles;
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
        public ActionResult Index()
        {
            return Run(() =>
            {
                var list = _articleAppService.GetList(new ListArticleInputDto());
                return View(list);
            });


        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(InsertArticleDto dto)
        {
           

            return Run(() =>
            {
                var list = _articleAppService.Insert(dto);
                return RedirectToAction("Index");
            });
        }
        public ActionResult GetList(ListArticleInputDto dto)
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
        public ActionResult Get(int id)
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