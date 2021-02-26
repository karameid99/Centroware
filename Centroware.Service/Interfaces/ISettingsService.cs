using Centroware.Model.ViewModels.Settings;
using System.Threading.Tasks;

namespace Centroware.Service.Interfaces
{
    public interface ISettingsService
    {
        Task<AboutSettingVm> GetAboutSetting();
        Task<MainSettingVm> GetMainSetting();
        Task<HomeSettingVm> GetHomeSetting();
        Task<AboutSettingVm> UpdateAboutSetting(AboutSettingVm input);
        Task<MainSettingVm> UpdateMainSetting(MainSettingVm input);
        Task<HomeSettingVm> UpdateHomeSetting(HomeSettingVm input);
    }
}
