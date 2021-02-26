using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centroware.Model.Entities.Blogs
{
    public class Blog : BaseEntity
    {
        public string Title { get; set; }
        public string  Description { get; set; }
        public string  Tags { get; set; }
        public int BlogCategoryId { get; set; }
        public string ImagePath { get; set; }
        [ForeignKey("BlogCategoryId")]
        public BlogCategory BlogCategory { get; set; }
    }
}
