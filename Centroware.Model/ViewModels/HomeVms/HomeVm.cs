using Centroware.Model.ViewModels.Settings;
using Centroware.Model.ViewModels.Works;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centroware.Model.ViewModels.HomeVms
{
    public class HomeVm
    {
        public HomeSettingVm HomeSetting { get; set; }
        public List<WorkVm> Worsk { get; set; }
    }
}
