using AutoMapper;
using Centroware.Model.Entities.Sayings;
using Centroware.Model.Entities.Settings;
using Centroware.Model.Entities.Works;
using Centroware.Model.ViewModels.HomeVms;
using Centroware.Model.ViewModels.Services;
using Centroware.Model.ViewModels.Settings;
using Centroware.Repository.Interfaces.Generic;
using Centroware.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Centroware.Service.Services
{
    public class HomeService : IHomeService
    {
        private readonly IBaseRepository<HomeSetting> _homeSettingRepository;
        private readonly IBaseRepository<AboutSetting> _aboutSettingRepository;
        private readonly IBaseRepository<MainSetting> _mainSettingRepository;
        private readonly IBaseRepository<Opinion> _opinionRepository;
        private readonly IBaseRepository<Work> _workRepository;
        private readonly IMapper _mapper;
        private readonly IBaseRepository<Model.Entities.Services.Service> _ServicesRepository;

        public HomeService(IBaseRepository<HomeSetting> homeSettingRepository, IBaseRepository<AboutSetting> aboutSettingRepository, IBaseRepository<MainSetting> mainSettingRepository, IBaseRepository<Opinion> opinionRepository, IBaseRepository<Work> workRepository, IMapper mapper, IBaseRepository<Model.Entities.Services.Service> servicesRepository)
        {
            _homeSettingRepository = homeSettingRepository;
            _aboutSettingRepository = aboutSettingRepository;
            _mainSettingRepository = mainSettingRepository;
            _opinionRepository = opinionRepository;
            _workRepository = workRepository;
            _mapper = mapper;
            _ServicesRepository = servicesRepository;
        }

        public async Task<HomeVm> GetHomePage()
        {
            var homeSetting = await _homeSettingRepository.FindFirst(x => x.Id > 0);
            var homeSettingVm = _mapper.Map<HomeSetting, HomeSettingVm>(homeSetting);
            return new HomeVm
            {
                HomeSetting = homeSettingVm,
            };
        }

        public async Task<MainSettingsVm> GetMainSettings()
        {
            var data = await _mainSettingRepository.FindFirst(x => x.Id > 0);
            return _mapper.Map<MainSetting, MainSettingsVm>(data);
        }

        public async Task<List<ServiceVm>> GetServices()
        {
            return await _ServicesRepository.Filter(filter: x => x.Id > 0, 0, 5, orderBy: x => x.OrderByDescending(x => x.Id)).Select(x => new ServiceVm
            {
                Title = x.Title,
                Image = x.Image,
                Description = x.Description
            }).ToListAsync();
        }
    }
}
