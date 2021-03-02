
using Microsoft.AspNetCore.Http;

namespace Centroware.Model.ViewModels.Settings
{
    public class AboutSettingVm
    {
        public int Id { get; set; }
        public string WeDoTitle { get; set; }
        public string WeDoDescription { get; set; }
        public string OurTeamFirstTitle { get; set; }
        public string OurTeamSoccondTitle { get; set; }
        public string OurTeamDescription { get; set; }
        public string JoinUsTitle { get; set; }
        public string JoinUsSubTitle { get; set; }
        public IFormFile JoinUsImageFile { get; set; }
    }
}
