using AutoMapper;
using Centroware.Model.DTOs;
using Centroware.Model.DTOs.Helpers;
using Centroware.Model.DTOs.Services;
using Centroware.Model.ViewModels.Services;
using Centroware.Repository.Interfaces.Generic;
using Centroware.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Centroware.Service.Services
{
   public class ServiceService : IServiceService
    {
        private readonly IBaseRepository<Centroware.Model.Entities.Services.Service> _serviceRepository;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;

        public ServiceService(IBaseRepository<Centroware.Model.Entities.Services.Service> serviceRepository, IMapper mapper, IFileService fileService)
        {
            _serviceRepository = serviceRepository;
            _mapper = mapper;
            _fileService = fileService;
        }

        public async Task<bool> AddService(ServiceCreateDto input)
        {
            if (input != null)
            {
                var service = _mapper.Map<ServiceCreateDto, Centroware.Model.Entities.Services.Service>(input);
                service.Image = await _fileService.SaveFile(input.ImageFile, "Images");
                await _serviceRepository.AddAsync(service);
                return true;
            }
            return false;
        }

        public async Task<bool> Delete(int id)
        {
            if (id > 0)
            {
                var service = await _serviceRepository.Get(id);
                await _serviceRepository.DeleteAsync(service);
                return true;
            }
            return false;
        }

        public async Task<ServiceUpdateDto> Get(int id)
        {
            var data = await _serviceRepository.Get(id);
            if (data != null)
            {
                var dataVm = _mapper.Map<ServiceUpdateDto>(data);
                return dataVm;
            }
            return null;
        }

        public async Task<ResponseDto> GetAll(Pagination pagination, Query query)
        {
            var skipValue = (pagination.Page - 1) * pagination.PerPage;
            var data = _serviceRepository.Filter(filter: x =>
           string.IsNullOrEmpty(query.GeneralSearch) || x.Title.Contains(query.GeneralSearch),
            orderBy: x => x.OrderByDescending(x => x.Id));
            var dataCount = await data.CountAsync();
            if (skipValue >= dataCount)
            {
                skipValue = 0;
                pagination.Page = 1;
            }
            var pages = Convert.ToInt32(Math.Ceiling(dataCount / (float)pagination.PerPage));
            var dataList = await data.Skip(skipValue).Take(pagination.PerPage).Select(x => new ServiceVm
            {
                Id = x.Id,
                Image = x.Image,
                Title = x.Title,
                Description = x.Description,
            }).ToListAsync();
            var response = new ResponseDto
            {
                meta = new Meta
                {
                    page = pagination.Page,
                    perpage = pagination.PerPage,
                    total = dataCount,
                    pages = pages,
                },
                data = dataList
            };
            return response;
        }

        public async Task<bool> UpdateService(ServiceUpdateDto input)
        {
            if (input != null)
            {
                var service = _mapper.Map<ServiceUpdateDto, Centroware.Model.Entities.Services.Service>(input);
                var oldService = await _serviceRepository.FindSingle(x=> x.Id == input.Id);
                service.Image = input.ImageFile != null ?
                    await _fileService.SaveFile(input.ImageFile, "Images") : oldService.Image;
                await _serviceRepository.UpdateAsync(service);
                return true;
            }
            return false;
        }
    }
}
