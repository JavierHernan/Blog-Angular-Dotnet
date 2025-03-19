using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Models.Blog
{
    public class Blog : BlogCreate
    {
        public required string Username { get; set; }

        public required int ApplicationUserId { get; set; }

        public required DateTime PublishDate { get; set; }

        public required DateTime UpdateDate { get; set; }
    }
}
