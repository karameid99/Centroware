using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centroware.Model.DTOs.Blogs
{
    public class BlogCreateDto
    {
        [Display(Name ="Post Title")]
        [Required]
        public string Title { get; set; }
        public IFormFile ImageFile { get; set; }
        public List<string> stringTags { get; set; }
        public string Description { get; set; }
        public int BlogCategoryId { get; set; }
    }
}
