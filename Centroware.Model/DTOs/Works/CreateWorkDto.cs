using Microsoft.AspNetCore.Http;

namespace Centroware.Model.DTOs.Works
{
    public class CreateWorkDto
    {
        public IFormFile MainImageFile { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string About { get; set; }
        public string OurPart { get; set; }
        public int CategoryId { get; set; }
        public string WorkStringId { get; set; }
    }
}
