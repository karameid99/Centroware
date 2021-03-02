using Centroware.Model.DTOs;
using Centroware.Model.DTOs.Blogs;
using Centroware.Model.DTOs.Helpers;
using Centroware.Model.DTOs.Jobs;
using Centroware.Model.ViewModels.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centroware.Service.Interfaces
{
    public interface IJobService
    {
        Task<ResponseDto> GetAll(Pagination pagination, Query query);
        Task<JobUpdateDto> Get(int id);
        Task<bool> AddJob(JobCreateDto input);
        Task<bool> UpdateJob(JobUpdateDto input);
        Task<bool> Delete(int id);
        Task<List<ListVm>> List();
    }
}
