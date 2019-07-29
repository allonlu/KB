using Comm100.Domain.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KB.Domain.Entities
{
    [TableSwitch]
    public class ArticleTag : IEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ArticleId { get; set; }

        //[ForeignKey(nameof(ArticleId))]
        //public virtual Article Article { get; set; }

        [Required]
        public int TagId { get; set; }

        //[ForeignKey(nameof(TagId))]
        //public virtual Tag Tag { get; set; }


    }
}
