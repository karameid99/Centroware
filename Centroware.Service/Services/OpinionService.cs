using AutoMapper;
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

        public OpinionService(IBaseRepository<Opinion> opinoinRepository, IMapper mapper)
        {
            _opinoinRepository = opinoinRepository;
            _mapper = mapper;
        }

        public async Task<bool> AddOpinoin(OpinionDto input)
        {
            var opinoin = _mapper.Map<OpinionDto, Opinion>(input);
            await _opinoinRepository.AddAsync(opinoin);
            return true;

        }

        public async Task<bool> Delete(int id)
        {
            var opinoin = await _opinoinRepository.Get(id);
            if (opinoin != null)
                return false;
            await _opinoinRepository.DeleteAsync(opinoin);
            return true;
        }

        public async Task<List<OpinoinVm>> GetAllOpinoins(string searchKey, int skip, int take)
        {
            var data = await _opinoinRepository.Filter(filter: x =>
            (string.IsNullOrEmpty(searchKey) || x.Name.Contains(searchKey)) && !x.WorkId.HasValue,
            orderBy: x => x.OrderByDescending(x => x.Id)).Skip(skip).Take(take)
            .Select(x => new OpinoinVm
            {
                Id = x.Id,
                Image = x.Image,
                Specialty = x.Specialty,
                Name = x.Name,
            }).ToListAsync();
            return data;
        }

        public Task<bool> UpdateOpinoin(OpinionDto input)
        {
            throw new NotImplementedException();
        }
    }
}
