using KB.Application.Dto.Articles;
using KB.Application.Dto.Tags;
using System.Collections.Generic;
using System.Linq;

namespace KB.Application.AppServices
{
    public interface IArticleAppService:IAppService
    {
        ArticleDto Get(int id);
        IList<ArticleDto> GetList(QueryArticleInput dto);
        IList<ArticleWithTagsDto> GetListWithTags(QueryArticleInput dto);
        int Delete(int articleId);
        ArticleDto Update(ArticleDto dto);
        ArticleDto Add(AddArticleDto dto);
        ArticleDto AddWithTags(AddArticleDto dto, IList<AddTagDto> tags);

        //ArticleTag related
        IList<TagDto> GetTags(int articleId);
        int DeleteTag(ArticleTagDto dto);
        int DeleteTag(int articleId);
        TagDto AddTag(ArticleTagDto dto);
        TagDto AddTag(int articleId, AddTagDto tag);

    }
}