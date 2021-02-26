using Microsoft.AspNetCore.Http;

namespace Centroware.Model.ViewModels.Settings
{
    public class MainSettingVm
    {
        public int Id { get; set; }
        public IFormFile Image { get; set; }
        public string FacebookUrl { get; set; }
        public string InstagramUrl { get; set; }
        public string LinkedInUrl { get; set; }
        public string YoutubeUrl { get; set; }
        public string ContactUsTitle { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Longtude { get; set; }
        public string Latetude { get; set; }
    }
}
