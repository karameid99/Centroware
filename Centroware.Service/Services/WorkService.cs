using AutoMapper;
using Centroware.Model.DTOs.Works;
using Centroware.Model.Entities.Works;
using Centroware.Repository.Interfaces.Generic;
using Centroware.Service.Interfaces;
using System.Threading.Tasks;

namespace Centroware.Service.Services
{
    public class WorkService : IWorkService
    {
        private IBaseRepository<Work> _workRepository;
        private IMapper _mapper;

        public WorkService(IBaseRepository<Work> workRepository, IMapper mapper)
        {
            _workRepository = workRepository;
            _mapper = mapper;
        }

        public async Task<CreateWorkDto> AddWork(CreateWorkDto input)
        {
            var work = _mapper.Map<CreateWorkDto, Work>(input);
            await _workRepository.AddAsync(work);
            return input;
        }

        public async Task<CreateWorkDto> UpdateWork(UpdateWorkDto input)
        {
            var work = _mapper.Map<UpdateWorkDto, Work>(input);
            await _workRepository.UpdateAsync(work);
            return input;
        }
    }
}
