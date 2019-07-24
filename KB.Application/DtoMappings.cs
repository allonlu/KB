using AutoMapper;
using KB.Application.Dto.Articles;
using KB.Application.Dto.Categories;
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
            CreateMap<AddArticleDto, Article>();


            // Tag
            CreateMap<Tag, TagDto>();
            CreateMap<TagDto, Tag>();
            CreateMap<AddTagDto, Tag>();

            CreateMap<ArticleTagDto, ArticleTag>();

            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
            CreateMap<AddCategoryDto, Category>();


        }
    }
}
