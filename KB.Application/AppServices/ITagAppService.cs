using KB.Application.Dto.Tags;
using System.Collections.Generic;
using System.Linq;

namespace KB.Application.AppServices
{
    public interface ITagAppService: IAppService { 
        TagDto Get(int tagId);
        IList<TagDto> GetList(ListTagInputDto dto);
        TagDto Insert(InsertTagDto dto);
        TagDto Update(TagDto dto);
        int Delete(int tagId);

    }
}