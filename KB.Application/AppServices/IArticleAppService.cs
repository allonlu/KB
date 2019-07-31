using Comm100.Application.Services;
using Comm100.Runtime.Dto;
using KB.Application.Dto.Articles;
using KB.Application.Dto.Tags;
using System.Collections.Generic;
using System.Linq;

namespace KB.Application.AppServices
{
    public interface IArticleAppService:IAppService
    {
        ArticleDto Get(int id);
        ArticleWithTagsDto GetWithTags(int Id);

        PagedResultDto<ArticleDto> GetList(QueryArticleInput dto);
        PagedResultDto<ArticleWithTagsDto> GetListWithTags(QueryArticleInput dto);
        int Delete(int articleId);
        ArticleDto Update(ArticleDto dto);
        ArticleDto Add(AddArticleDto dto);
        ArticleDto AddWithTags(AddArticleDto dto, IList<AddTagDto> tags);

        //ArticleTag related
        IList<TagDto> GetTags(int articleId);
        int DeleteTag(int articleId, int tagId);
        int DeleteTag(int articleId);
        TagDto AddTag(ArticleTagDto dto);
        TagDto AddTag(int articleId, AddTagDto tag);

    }
}