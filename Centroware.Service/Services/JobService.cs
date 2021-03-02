using AutoMapper;
using Centroware.Model.DTOs;
using Centroware.Model.DTOs.Helpers;
using Centroware.Model.DTOs.Jobs;
using Centroware.Model.Entities.Jobs;
using Centroware.Model.ViewModels.Jobs;
using Centroware.Model.ViewModels.Shared;
using Centroware.Repository.Interfaces.Generic;
using Centroware.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centroware.Service.Services
{
    public class JobService : IJobService
    {
        private readonly IBaseRepository<Job> _JobRepository;
        private readonly IMapper _mapper;
        public JobService(IBaseRepository<Job> JobRepository, IMapper mapper)
        {
            _JobRepository = JobRepository;
            _mapper = mapper;
        }

        public async Task<bool> AddJob(JobCreateDto input)
        {
            if (input != null)
            {
                var Job = _mapper.Map<JobCreateDto, Job>(input);
                await _JobRepository.AddAsync(Job);
                return true;
            }
            return false;
        }

        public async Task<bool> Delete(int id)
        {
            if (id > 0)
            {
                var Job = await _JobRepository.Get(id);
                await _JobRepository.DeleteAsync(Job);
                return true;
            }
            return false;
        }

        public async Task<JobUpdateDto> Get(int id)
        {
            var data = await _JobRepository.Get(id);
            if (data != null)
            {
                var dataVm = _mapper.Map<JobUpdateDto>(data);
                return dataVm;
            }
            return null;
        }

        public async Task<ResponseDto> GetAll(Pagination pagination, Query query)
        {
            var skipValue = (pagination.Page - 1) * pagination.PerPage;
            var data = _JobRepository.Filter(filter: x =>
           string.IsNullOrEmpty(query.GeneralSearch) || x.Title.Contains(query.GeneralSearch),
            orderBy: x => x.OrderByDescending(x => x.Id));
            var dataCount = await data.CountAsync();
            if (skipValue >= dataCount)
            {
                skipValue = 0;
                pagination.Page = 1;
            }
            var pages = Convert.ToInt32(Math.Ceiling(dataCount / (float)pagination.PerPage));
            var dataList = await data.Skip(skipValue).Take(pagination.PerPage).Select(x => new JobVm
            {
                Id = x.Id,
                Title = x.Title,
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

        public async Task<List<ListVm>> List()
        {
            return await _JobRepository.Filter(filter: x => x.Id > 0, orderBy: x => x.OrderByDescending(x => x.Id)).Select(x => new ListVm
            {
                Id = x.Id,
                Name = x.Title
            }).ToListAsync();
        }

        public async Task<bool> UpdateJob(JobUpdateDto input)
        {
            if (input != null)
            {
                var Job = _mapper.Map<JobUpdateDto, Job>(input);
                await _JobRepository.UpdateAsync(Job);
                return true;
            }
            return false;
        }
    }
}
