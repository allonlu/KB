
using Comm100.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KB.Application.Dto.Articles
{
   public class QueryArticleInput
    {
        public int? articleId { get; set; }

        [MaxLength(StringLength.MaxNameLength)]
        public string Title { get; set; }
    }
}
