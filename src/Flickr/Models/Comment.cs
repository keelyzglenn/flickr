using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Flickr.Models;

namespace Flickr.Models
{
    [Table("Comments")]
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public string Description { get; set; }

        public int PostId { get; set; }
        public virtual Post Post { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}