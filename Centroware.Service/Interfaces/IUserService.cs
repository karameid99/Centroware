using Centroware.Model.DTOs;
using Centroware.Model.DTOs.Helpers;
using Centroware.Model.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centroware.Service.Interfaces
{
    public interface IUserService
    {
        Task<ResponseDto> GetAll(Pagination pagination, Query query);
        Task<bool> CreateUser(CreateUserDto user);
        Task<bool> UpdateUser(UpdateUserDto user);
        Task<bool> DeleteUser(string id);
        Task<UpdateUserDto> GetUser(string id);

    }
}
