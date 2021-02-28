

using Microsoft.AspNetCore.Http;

namespace Centroware.Model.DTOs.Services
{
   public  class ServiceCreateDto
    {
        public string Title { get; set; }
        public IFormFile ImageFile { get; set; }
        public string Description { get; set; }
    }
}
