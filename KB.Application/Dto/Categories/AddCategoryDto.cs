using KB.Domain.Entities;
using KB.Infrastructure.Constant;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KB.Application.Dto.Categories
{
   public class AddCategoryDto
    {
        [Required]
        [MaxLength(Constant.MaxNameLength)]
        public string Name { get; set; }

        public CategoryStateEnum State { get; set; }

    }
}
