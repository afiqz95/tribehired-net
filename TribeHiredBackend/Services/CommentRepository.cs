using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TribeHiredBackend.Models;

namespace TribeHiredBackend.Services
{
    public class CommentRepository
    {
        private JsonPlaceHolderAPIService JsonPlaceHolderAPIService;

        public CommentRepository(JsonPlaceHolderAPIService JsonPlaceHolderAPIService)
        {
            this.JsonPlaceHolderAPIService = JsonPlaceHolderAPIService;
        }


        public async Task<IEnumerable<Comment>> GetAllComments()
        {
            return JsonConvert.DeserializeObject<IEnumerable<Comment>>(await this.JsonPlaceHolderAPIService.Get("comments"));
        }
    }
}
