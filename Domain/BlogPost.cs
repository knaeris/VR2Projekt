using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
    public class BlogPost
    {
        [Key]
        public int BlogPostId { get; set; }
        [MaxLength(128)]
        public string BlogPostTitle { get; set; }
        [MaxLength(5120)]
        public string BlogPostContent { get; set; }
        public DateTime BlogPostPostedTime { get; set; }
     
        public virtual Blog Blog { get; set; }
        public virtual List<BlogComment> BlogComments { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

    }
}
