﻿using HellDay.Data;
using HellDay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HellDay.Services
{
    public class LikeService
    {
        private readonly Guid _userId;
        public LikeService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateLike(LikeCreate model)
        {
            var entity = new Like()
            {
                UserId = model.UserId,
                PostId = model.PostId,
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Likes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
