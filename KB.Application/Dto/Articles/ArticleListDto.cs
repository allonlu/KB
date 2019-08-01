using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KB.Application.Dto.Articles
{
    public class ArticleListDto
    {
        public int id { get; set; }
        
        public string authorId { get; set; }

        public string categoryId { get; set; }

        public string title { get; set; }

        public int views { get; set; }
    }
}
