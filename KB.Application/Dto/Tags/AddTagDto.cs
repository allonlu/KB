using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KB.Infrastructure.Constant;

namespace KB.Application.Dto.Tags
{
   public  class AddTagDto
    {
        [Required]
        [MaxLength(Constant.MaxNameLength)]
        public string Name { get; set; }
    }
}
