using KB.Infrastructure.Constant;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KB.Application.Dto.Tags
{
    public class UpdateTagDto
    {
        [Required]
        [MaxLength(Constant.MaxNameLength)]
        public string Name { get; set; }
    }
}
