using HellDay.Models;
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
    public class PostController : ApiController
    {

        private PostService CreatePostService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var noteService = new PostService(userId);
            return noteService;
        }
        public IHttpActionResult Get()
        {
            PostService postService = CreatePostService();
            var post = postService.GetPosts();
            return Ok(post);
        }

        [HttpPost]
        public IHttpActionResult Post(PostCreate post)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreatePostService();
            if (!service.CreatePost(post))
                return InternalServerError();
            return Ok();
        }
    }
}
