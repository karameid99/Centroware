using Centroware.Model.DTOs;
using Centroware.Model.DTOs.Helpers;
using Centroware.Model.DTOs.Opinions;
using Centroware.Model.ViewModels.Sayings;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Centroware.Service.Interfaces
{
    public interface IOpinionService
    {
        Task<ResponseDto> GetAllOpinoins(Pagination pagination, Query query);
        Task<bool> AddOpinoin(OpinionDto input);
        Task<bool> UpdateOpinoin(UpdateOpinionDto input);
        Task<bool> Delete(int id);
        Task<UpdateOpinionDto> Get(int id);
    }
}
