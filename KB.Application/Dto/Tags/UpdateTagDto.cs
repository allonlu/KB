
using Comm100.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KB.Application.Dto.Tags
{
    public class UpdateTagDto
    {
        [Required]
        [MaxLength(StringLength.MaxNameLength)]
        public string Name { get; set; }
    }
}
