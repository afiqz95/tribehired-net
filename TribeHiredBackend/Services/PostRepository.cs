using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TribeHiredBackend.Models;

namespace TribeHiredBackend.Services
{
    public class PostRepository
    {
        private JsonPlaceHolderAPIService JsonPlaceHolderAPIService;

        public PostRepository(JsonPlaceHolderAPIService JsonPlaceHolderAPIService)
        {
            this.JsonPlaceHolderAPIService = JsonPlaceHolderAPIService;
        }

        public async Task<IEnumerable<Post>> GetAllPosts()
        {
            return JsonConvert.DeserializeObject<IEnumerable<Post>>(await this.JsonPlaceHolderAPIService.Get("posts"));
        }

        public async Task<Post> GetSinglePost(int post_id)
        {
            return JsonConvert.DeserializeObject<Post>(await this.JsonPlaceHolderAPIService.Get("posts/" + post_id));
        }
    }
}
