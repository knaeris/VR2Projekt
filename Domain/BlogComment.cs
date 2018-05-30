using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
    public class BlogComment
    {
        [Key]
        public int BlogCommentId { get; set; }
        [MaxLength(640)]
        public string BlogCommentContent { get; set; }
        public DateTime BlogCommentPostedTime { get; set; }
      public int BlogId { get; set; }
        public virtual Blog Blog { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
