using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Centroware.Model.DTOs.Teams
{
   public class TeamCreateDto
    {
        [Required]
        public string Name { get; set; }
        public string Specialization { get; set; }
        [Display(Name= "Member Static Image")]
        public IFormFile StaticImageFile { get; set; }
        [Display(Name = "Animated Member Image")]
        public IFormFile MovedImageFile { get; set; }
        public string Description { get; set; }
    }
}
