using KB.Application.Dto.Articles;
using KB.Application.Dto.Tags;
using System.Collections.Generic;
using System.Linq;

namespace KB.Application.AppServices
{
    public interface IArticleAppService:IAppService
    {
        ArticleDto Get(int id);
        IList<ArticleDto> GetList(ListArticleInputDto dto);
        IList<ArticleWithTagsDto> GetListWithTags(ListArticleInputDto dto);
        int Delete(int articleId);
        ArticleDto Update(ArticleDto dto);
        ArticleDto Insert(InsertArticleDto dto);
        ArticleDto InsertWithTags(InsertArticleDto dto, IList<InsertTagDto> tags);

        //ArticleTag related
        IList<TagDto> GetTags(int articleId);
        int RemoveTag(ArticleTagDto dto);
        int RemoveTag(int articleId);
        TagDto InsertTag(ArticleTagDto dto);
        TagDto InsertTag(int articleId, InsertTagDto tag);

    }
}