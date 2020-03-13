using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TribeHiredBackend.Models
{
    public class PostComment
    {
        public Post Post { get; set; }
        public IEnumerable<Comment> Comments { get; set; }

    }
}
