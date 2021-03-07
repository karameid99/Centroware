using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centroware.Model.DTOs.Blogs
{
    public class BlogCreateDto
    {
        [Display(Name = "Post Title")]
        [Required]
        public string Title { get; set; }
        [Display(Name = "Post Image")]
        public IFormFile ImageFile { get; set; }
        [Display(Name = "Tags")]
        public List<string> StringTags { get; set; }
        public string Description { get; set; }
        [Display(Name = " Blog Category")]
        [DefaultValue(1)]
        public int BlogCategoryId { get; set; }
    }
}
