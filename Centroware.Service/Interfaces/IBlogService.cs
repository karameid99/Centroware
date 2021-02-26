using Centroware.Model.DTOs;
using Centroware.Model.DTOs.Blogs;
using Centroware.Model.DTOs.Helpers;
using System.Threading.Tasks;

namespace Centroware.Service.Interfaces
{
   public interface IBlogService
    {
        Task<ResponseDto> GetAll(Pagination pagination, Query query);
        Task<BlogUpdateDto> Get(int id);
        Task<bool> AddBlog(BlogCreateDto input);
        Task<bool> UpdateBlog(BlogUpdateDto input);
        Task<bool> Delete(int id);
    }
}
