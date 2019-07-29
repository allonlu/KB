using AutoMapper;
using AutoMapper.QueryableExtensions;
using KB.Application.Dto.Articles;
using KB.Domain.Entities;
using KB.Domain.DomainServices;
using System.Linq;
using KB.Application.Dto.Tags;
using System.Collections.Generic;
using System.Linq.Expressions;
using System;
using Comm100.Application.Services;
using Comm100.Runtime;

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
            ITagDomainService tagDomainService) 
        {
            _articleDomainService = articleDomainService;
            _articleTagDomainService = articleTagDomainService;
            _tagDomainService = tagDomainService;
        }


        [Permission("Article.Tag.Add")]
        public TagDto AddTag(ArticleTagDto dto)
        {

                var t = _articleTagDomainService.Add(Mapper.Map<ArticleTag>(dto));
                return Mapper.Map<TagDto>(t);
           
        }
        [Permission("Article.Tag.Add")]
        public TagDto AddTag(int articleId, AddTagDto tag)
        {

               var t= _articleTagDomainService.AddTag(articleId, Mapper.Map<Tag>(tag));
                return Mapper.Map<TagDto>(t);
           
        }
        [Permission("Article.Delete")]
        public int Delete(int articleId)
        {
            
                int delCount =_articleDomainService.Delete(articleId);

                return delCount;
        }
        [Permission("Article.Get")]
        public ArticleDto Get(int id)
        {
            
                var entity = _articleDomainService.Get(id);
                return Mapper.Map<ArticleDto>(entity);
          
        }

        private IQueryable<Article> Query(QueryArticleInput dto)
        {
            Expression<Func<Article, bool>> expression=null;

            if (!string.IsNullOrEmpty(dto.Title))
            {
                expression = e => e.Title.Contains(dto.Title);
            }
 
            return _articleDomainService.GetAll(expression);
                            
        }
        
        [Permission("Article.Get")]
        public IList<ArticleDto> GetList(QueryArticleInput dto)
        {
            
                var query = Query(dto).OrderBy(e => e.Id);

                return query.ProjectTo<ArticleDto>().ToList();
         

        }
        
        [Permission("Article.Get.Tag")]
        public IList<ArticleWithTagsDto> GetListWithTags(QueryArticleInput dto)
        {

            var list = Query(dto).ToList();
            var query1 = list.Select(
                                     t=> new ArticleWithTagsDto()
                                     {
                                         Id = t.Id,
                                         Title = t.Title,
                                         Description = t.Description,
                                         Tags = _articleTagDomainService.GetTags(t.Id).ProjectTo<TagDto>().ToList()
                                     });
            return query1.ToList();
        }

        [Permission("Article.Tag.Get")]
        public IList<TagDto> GetTags(int articleId)
        {
            
           return _articleTagDomainService.GetTags(articleId).ProjectTo<TagDto>().ToList();
           
        }
        [Permission("Article.Add")]
        public ArticleDto Add(AddArticleDto dto)
        {
           
                var entity = _articleDomainService.Add(Mapper.Map<Article>(dto));
                return Mapper.Map<ArticleDto>(entity);
          
        }

        [Permission("Article.Tag.Add")]
        public ArticleDto AddWithTags(AddArticleDto dto, IList<AddTagDto> tags)
        {
          
                var entity = _articleDomainService.Add(Mapper.Map<Article>(dto));
                _articleTagDomainService.AddTags(entity.Id, Mapper.Map<IList<Tag>>(tags));
                return Mapper.Map<ArticleDto>(entity);
        }
        [Permission("Article.Tag.Delete")]
        public int DeleteTag(int articleId, int tagId)
        {
             return  _articleTagDomainService.Delete(articleId, tagId);
        }

        [Permission("Article.Tag.Delete")]
        public int DeleteTag(int articleId)
        {
           
            return  _articleTagDomainService.DeleteByArticle(articleId);
 
        }
        [Permission("Article.Update")]
        public ArticleDto Update(ArticleDto dto)
        {

             var entity = _articleDomainService.Update(Mapper.Map<Article>(dto));
             return Mapper.Map<ArticleDto>(entity);
           
        }
        [Permission("Article.Get.Tag")]
        public ArticleWithTagsDto GetWithTags(int id)
        {
            var artitle = _articleDomainService.Get(id).MapTo<ArticleWithTagsDto>();
            artitle.Tags = _articleTagDomainService.GetTags(artitle.Id).Select(e=>e.MapTo<TagDto>()).ToList();
            return artitle;
        }
    }
}
