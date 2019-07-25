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
using System.Linq.Expressions;
using System;

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
        [Permission("Article.Read")]
        public ArticleDto Get(int id)
        {
            
                var entity = _articleDomainService.Get(id);
                return Mapper.Map<ArticleDto>(entity);
          
        }

        private IQueryable<Article> Query(QueryArticleInput dto)
        {
            Expression<Func<Article, bool>> expression=null;
            Expression<Func<Article, bool>> expression1;

            if (!string.IsNullOrEmpty(dto.Title))
            {
                expression = e => e.Title.Contains(dto.Title);
            }
            if (dto.articleId.HasValue)
            {

                expression1 = e => e.Id == dto.articleId;
                if (expression == null)
                    expression = expression1;
                else
                    expression = LambdaExpression.Lambda<Func<Article, bool>>(Expression.And(expression, expression1));
            }
            return _articleDomainService.GetAll(expression);
                            
        }
        [Permission("Article.Read")]
        public IList<ArticleDto> GetList(QueryArticleInput dto)
        {
            
                var query = Query(dto).OrderBy(e => e.Id);

                return query.ProjectTo<ArticleDto>().ToList();
         

        }
        [Permission("Article.Read")]
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

        [Permission("Article.Read")]
        public IList<TagDto> GetTags(int articleId)
        {
            
           return _articleTagDomainService.GetTags(articleId).ProjectTo<TagDto>().ToList();
           
        }
        [Permission("Article.Insert")]
        public ArticleDto Add(AddArticleDto dto)
        {
           
                var entity = _articleDomainService.Add(Mapper.Map<Article>(dto));
                return Mapper.Map<ArticleDto>(entity);
          
        }

        [Permission("Article.Tag.Insert")]
        public ArticleDto AddWithTags(AddArticleDto dto, IList<AddTagDto> tags)
        {
          
                var entity = _articleDomainService.Add(Mapper.Map<Article>(dto));
                _articleTagDomainService.AddTags(entity.Id, Mapper.Map<IList<Tag>>(tags));
                return Mapper.Map<ArticleDto>(entity);
           

        }
        [Permission("Article.Tag.Remove")]
        public int DeleteTag(ArticleTagDto dto)
        {
             return  _articleTagDomainService.Delete(dto.ArticleId, dto.TagId);
        }

        [Permission("Article.Tag.Remove")]
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
    }
}
