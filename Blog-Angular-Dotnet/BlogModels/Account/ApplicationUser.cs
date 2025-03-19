using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Models.Account
{
    public class ApplicationUser
    {
        public int ApplicationUserId { get; set; }

        public required string Username { get; set; }

        public required string Fullname { get; set; }

        public required string Email { get; set; }

        public required string Token { get; set; }
    }
}
