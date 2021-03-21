using AutoMapper;
using Centroware.Model.Entities.Contact;
using Centroware.Model.Entities.Sayings;
using Centroware.Model.Entities.Settings;
using Centroware.Model.Entities.Teams;
using Centroware.Model.Entities.Works;
using Centroware.Model.ViewModels.Blogs;
using Centroware.Model.ViewModels.Contacts;
using Centroware.Model.ViewModels.HomeVms;
using Centroware.Model.ViewModels.Services;
using Centroware.Model.ViewModels.Settings;
using Centroware.Model.ViewModels.Teams;
using Centroware.Model.ViewModels.Works;
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
        private readonly IBaseRepository<Contact> _contactRepository;
        private readonly IBaseRepository<Work> _workRepository;
        private readonly IBaseRepository<Category> _categoryRepository;
        private readonly IBaseRepository<Team> _teamRepository;
        private readonly IMapper _mapper;
        private readonly IBaseRepository<Model.Entities.Services.Service> _ServicesRepository;

        public HomeService(IBaseRepository<HomeSetting> homeSettingRepository, IBaseRepository<AboutSetting> aboutSettingRepository, IBaseRepository<MainSetting> mainSettingRepository, IBaseRepository<Opinion> opinionRepository, IBaseRepository<Contact> contactRepository, IBaseRepository<Work> workRepository, IBaseRepository<Category> categoryRepository, IBaseRepository<Team> teamRepository, IMapper mapper, IBaseRepository<Model.Entities.Services.Service> servicesRepository)
        {
            _homeSettingRepository = homeSettingRepository;
            _aboutSettingRepository = aboutSettingRepository;
            _mainSettingRepository = mainSettingRepository;
            _opinionRepository = opinionRepository;
            _contactRepository = contactRepository;
            _workRepository = workRepository;
            _categoryRepository = categoryRepository;
            _teamRepository = teamRepository;
            _mapper = mapper;
            _ServicesRepository = servicesRepository;
        }

        public async Task<ContactVm> CreateContact(ContactVm contactVm)
        {
            var contact = _mapper.Map<Contact>(contactVm);
            var result = await _contactRepository.AddAsync(contact);
            return contactVm;
        }

        public async Task<AboutVm> GetAboutPage()
        {
            var teams = await _teamRepository.Filter(filter: x => x.Id > 0, orderBy: x => x.OrderByDescending(x => x.Id))
                .Select(x => new TeamVm
                {
                    Id = x.Id,
                    MovedImage = x.MovedImage,
                    Name = x.Name,
                    Specialization = x.Specialization,
                    StaticImage = x.StaticImage,
                    Description = x.Description
                }).ToListAsync();
            var services = await GetServices();
            var about = await _aboutSettingRepository.FindFirst(x => x.Id > 0);
            var mapAbout = _mapper.Map<AboutSetting, AboutSettingVm>(about);
            return new AboutVm
            {
                About = mapAbout,
                Services = services,
                Teams = teams
            };
        }

        public async Task<HomeVm> GetHomePage()
        {
            var homeSetting = await _homeSettingRepository.FindFirst(x => x.Id > 0);
            var homeSettingVm = _mapper.Map<HomeSetting, HomeSettingVm>(homeSetting);
            var works = await _workRepository
                .Filter(filter: x => x.Id > 0, 0, 4, orderBy: x => x.OrderByDescending(x => x.Id)).Select(x => new WorkVm
                {
                    Title = x.Title,
                    Id = x.Id,
                    MainImage = x.MainImage,
                    Category = x.Category.Name,
                    SubTitle = x.SubTitle
                }).ToListAsync();
            return new HomeVm
            {
                HomeSetting = homeSettingVm,
                Worsk = works,
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

        public async Task<WorksVm> GetWorksPage()
        {
            var works = await _workRepository.Filter(filter: x => x.Id > 0,
                orderBy: x => x.OrderByDescending(x => x.Id),
                include: x => x.Include(x => x.Category)).Select(x => new WorkVm
                {
                    Id = x.Id,
                    Title = x.Title,
                    SubTitle = x.SubTitle,
                    MainImage = x.MainImage,
                    Category = x.Category.Name,
                    CategoryId = x.CategoryId
                }).ToListAsync();
            var categories = await _categoryRepository.Filter(filter: x => x.Id > 0,
                orderBy: x => x.OrderByDescending(x => x.Id)).Select(x => new BlogCategoryVm
                {
                    Id = x.Id,
                    Name = x.Name,
                }).ToListAsync();
            return new WorksVm { Categories = categories, Works = works };
        }
    }
}
