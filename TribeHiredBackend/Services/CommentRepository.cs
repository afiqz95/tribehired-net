using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TribeHiredBackend.Models;
using TribeHiredBackend.ViewModel;

namespace TribeHiredBackend.Services
{
    public class CommentRepository
    {
        private JsonPlaceHolderApiRepository JsonPlaceHolderAPIService;

        public CommentRepository(JsonPlaceHolderApiRepository JsonPlaceHolderAPIService)
        {
            this.JsonPlaceHolderAPIService = JsonPlaceHolderAPIService;
        }


        public async Task<IEnumerable<Comment>> GetAllComments()
        {
            return JsonConvert.DeserializeObject<IEnumerable<Comment>>(await this.JsonPlaceHolderAPIService.Get("comments"));
        }

        public async Task<IEnumerable<Comment>> SearchComments(SearchCommentModel searchCommentModel)
        {
            var comments = await this.GetAllComments();

            if (searchCommentModel.PostId != null)
                comments = comments.Where(x => x.PostId == searchCommentModel.PostId);
            if (searchCommentModel.Id != null)
                comments = comments.Where(x => x.Id == searchCommentModel.Id);
            if (searchCommentModel.Name != null)
                comments = comments.Where(x => x.Name.Contains(searchCommentModel.Name, StringComparison.OrdinalIgnoreCase));
            if (searchCommentModel.Body != null)
                comments = comments.Where(x => x.Body.Contains(searchCommentModel.Body, StringComparison.OrdinalIgnoreCase));
            if (searchCommentModel.Email != null)
                comments = comments.Where(x => x.Email.Contains(searchCommentModel.Email, StringComparison.OrdinalIgnoreCase));

            return comments;
        }
    }
}
