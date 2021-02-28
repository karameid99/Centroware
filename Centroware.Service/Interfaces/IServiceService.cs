using Centroware.Model.DTOs;
using Centroware.Model.DTOs.Helpers;
using Centroware.Model.DTOs.Services;
using Centroware.Model.DTOs.Teams;
using Centroware.Model.ViewModels.Teams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centroware.Service.Interfaces
{
    public interface IServiceService
    {
        Task<ResponseDto> GetAll(Pagination pagination, Query query);
        Task<ServiceUpdateDto> Get(int id);
        Task<bool> AddService(ServiceCreateDto input);
        Task<bool> UpdateService(ServiceUpdateDto input);
        Task<bool> Delete(int id);
    }
}