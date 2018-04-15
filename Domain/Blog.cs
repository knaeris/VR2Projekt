
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
   public class Blog
    {
        [Key]
        public int BlogId { get; set; }
        [MaxLength(128)]
        public string BlogTitle { get; set; }
        [MaxLength(1024)]
        public string BlogDescription { get; set; }
        public virtual List<BlogPost> BlogPosts { get; set; } = new List<BlogPost>();
        public int Rating { get; set; }
       
        public virtual BlogCategory BlogCategory { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
