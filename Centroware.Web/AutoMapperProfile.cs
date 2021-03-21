using AutoMapper;
using Centroware.Model.DTOs.Blogs;
using Centroware.Model.DTOs.Jobs;
using Centroware.Model.DTOs.Opinions;
using Centroware.Model.DTOs.Services;
using Centroware.Model.DTOs.Teams;
using Centroware.Model.DTOs.Users;
using Centroware.Model.DTOs.Works;
using Centroware.Model.Entities.Blogs;
using Centroware.Model.Entities.Contact;
using Centroware.Model.Entities.Identity;
using Centroware.Model.Entities.Jobs;
using Centroware.Model.Entities.Sayings;
using Centroware.Model.Entities.Settings;
using Centroware.Model.Entities.Teams;
using Centroware.Model.Entities.Works;
using Centroware.Model.ViewModels.Contacts;
using Centroware.Model.ViewModels.HomeVms;
using Centroware.Model.ViewModels.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Centroware.Web
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<TeamCreateDto, Team>();
            CreateMap<TeamUpdateDto, Team>().ReverseMap();

            CreateMap<BlogCreateDto, Blog>().ForMember(x => x.Tags, x => x.MapFrom(x => String.Join(",", x.StringTags)));
            CreateMap<BlogUpdateDto, Blog>().ReverseMap();

            CreateMap<CreateWorkDto, Work>();
            CreateMap<UpdateWorkDto, Work>().ReverseMap();

            CreateMap<BlogCategoryCreateDto, BlogCategory>();
            CreateMap<BlogCategoryUpdateDto, BlogCategory>().ReverseMap();

            CreateMap<BlogCategoryCreateDto, Category>();
            CreateMap<BlogCategoryUpdateDto, Category>().ReverseMap();

            CreateMap<CreateUserDto, CentrowareUser>();
            CreateMap<UpdateUserDto, CentrowareUser>().ReverseMap();


            CreateMap<AboutSettingVm, AboutSetting>().ReverseMap();
            CreateMap<HomeSettingVm, HomeSetting>().ReverseMap();
            CreateMap<MainSettingVm, MainSetting>().ReverseMap();

            CreateMap<ServiceCreateDto, Centroware.Model.Entities.Services.Service>();
            CreateMap<ServiceUpdateDto, Centroware.Model.Entities.Services.Service>().ReverseMap();

            CreateMap<JobCreateDto, Job>();
            CreateMap<JobUpdateDto, Job>().ReverseMap();
            CreateMap<CreateArticleDto, Article>().ReverseMap();

            CreateMap<OpinionDto, Opinion>();
            CreateMap<UpdateOpinionDto, Opinion>().ReverseMap();
            CreateMap<UpdateWorkDto, Work>().ReverseMap();
            CreateMap<MainSetting, MainSettingsVm>();
            CreateMap<AboutSetting, AboutSettingVm>().ReverseMap();
            CreateMap<ContactVm, Contact>().ReverseMap();

        }

    }
}
