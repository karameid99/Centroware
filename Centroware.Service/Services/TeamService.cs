using AutoMapper;
using Centroware.Model.DTOs;
using Centroware.Model.DTOs.Helpers;
using Centroware.Model.DTOs.Teams;
using Centroware.Model.Entities.Teams;
using Centroware.Model.ViewModels.Teams;
using Centroware.Repository.Interfaces.Generic;
using Centroware.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Centroware.Service.Services
{
    public class TeamService : ITeamService
    {
        private readonly IBaseRepository<Team> _teamRepository;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;

        public TeamService(IBaseRepository<Team> teamRepository, IMapper mapper, IFileService fileService)
        {
            _teamRepository = teamRepository;
            _mapper = mapper;
            _fileService = fileService;
        }

        public async Task<bool> AddTeamMember(TeamCreateDto input)
        {
            if (input != null)
            {
                var team = _mapper.Map<TeamCreateDto, Team>(input);
                team.StaticImage = await _fileService.SaveFile(input.StaticImageFile, "Images");
                team.MovedImage = await _fileService.SaveFile(input.MovedImageFile, "Images");
                await _teamRepository.AddAsync(team);
                return true;
            }
            return false;
        }

        public async Task<bool> Delete(int id)
        {
            if (id > 0)
            {
                var team = await _teamRepository.Get(id);
                await _teamRepository.DeleteAsync(team);
                return true;
            }
            return false;
        }

        public async Task<TeamUpdateDto> Get(int id)
        {
            var data = await _teamRepository.Get(id);
            if (data != null)
            {
                var dataVm = _mapper.Map<TeamUpdateDto>(data);
                return dataVm;
            }
            return null;
        }

        public async Task<ResponseDto> GetAll(Pagination pagination, Query query)
        {
            var skipValue = (pagination.Page - 1) * pagination.PerPage;
            var data = _teamRepository.Filter(filter: x =>
           string.IsNullOrEmpty(query.GeneralSearch) || x.Name.Contains(query.GeneralSearch),
            orderBy: x => x.OrderByDescending(x => x.Id));
            var dataCount = await data.CountAsync();
            if (skipValue >= dataCount)
            {
                skipValue = 0;
                pagination.Page = 1;
            }
            var pages = Convert.ToInt32(Math.Ceiling(dataCount / (float)pagination.PerPage));
            var dataList = await data.Skip(skipValue).Take(pagination.PerPage).Select(x => new TeamVm
            {
                Id = x.Id,
                StaticImage = x.StaticImage,
                Specialization = x.Specialization,
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

        public async Task<bool> UpdateTeamMember(TeamUpdateDto input)
        {
            if (input != null)
            {
                var team = _mapper.Map<TeamUpdateDto, Team>(input);
                var oldTeam = await _teamRepository.Get(input.Id);
                team.StaticImage = input.StaticImageFile != null ?
                    await _fileService.SaveFile(input.StaticImageFile, "Images") : oldTeam.StaticImage;
                team.MovedImage = input.StaticImageFile != null ?
                    await _fileService.SaveFile(input.MovedImageFile, "Images") : oldTeam.StaticImage;
                await _teamRepository.AddAsync(team);
                return true;
            }
            return false;
        }
    }
}
