using Centroware.Model.DTOs;
using Centroware.Model.DTOs.Helpers;
using Centroware.Model.DTOs.Works;
using Centroware.Model.Entities.Works;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Centroware.Service.Interfaces
{
    public interface IWorkService
    {
        Task<ResponseDto> GetAll(Pagination pagination, Query query);
        Task<UpdateWorkDto> Get(int id);
        Task<CreateWorkDto> AddWork(CreateWorkDto input);
        Task<Article> AddArticle(CreateArticleDto input);
        Task<bool> Delete(int id);
        Task<List<Article>> GetAllArticle(int id);
        Task<bool> RemoveArticle(int id);
        Task<CreateWorkDto> UpdateWork(UpdateWorkDto input);
    }
}
