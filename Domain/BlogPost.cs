using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public int BlogId { get; set; }
        [ForeignKey("BlogId")]
        public virtual Blog Blog { get; set; }
        public virtual List<BlogPostComment> BlogPostComments { get; set; }
        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        public ApplicationUser ApplicationUser { get; set; }
        
        //public int NumberOfBlogPostLikes { get; set; }

    }
}
