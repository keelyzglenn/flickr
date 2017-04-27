using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Flickr.Models
{
    [Table("Posts")]
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }

        public virtual ApplicationUser User { get; set; }

        public ICollection<PostsTags> PostsTags { get; set; }



    }
}
