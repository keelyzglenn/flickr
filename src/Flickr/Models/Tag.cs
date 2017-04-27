
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Flickr.Models
{
    [Table("Tags")]
    public class Tag
    {
        public int TagId { get; set; }
        public string Name { get; set; }

        public ICollection<PostsTags> PostsTags { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
