using Blog.Models.Account;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Models.Account
{
    public class ApplicationUserCreate : ApplicationUserLogin
    {
        [MinLength(10, ErrorMessage = "Must be at least 10-30 characters")]
        [MaxLength(30, ErrorMessage = "Must be at least 10-30 characters")]
        public required string Fullname { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [MaxLength(30, ErrorMessage = "Can be at most 30 characters")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public required string Email { get; set; }
    }
}
