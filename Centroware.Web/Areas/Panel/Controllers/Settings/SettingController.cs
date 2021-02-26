using Centroware.Model.Constants;
using Centroware.Model.Entities.Identity;
using Centroware.Model.ViewModels.Settings;
using Centroware.Service.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Centroware.Web.Areas.Panel.Controllers.Settings
{
    public class SettingController : BaseController
    {
        private readonly ISettingsService _settingService;
        public SettingController(UserManager<CentrowareUser> userManager, ISettingsService settingService) : base(userManager)
        {
            _settingService = settingService;
        }
        [HttpGet]
        public async Task<IActionResult> MainSetting()
        {
            var result = await _settingService.GetMainSetting();
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> MainSetting(MainSettingVm input)
        {
            var result = await _settingService.UpdateMainSetting(input);
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> AboutSetting()
        {
            var result = await _settingService.GetAboutSetting();
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> AboutSetting(AboutSettingVm input)
        {
            var result = await _settingService.UpdateAboutSetting(input);
            if (result != null)
                TempData["Meesage"] = Constant.UpdateSettings;
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> HomeSetting()
        {
            var result = await _settingService.GetHomeSetting();
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> HomeSetting(HomeSettingVm input)
        {
            var result = await _settingService.UpdateHomeSetting(input);
            if (result != null)
                TempData["Meesage"] = Constant.UpdateSettings;
            return View(result);
        }
    }
}
