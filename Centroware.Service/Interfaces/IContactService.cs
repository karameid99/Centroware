using Centroware.Model.DTOs;
using Centroware.Model.DTOs.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centroware.Service.Interfaces
{
   public interface IContactService
    {
        Task<ResponseDto> GetAll(Pagination pagination, Query query);
    }
}
