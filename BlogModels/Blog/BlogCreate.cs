using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Models.Blog
{
    public class BlogCreate
    {
        public required int BlogId { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [MinLength(10, ErrorMessage = "Must be 10-50 characters")]
        [MaxLength(50, ErrorMessage = "Must be 10-50 characters")]
        public required string Title { get; set; }

        [Required(ErrorMessage = "Content is required")]
        [MinLength(300, ErrorMessage = "Must be 300-3000 characters")]
        [MaxLength(3000, ErrorMessage = "Must be 300-3000 characters")]
        public required string Content { get; set; }

        public int? PhotoId { get; set; }
    }
}
