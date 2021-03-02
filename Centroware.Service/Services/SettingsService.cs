using AutoMapper;
using Centroware.Model.Entities.Settings;
using Centroware.Model.ViewModels.Settings;
using Centroware.Repository.Interfaces.Generic;
using Centroware.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centroware.Service.Services
{
    public class SettingsService : ISettingsService
    {
        private readonly IBaseRepository<AboutSetting> _aboutRepository;
        private readonly IBaseRepository<HomeSetting> _homeRepository;
        private readonly IBaseRepository<MainSetting> _mainRepository;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;

        public SettingsService(IFileService fileService, IBaseRepository<AboutSetting> aboutRepository, IBaseRepository<HomeSetting> homeRepository, IBaseRepository<MainSetting> mainRepository, IMapper mapper)
        {
            _aboutRepository = aboutRepository;
            _homeRepository = homeRepository;
            _mainRepository = mainRepository;
            _fileService = fileService;
            _mapper = mapper;
        }

        public async Task<AboutSettingVm> GetAboutSetting()
        {
            var aboutSettings = await _aboutRepository.FindFirst(x => x.Id > 0);
            if (aboutSettings == null)
            {
                aboutSettings = new AboutSetting();
                await _aboutRepository.AddAsync(aboutSettings);
            }
            var aboutSettingVm = _mapper.Map<AboutSetting, AboutSettingVm>(aboutSettings);
            return aboutSettingVm;
        }

        public async Task<HomeSettingVm> GetHomeSetting()
        {
            var homeSettings = await _homeRepository.FindFirst(x => x.Id > 0);
            if (homeSettings == null)
            {
                homeSettings = new HomeSetting();
                await _homeRepository.AddAsync(homeSettings);
            }
            var homeSettingVm = _mapper.Map<HomeSetting, HomeSettingVm>(homeSettings);
            return homeSettingVm;
        }

        public async Task<MainSettingVm> GetMainSetting()
        {
            var mainSettings = await _mainRepository.FindFirst(x => x.Id > 0);
            if (mainSettings == null)
            {
                mainSettings = new MainSetting();
                await _mainRepository.AddAsync(mainSettings);
            }
            var mainSettingVm = _mapper.Map<MainSetting, MainSettingVm>(mainSettings);
            return mainSettingVm;
        }

        public async Task<AboutSettingVm> UpdateAboutSetting(AboutSettingVm input)
        {
            var oldAboutSetting = await _aboutRepository.FindFirst(x => x.Id == input.Id);
            var aboutSetting = _mapper.Map<AboutSettingVm, AboutSetting>(input);
            aboutSetting.JoinUsImage = input.JoinUsImageFile != null ? await _fileService.SaveFile(input.JoinUsImageFile, "Images") : oldAboutSetting.JoinUsImage;
            await _aboutRepository.UpdateAsync(aboutSetting);
            return input;
        }

        public async Task<HomeSettingVm> UpdateHomeSetting(HomeSettingVm input)
        {
            var oldHomeSetting = await _homeRepository.FindFirst(x => x.Id == input.Id);
            var homeSettings = _mapper.Map<HomeSettingVm, HomeSetting>(input);
            homeSettings.SliderImage = input.Image != null ? await _fileService.SaveFile(input.Image, "Images") : oldHomeSetting.SliderImage;
            homeSettings.OurCustomersImage = input.CustomersImage != null ? await _fileService.SaveFile(input.CustomersImage, "Images") : oldHomeSetting.OurCustomersImage;
            await _homeRepository.UpdateAsync(homeSettings);
            return input;
        }

        public async Task<MainSettingVm> UpdateMainSetting(MainSettingVm input)
        {
            var oldMainSetting = await _mainRepository.FindFirst(x => x.Id == input.Id);
            var mainSetting = _mapper.Map<MainSettingVm, MainSetting>(input);
            mainSetting.Logo = input.Image != null ? await _fileService.SaveFile(input.Image, "Images") : oldMainSetting.Logo;
            await _mainRepository.UpdateAsync(mainSetting);
            return input;
        }
    }
}
