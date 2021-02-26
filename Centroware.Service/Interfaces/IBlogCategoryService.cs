using Centroware.Model.DTOs;
using Centroware.Model.DTOs.Blogs;
using Centroware.Model.DTOs.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centroware.Service.Interfaces
{
    public interface IBlogCategoryService
    {
        Task<ResponseDto> GetAll(Pagination pagination, Query query);
        Task<BlogCategoryUpdateDto> Get(int id);
        Task<bool> AddBlogCategory(BlogCategoryCreateDto input);
        Task<bool> UpdateBlogCategory(BlogCategoryUpdateDto input);
        Task<bool> Delete(int id);
    }
}
