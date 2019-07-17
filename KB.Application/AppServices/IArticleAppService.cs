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
        IList<ArticleWithTagsDto> GetListWithTags();
        int Delete(int articleId);
        ArticleDto Update(ArticleDto dto);
        ArticleDto Insert(InsertArticleDto dto);
        ArticleDto InsertWithTags(InsertArticleDto dto, IList<TagDto> tags);

        //ArticleTag related
        IList<TagDto> GetTags(int articleId);
        void RemoveTag(ArticleTagDto dto);
        void AddTag(ArticleTagDto dto);
        void AddTag(int articleId, TagDto tag);

    }
}