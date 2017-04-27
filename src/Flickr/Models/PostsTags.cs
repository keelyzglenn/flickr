using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Flickr.Models
{
    [Table("PostsTags")]
    public class PostsTags
    {
        [Key]
        public int PostId { get; set; }
        public virtual Post Post { get; set; }

        public int TagId { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
