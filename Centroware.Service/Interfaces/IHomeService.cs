using Centroware.Model.Entities.Settings;
using Centroware.Model.ViewModels.HomeVms;
using Centroware.Model.ViewModels.Services;
using Centroware.Model.ViewModels.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centroware.Service.Interfaces
{
    public interface IHomeService
    {
        Task<MainSettingsVm> GetMainSettings();
        Task<HomeVm> GetHomePage();
        Task<List<ServiceVm>> GetServices();
    }
}
