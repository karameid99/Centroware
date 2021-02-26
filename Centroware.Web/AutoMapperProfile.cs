using AutoMapper;
using Centroware.Model.DTOs.Blogs;
using Centroware.Model.DTOs.Teams;
using Centroware.Model.Entities.Blogs;
using Centroware.Model.Entities.Settings;
using Centroware.Model.Entities.Teams;
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

            CreateMap<BlogCreateDto, Blog>();
            CreateMap<BlogUpdateDto, Blog>().ReverseMap();

            CreateMap<BlogCategoryCreateDto, BlogCategory>();
            CreateMap<BlogCategoryUpdateDto, BlogCategory>().ReverseMap();

            CreateMap<AboutSettingVm, AboutSetting>().ReverseMap();
            CreateMap<HomeSettingVm, HomeSetting>().ReverseMap();
            CreateMap<MainSettingVm, MainSetting>().ReverseMap();
        }
    }
}
