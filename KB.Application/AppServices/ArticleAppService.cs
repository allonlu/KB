using AutoMapper;
using AutoMapper.QueryableExtensions;
using KB.Application.Dto.Articles;
using KB.Domain.Entities;
using KB.Domain.DomainServices;
using System.Linq;
using KB.Application.Dto.Tags;
using System.Collections.Generic;
using KB.Domain.Uow;
using KB.Infrastructure.Extension;
using KB.Infrastructure.Runtime.Authorization;

namespace KB.Application.AppServices
{
    /// <summary>
    /// 实现AOP编程
    /// </summary>
    public class ArticleAppService : AppServiceBase,IArticleAppService
    {
        private IArticleDomainService _articleDomainService;
        private IArticleTagDomainService _articleTagDomainService;
        private ITagDomainService _tagDomainService;
        public ArticleAppService(IArticleDomainService articleDomainService,
            IArticleTagDomainService articleTagDomainService,
            IUnitOfWorkManager unitOfWorkMananger,
            ITagDomainService tagDomainService) :base(unitOfWorkMananger)
        {
            _articleDomainService = articleDomainService;
            _articleTagDomainService = articleTagDomainService;
            _tagDomainService = tagDomainService;
        }


        [Permission("Article.Tag.Add")]
        public TagDto AddTag(ArticleTagDto dto)
        {

                var t = _articleTagDomainService.Insert(Mapper.Map<ArticleTag>(dto));
                return Mapper.Map<TagDto>(t);
           
        }
        [Permission("Article.Tag.Add")]
        public TagDto AddTag(int articleId, InsertTagDto tag)
        {

               var t= _articleTagDomainService.AddTag(articleId, Mapper.Map<Tag>(tag));
                return Mapper.Map<TagDto>(t);
           
        }
        [Permission("Article.Delete")]
        public int Delete(int articleId)
        {
            
                int delCount = _articleTagDomainService.DeleteByArticle(articleId);
                delCount += _articleDomainService.Delete(articleId);

                return delCount;
        }
        [Permission("Article.Read")]
        public ArticleDto Get(int id)
        {
            
                var entity = _articleDomainService.Get(id);
                return Mapper.Map<ArticleDto>(entity);
          
        }

        private IQueryable<Article> Query(ListArticleInputDto dto)
        {
            return _articleDomainService.GetAll()
                            .WhereIf(e => e.Title.Contains(dto.Title), !string.IsNullOrEmpty(dto.Title))
                            .WhereIf(e => e.Id == dto.articleId, dto.articleId.HasValue);
        }
        [Permission("Article.Read")]
        public IList<ArticleDto> GetList(ListArticleInputDto dto)
        {
            
                var query = Query(dto).OrderBy(e => e.Id);

                return query.ProjectTo<ArticleDto>().ToList();
         

        }
        [Permission("Article.Read")]
        public IList<ArticleWithTagsDto> GetListWithTags(ListArticleInputDto dto)
        {
            var query = from a in Query(dto)
                        from at in _articleTagDomainService.GetAll().Where(t => t.ArticleId == a.Id).DefaultIfEmpty()
                        from t in _tagDomainService.GetAll().Where(t => t.Id == at.TagId).DefaultIfEmpty()
                        select new { Article = a, Tag = t };

            var query1 = from t in query
                         group t by t.Article into g
                         select new ArticleWithTagsDto()
                         {
                             Id = g.Key.Id,
                             Title = g.Key.Title,
                             Description = g.Key.Description,
                             Tags = g.Where(e=>e.Tag!=null).Select(t => Mapper.Map<TagDto>(t.Tag)).ToList()
                   };
            return query1.ToList();
        }
        [Permission("Article.Read")]
        public IList<TagDto> GetTags(int articleId)
        {
            
           return _articleTagDomainService.GetTags(articleId).ProjectTo<TagDto>().ToList();
           
        }
        [Permission("Article.Insert")]
        public ArticleDto Insert(InsertArticleDto dto)
        {
           
                var entity = _articleDomainService.Insert(Mapper.Map<Article>(dto));
                return Mapper.Map<ArticleDto>(entity);
          
        }

        [Permission("Article.Tag.Insert")]
        public ArticleDto InsertWithTags(InsertArticleDto dto, IList<InsertTagDto> tags)
        {
          
                var entity = _articleDomainService.Insert(Mapper.Map<Article>(dto));
                _articleTagDomainService.AddTags(entity.Id, Mapper.Map<IList<Tag>>(tags));
                return Mapper.Map<ArticleDto>(entity);
           

        }
        [Permission("Article.Tag.Remove")]
        public int RemoveTag(ArticleTagDto dto)
        {
             return  _articleTagDomainService.Delete(dto.ArticleId, dto.TagId);
        }

        [Permission("Article.Tag.Remove")]
        public int RemoveTag(int articleId)
        {
           
            return  _articleTagDomainService.DeleteByArticle(articleId);
 
        }
        [Permission("Article.Update")]
        public ArticleDto Update(ArticleDto dto)
        {

             var entity = _articleDomainService.Update(Mapper.Map<Article>(dto));
             return Mapper.Map<ArticleDto>(entity);
           
        }
    }
}
