using KB.Infrastructure.Constant;
using System.ComponentModel.DataAnnotations;

namespace KB.Application.Dto.Tags
{
    public class TagDto
    {

        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(Constant.MaxNameLength)]
        public string Name { get; set; }
    }
}
