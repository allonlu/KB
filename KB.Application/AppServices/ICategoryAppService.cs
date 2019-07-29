using Comm100.Application.Services;
using KB.Application.Dto.Articles;
using KB.Application.Dto.Categories;
using System;
using System.Collections.Generic;
using System.Text;

namespace KB.Application.AppServices
{
    public interface ICategoryAppService:IAppService
    {
        IList<CategoryDto> GetList();
        CategoryDto Add(AddCategoryDto dto);
        CategoryDto Update(CategoryDto dto);

        int Delete(int id);

        IList<ArticleDto> GetArticles(int categoryId);


    }
}
