using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper.QueryableExtensions;
using Comm100.Application.Services;
using Comm100.Extension;
using Comm100.Runtime;
using KB.Application.Dto.Articles;
using KB.Application.Dto.Categories;
using KB.Domain.DomainServices;
using KB.Domain.Entities;

namespace KB.Application.AppServices
{
    public class CategoryAppService : AppServiceBase,ICategoryAppService
    {
        private readonly ICategoryDomainService _categoryDomainService;

        public CategoryAppService(ICategoryDomainService categoryDomainService)
        {
            this._categoryDomainService = categoryDomainService;
        }
        [Permission("Category.Add")]
        public CategoryDto Add(AddCategoryDto dto)
        {
           var entity= _categoryDomainService.Add(dto.MapTo<Category>());
            return entity.MapTo<CategoryDto>();
        }
        [Permission("Category.Delete")]
        public int Delete(int id)
        {
            return _categoryDomainService.Delete(id);
        }
        [Permission("Category.Article.Get")]
        public IList<ArticleDto> GetArticles(int categoryId)
        {
            return _categoryDomainService.GetArticles(categoryId).ProjectTo<ArticleDto>().ToList();
        }
        [Permission("Category.Get")]
        public IList<CategoryDto> GetList()
        {
            return _categoryDomainService.GetAll(null).ProjectTo<CategoryDto>().ToList();
        }

        [Permission("Category.Update")]
        public CategoryDto Update(CategoryDto dto)
        {
            return _categoryDomainService.Update(dto.MapTo<Category>()).MapTo<CategoryDto>();
        }
    }
}
