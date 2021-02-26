using Microsoft.AspNetCore.Http;

namespace Centroware.Model.ViewModels.Settings
{
    public class HomeSettingVm
    {
        public int Id { get; set; }
        public IFormFile Image { get; set; }
        public IFormFile CustomersImage { get; set; }
        public string AboutFirstTitle { get; set; }
        public string AboutSocondTitle { get; set; }
        public string AboutDescription { get; set; }
        public string OurWorkSocondTitle { get; set; }
        public string OurWorkFirstTitle { get; set; }
        public string OurWorkDescription { get; set; }
        public string AwardsTitle { get; set; }
        public string OurCustomersTitle { get; set; }
        public string OurFriends { get; set; }
        public string SayingFirstTitle { get; set; }
        public string SayingSoccondTitle { get; set; }
    }
}
