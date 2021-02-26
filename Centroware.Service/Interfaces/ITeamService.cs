using Centroware.Model.DTOs;
using Centroware.Model.DTOs.Helpers;
using Centroware.Model.DTOs.Teams;
using Centroware.Model.ViewModels.Teams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centroware.Service.Interfaces
{
    public interface ITeamService
    {
        Task<ResponseDto> GetAll(Pagination pagination, Query query);
        Task<TeamUpdateDto> Get(int id);
        Task<bool> AddTeamMember(TeamCreateDto input);
        Task<bool> UpdateTeamMember(TeamUpdateDto input);
        Task<bool> Delete(int id);
    }
}