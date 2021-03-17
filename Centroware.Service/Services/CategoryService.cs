using AutoMapper;
using Centroware.Model.DTOs;
using Centroware.Model.DTOs.Blogs;
using Centroware.Model.DTOs.Helpers;
using Centroware.Model.Entities.Works;
using Centroware.Model.ViewModels.Blogs;
using Centroware.Model.ViewModels.Shared;
using Centroware.Repository.Interfaces.Generic;
using Centroware.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centroware.Service.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IBaseRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(IBaseRepository<Category> BlogCategoryRepository, IMapper mapper)
        {
            _categoryRepository = BlogCategoryRepository;
            _mapper = mapper;
        }

        public async Task<bool> AddBlogCategory(BlogCategoryCreateDto input)
        {
            if (input != null)
            {
                var BlogCategory = _mapper.Map<BlogCategoryCreateDto, Category>(input);
                await _categoryRepository.AddAsync(BlogCategory);
                return true;
            }
            return false;
        }

        public async Task<bool> Delete(int id)
        {
            if (id > 0)
            {
                var BlogCategory = await _categoryRepository.Get(id);
                await _categoryRepository.DeleteAsync(BlogCategory);
                return true;
            }
            return false;
        }

        public async Task<BlogCategoryUpdateDto> Get(int id)
        {
            var data = await _categoryRepository.Get(id);
            if (data != null)
            {
                var dataVm = _mapper.Map<BlogCategoryUpdateDto>(data);
                return dataVm;
            }
            return null;
        }

        public async Task<ResponseDto> GetAll(Pagination pagination, Query query)
        {
            var skipValue = (pagination.Page - 1) * pagination.PerPage;
            var data = _categoryRepository.Filter(filter: x =>
           string.IsNullOrEmpty(query.GeneralSearch) || x.Name.Contains(query.GeneralSearch),
            orderBy: x => x.OrderByDescending(x => x.Id));
            var dataCount = await data.CountAsync();
            if (skipValue >= dataCount)
            {
                skipValue = 0;
                pagination.Page = 1;
            }
            var pages = Convert.ToInt32(Math.Ceiling(dataCount / (float)pagination.PerPage));
            var dataList = await data.Skip(skipValue).Take(pagination.PerPage).Select(x => new BlogCategoryVm
            {
                Id = x.Id,
                Name = x.Name,
            }).ToListAsync();
            var response = new ResponseDto
            {
                meta = new Meta
                {
                    page = pagination.Page,
                    perpage = pagination.PerPage,
                    total = dataCount,
                    pages = pages,
                },
                data = dataList

            };
            return response;
        }

        public async Task<List<ListVm>> List()
        {
            return await _categoryRepository.Filter(filter: x => x.Id > 0, orderBy: x => x.OrderByDescending(x => x.Id)).Select(x => new ListVm
            {
                Id = x.Id,
                Name = x.Name,
            }).ToListAsync();
        }

        public async Task<bool> UpdateBlogCategory(BlogCategoryUpdateDto input)
        {
            if (input != null)
            {
                var BlogCategory = _mapper.Map<BlogCategoryUpdateDto, Category>(input);
                await _categoryRepository.UpdateAsync(BlogCategory);
                return true;
            }
            return false;
        }
    }
}
