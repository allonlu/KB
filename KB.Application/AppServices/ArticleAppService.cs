using AutoMapper;
using AutoMapper.QueryableExtensions;
using KB.Application.Dto.Articles;
using KB.Domain.Entities;
using KB.Domain.DomainServices;
using System.Linq;
using KB.Application.Dto.Tags;
using System.Collections.Generic;
using KB.Domain.Uow;

namespace KB.Application.AppServices
{
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

   
        public void AddTag(ArticleTagDto dto)
        {
            //Permission("Article.AddTag");
            //_articleTagDomainService.Insert(Mapper.Map<ArticleTag>(dto));

            Run("Article.AddTag",() =>
            {
                _articleTagDomainService.Insert(Mapper.Map<ArticleTag>(dto));
            });
        }

        public void AddTag(int articleId, TagDto tag)
        {
            //Permission("Article.AddTag");
            //_articleTagDomainService.AddTag(articleId, Mapper.Map<Tag>(tag));
            Run("Article.AddTag", () =>
            {
                _articleTagDomainService.AddTag(articleId, Mapper.Map<Tag>(tag));
            });
        }

        public int Delete(int articleId)
        {
            //Permission("Article.Delete");
            //return  _articleDomainService.Delete(articleId);
            return Run("Article.Delete", () =>
            {
                int delCount = _articleTagDomainService.DeleteByArticle(articleId);
                delCount += _articleDomainService.Delete(articleId);

                return delCount;
               

            });
        }

        public ArticleDto Get(int id)
        {
            //Permission("Article.Read");
            //var entity = _articleDomainService.Get(id);
            //return Mapper.Map<ArticleDto>(entity);
            return Run("Article.Read", () =>
            {
                var entity = _articleDomainService.Get(id);
                return Mapper.Map<ArticleDto>(entity);
            });
        }

        public IList<ArticleDto> GetList(ListArticleInputDto dto)
        {
            return Run("Article.Read", () =>
            {
                var query = _articleDomainService.GetAll()
                .Where(e => e.Title.Contains(dto.Title)|| string.IsNullOrEmpty(dto.Title)).OrderBy(e => e.Id)
                ;
                return query.ProjectTo<ArticleDto>().ToList();
            });

            //Permission("Article.Read");
            //var query = _articleDomainService.GetAll().Where(e => e.Title.Contains(dto.Title)).OrderBy(e => e.Title);
            //return query.ProjectTo<ArticleDto>().ToList();
        }

        public IList<ArticleWithTagsDto> GetListWithTags()
        {
            var query = from a in _articleDomainService.GetAll()
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
                             Tags = g.Select(t => Mapper.Map<TagDto>(t.Tag)).ToList()
                   };
            return query1.ToList();
        }

        public IList<TagDto> GetTags(int articleId)
        {
            return Run("Article.Read", () =>
            {
                return _articleTagDomainService.GetTags(articleId).ProjectTo<TagDto>().ToList();
            });

            //Permission("Article.Read");
            //return _articleTagDomainService.GetTags(articleId).ProjectTo<TagDto>().ToList();
        }

        public ArticleDto Insert(InsertArticleDto dto)
        {
            //Permission("Article.Insert");
            //var entity = _articleDomainService.Insert(Mapper.Map<Article>(dto));
            //return Mapper.Map<ArticleDto>(entity);

            return Run("Article.Insert", () =>
            {
                var entity = _articleDomainService.Insert(Mapper.Map<Article>(dto));
                return Mapper.Map<ArticleDto>(entity);
            });
        }


        public ArticleDto InsertWithTags(InsertArticleDto dto, IList<TagDto> tags)
        {
            return Run("Article.Insert", () =>
            {
                var entity = _articleDomainService.Insert(Mapper.Map<Article>(dto));
                _articleTagDomainService.AddTags(entity.Id, Mapper.Map<IList<Tag>>(tags));
                return Mapper.Map<ArticleDto>(entity);
            });

            //using (var uow = _unitOfWorkManager.Begin())
            //{
            //    uow.SetSiteId(Session.GetSiteId());

            //    Permission("Article.Insert");
           
            //    var entity = _articleDomainService.Insert(Mapper.Map<Article>(dto));
            //    _articleTagDomainService.AddTags(entity.Id, Mapper.Map<IList<Tag>>(tags));
            //    uow.Complete();
            //    return Mapper.Map<ArticleDto>(entity);
            //}
        }

        public void RemoveTag(ArticleTagDto dto)
        {
            //Permission("Article.RemoveTag");
            //_articleTagDomainService.Delete(dto.ArticleId, dto.TagId);

            Run("Article.RemoveTag", () =>
            {
                _articleTagDomainService.Delete(dto.ArticleId, dto.TagId);
            });
        }

        public ArticleDto Update(ArticleDto dto)
        {
            //Permission("Article.Update");
            //var entity=  _articleDomainService.Update(Mapper.Map<Article>(dto));
            //return Mapper.Map<ArticleDto>(entity);

            return Run("Article.Update", () =>
            {
                var entity = _articleDomainService.Update(Mapper.Map<Article>(dto));
                return Mapper.Map<ArticleDto>(entity);
            });
        }
    }
}
