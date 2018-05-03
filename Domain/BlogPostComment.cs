using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
    public class BlogPostComment
    {
        [Key]
        public int BlogPostCommentId { get; set; }
        [MaxLength(640)]
        public string BlogPostCommentContent { get; set; }
        public DateTime BlogPostCommentPostedTime { get; set; }

        public virtual BlogPost BlogPost { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
