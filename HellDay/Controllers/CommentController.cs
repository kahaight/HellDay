﻿using HellDay.Models;
using HellDay.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HellDay.Controllers
{
    public class CommentController : ApiController
    {
        private CommentService CreateCommentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
             var commentService = new CommentService(userId);
            return commentService;
        }
        [HttpPost]
        public IHttpActionResult Post(CommentCreate comment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateCommentService();
            if (!service.CreateComment(comment))
                return InternalServerError();
            return Ok();
        }

    }
}
