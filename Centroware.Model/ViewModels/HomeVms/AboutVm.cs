using Centroware.Model.ViewModels.Services;
using Centroware.Model.ViewModels.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centroware.Model.ViewModels.HomeVms
{
    public class AboutVm
    {
        public AboutSettingVm About { get; set; }
        public List<Teams.TeamVm> Teams { get; set; }
        public List<ServiceVm> Services { get; set; }

    }
}
