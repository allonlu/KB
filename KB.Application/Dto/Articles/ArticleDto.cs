using Comm100.Constants;
using KB.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace KB.Application.Dto.Articles
{
    
    public class ArticleDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(StringLength.MaxNameLength)]
        public string Title { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [MaxLength(StringLength.MaxNameLength)]
        public string Description { get; set; }
        public ArticleStateEnum State { get; set; }
    }
}
