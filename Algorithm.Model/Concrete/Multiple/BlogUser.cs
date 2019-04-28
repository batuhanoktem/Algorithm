﻿using Algorithm.Model.Concrete.Sub;
using Algorithm.Model.Enum;

namespace Algorithm.Model.Concrete.Multiple
{
    public class BlogUser
    {
        public Sub.Blog BlogId { get; set; }
        public User UserId { get; set; }
        public Content ContentType { get; set; }
    }
}