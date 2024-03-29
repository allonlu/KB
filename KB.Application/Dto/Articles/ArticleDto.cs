﻿using Comm100.Constants;
using KB.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace KB.Application.Dto.Articles
{
    public class ArticleDto
    {
        public int id { get; set; }

        public int authorId { get; set; }

        public string title { get; set; }

        public string content { get; set; }

        public int categoryId { get; set; }

        public string[] tags { get; set; }

        public int views { get; set; }

        public EnumArticleState state { get; set; }
        
    }
}
