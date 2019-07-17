using System.ComponentModel.DataAnnotations;

namespace KB.Domain.Entities
{
    public class ArticleTag : IEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ArticleId { get; set; }
        [Required]
        public int TagId { get; set; }


    }
}
