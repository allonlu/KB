﻿
using Comm100.Constants;
using Comm100.Runtime.Dto;
using KB.Domain.DomainServices.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KB.Application.Dto.Articles
{
    public class ArticleQueryDto
    {
        public string tag { get; set; } 

        public int? categoryId { get; set; }
        
        public string keywords { get; set; }
    }
}
