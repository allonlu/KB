using KB.Domain.Entities;
using KB.Infrastructure.Constant;
using System.ComponentModel.DataAnnotations;

namespace KB.Application.Dto.Articles
{
    
    public class ArticleDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(Constant.MaxNameLength)]
        public string Title { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [MaxLength(Constant.MaxNameLength)]
        public string Description { get; set; }
        public ArticleStateEnum State { get; set; }
    }
}
