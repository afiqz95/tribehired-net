using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TribeHiredBackend.Models;
using TribeHiredBackend.Services;
using TribeHiredBackend.ViewModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TribeHiredBackend.Controllers
{
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        private readonly PostRepository postRepository;
        private readonly CommentRepository commentRepository;
        public PostController(PostRepository postRepository, CommentRepository commentRepository)
        {
            this.postRepository = postRepository;
            this.commentRepository = commentRepository;
        }

        [HttpGet("top-comment")]
        public async Task<IActionResult> GetPostWithTopComment()
        {
            var posts = await this.postRepository.GetAllPosts();
            var comments = await this.commentRepository.GetAllComments();

            //map post and commments to single model
            var postComments = posts.Select(post =>
            {
                return new PostComment
                {
                    Post = post,
                    Comments = comments.Where(comment => comment.PostId == post.Id)
                };
            });

            //Find post with highest number of comments
            var topComment = postComments.Aggregate((pc1, pc2) => pc1.Comments.Count() > pc2.Comments.Count() ? pc1 : pc2);

            return Ok(new PostWithTopComment
            {
                Post_Body = topComment.Post.Body,
                Post_Id = topComment.Post.Id,
                Post_Title = topComment.Post.Title,
                Total_Number_Of_Comments = topComment.Comments.Count()
            });
        }

    }
}
