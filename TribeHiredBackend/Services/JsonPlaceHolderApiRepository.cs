using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace TribeHiredBackend.Services
{
    public class JsonPlaceHolderApiRepository
    {
        private readonly IConfiguration Configuration;

        public JsonPlaceHolderApiRepository(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }
        public async Task<string> Get(string Path)
        {
            using (var httpclient = new HttpClient())
            {
                httpclient.BaseAddress = new Uri(this.Configuration.GetValue<string>("JsonPlaceHolderUrl", "https://jsonplaceholder.typicode.com"));
                var request = await httpclient.GetAsync(Path);
                if (request.IsSuccessStatusCode)
                    return await request.Content.ReadAsStringAsync();
                else
                    throw new Exception("Unable to read from JsonPlaceHolder", new Exception(await request.Content.ReadAsStringAsync()));
            }
        }
    }
}
