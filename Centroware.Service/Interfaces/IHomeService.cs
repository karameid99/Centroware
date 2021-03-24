using Centroware.Model.Entities.Settings;
using Centroware.Model.ViewModels.Contacts;
using Centroware.Model.ViewModels.HomeVms;
using Centroware.Model.ViewModels.Services;
using Centroware.Model.ViewModels.Settings;
using Centroware.Model.ViewModels.Works;
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
        Task<AboutVm> GetAboutPage();
        Task<ContactVm> CreateContact(ContactVm contact);
        Task<List<ServiceVm>> GetServices();
        Task<WorksVm> GetWorksPage();
        Task<WorkVm> GetWork(int id);
    }
}
