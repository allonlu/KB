
using Comm100.Constants;
using System.ComponentModel.DataAnnotations;

namespace KB.Application.Dto.Tags
{
    public class TagDto
    {

        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(StringLength.MaxNameLength)]
        public string Name { get; set; }
    }
}
