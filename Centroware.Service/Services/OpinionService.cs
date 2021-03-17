using AutoMapper;
using Centroware.Model.DTOs;
using Centroware.Model.DTOs.Helpers;
using Centroware.Model.DTOs.Opinions;
using Centroware.Model.Entities.Sayings;
using Centroware.Model.ViewModels.Sayings;
using Centroware.Repository.Interfaces.Generic;
using Centroware.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Centroware.Service.Services
{
    public class OpinionService : IOpinionService
    {
        private readonly IBaseRepository<Opinion> _opinoinRepository;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;

        public OpinionService(IBaseRepository<Opinion> opinoinRepository, IMapper mapper, IFileService fileService)
        {
            _opinoinRepository = opinoinRepository;
            _mapper = mapper;
            _fileService = fileService;
        }

        public async Task<bool> AddOpinoin(OpinionDto input)
        {
            var opinoin = _mapper.Map<OpinionDto, Opinion>(input);
            if (input.ImageFile != null)
            {
                opinoin.Image = await _fileService.SaveFile(input.ImageFile, "Images");
            }
            if (input.LogoFile != null)
            {
                opinoin.Logo = await _fileService.SaveFile(input.LogoFile, "Images");
            }
            await _opinoinRepository.AddAsync(opinoin);
            return true;

        }

        public async Task<UpdateOpinionDto> Get(int id)
        {
            var data = await _opinoinRepository.Get(id);
            if (data != null)
            {
                var dataVm = _mapper.Map<UpdateOpinionDto>(data);
                return dataVm;
            }
            return null;
        }

        public async Task<bool> Delete(int id)
        {
            var opinoin = await _opinoinRepository.Get(id);
            if (opinoin == null)
                return false;
            await _opinoinRepository.DeleteAsync(opinoin);
            return true;
        }

        public async Task<ResponseDto> GetAllOpinoins(Pagination pagination, Query query)
        {
            var skipValue = (pagination.Page - 1) * pagination.PerPage;
            var data = _opinoinRepository.Filter(filter: x =>
           string.IsNullOrEmpty(query.GeneralSearch) || x.Name.Contains(query.GeneralSearch),
            orderBy: x => x.OrderByDescending(x => x.Id));
            var dataCount = await data.CountAsync();
            if (skipValue >= dataCount)
            {
                skipValue = 0;
                pagination.Page = 1;
            }
            var pages = Convert.ToInt32(Math.Ceiling(dataCount / (float)pagination.PerPage));
            var dataList = await data.Skip(skipValue).Take(pagination.PerPage).Select(x => new OpinoinVm
            {
                Id = x.Id,
                Image = x.Image,
                Specialty = x.Specialty,
                Name = x.Name,
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

        public async Task<bool> UpdateOpinoin(UpdateOpinionDto input)
        {
            var opinion = await _opinoinRepository.Get(input.Id);
            opinion.Name = input.Name;
            opinion.Specialty = input.Specialty;
            opinion.Description = input.Description;
            if (input.ImageFile != null)
            {
                opinion.Image = await _fileService.SaveFile(input.ImageFile, "Images");
            }
            if (input.LogoFile != null)
            {
                opinion.Logo = await _fileService.SaveFile(input.LogoFile, "Images");
            }
            await _opinoinRepository.UpdateAsync(opinion);
            return true;
        }
    }
}
