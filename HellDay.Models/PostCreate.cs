﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HellDay.Models
{
    public class PostCreate
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public Guid UserId { get; set; }
    }
}
