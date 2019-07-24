using KB.Domain.Entities;
using KB.Infrastructure.Constant;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KB.Application.Dto.Categories
{
    public class CategoryDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(Constant.MaxNameLength)]
        public string Name { get; set; }

        public CategoryStateEnum State { get; set; }

    }
}
