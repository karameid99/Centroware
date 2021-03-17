
using Microsoft.AspNetCore.Http;

namespace Centroware.Model.DTOs.Opinions
{
   public class OpinionDto
    {
        public string Name { get; set; }
        public string Specialty { get; set; }
        public IFormFile ImageFile { get; set; }
        public IFormFile LogoFile { get; set; }
        public string Description { get; set; }
        public int? WorkId { get; set; }
    }
}
