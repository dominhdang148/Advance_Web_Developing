﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TatBlog.Core.DTO
{
    public class PostDateItem
    {
        public int Month { get; set; }
        public string MonthName { get; set; }
        public int Year { get; set; }
        public int PostCount { get; set; }
    }
}
