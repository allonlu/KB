using AutoMapper;
using KB.Application.Dto.Articles;
using KB.Application.Dto.Tags;
using KB.Domain.Entities;

namespace KB.Application
{
    public class DtoMappings : Profile
    {
        public DtoMappings()
        {
            // Article
            CreateMap<Article, ArticleDto>();
            CreateMap<ArticleDto, Article>();
            CreateMap<InsertArticleDto, Article>();

      

            // Tag
            CreateMap<Tag, TagDto>();
            CreateMap<TagDto, Tag>();
            CreateMap<InsertTagDto, Tag>();

            CreateMap<ArticleTagDto, ArticleTag>();
        }
    }
}
