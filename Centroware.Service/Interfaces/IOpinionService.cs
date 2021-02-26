using Centroware.Model.DTOs.Opinions;
using Centroware.Model.ViewModels.Sayings;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Centroware.Service.Interfaces
{
    public interface IOpinionService
    {
        Task<List<OpinoinVm>> GetAllOpinoins(string searchKey, int skip, int take);
        Task<bool> AddOpinoin(OpinionDto input);
        Task<bool> UpdateOpinoin(OpinionDto input);
        Task<bool> Delete(int id);
    }
}
