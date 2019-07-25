﻿using KB.Infrastructure.Constant;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KB.Application.Dto.Articles
{
   public class QueryArticleInput
    {
        public int? articleId { get; set; }

        [MaxLength(Constant.MaxNameLength)]
        public string Title { get; set; }
    }
}