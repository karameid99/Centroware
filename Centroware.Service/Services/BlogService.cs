using AutoMapper;
using Centroware.Model.DTOs;
using Centroware.Model.DTOs.Helpers;
using Centroware.Model.DTOs.Blogs;
using Centroware.Model.Entities.Blogs;
using Centroware.Repository.Interfaces.Generic;
using Centroware.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Centroware.Model.ViewModels.Blogs;

namespace Centroware.Service.Services
{
    public class BlogService : IBlogService
    {
        private readonly IBaseRepository<Blog> _BlogRepository;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;

        public BlogService(IBaseRepository<Blog> BlogRepository, IMapper mapper, IFileService fileService)
        {
            _BlogRepository = BlogRepository;
            _mapper = mapper;
            _fileService = fileService;
        }

        public async Task<bool> AddBlog(BlogCreateDto input)
        {
            if (input != null)
            {
                var Blog = _mapper.Map<BlogCreateDto, Blog>(input);
                Blog.ImagePath = await _fileService.SaveFile(input.ImageFile, "Images");
                await _BlogRepository.AddAsync(Blog);
                return true;
            }
            return false;
        }

        public async Task<bool> Delete(int id)
        {
            if (id > 0)
            {
                var Blog = await _BlogRepository.Get(id);
                await _BlogRepository.DeleteAsync(Blog);
                return true;
            }
            return false;
        }

        public async Task<BlogUpdateDto> Get(int id)
        {
            var data = await _BlogRepository.Get(id);
            if (data != null)
            {
                var dataVm = _mapper.Map<BlogUpdateDto>(data);
                return dataVm;
            }
            return null;
        }

        public async Task<ResponseDto> GetAll(Pagination pagination, Query query)
        {
            var skipValue = (pagination.Page - 1) * pagination.PerPage;
            var data = _BlogRepository.Filter(filter: x =>
           string.IsNullOrEmpty(query.GeneralSearch) || x.Title.Contains(query.GeneralSearch),
            orderBy: x => x.OrderByDescending(x => x.Id));
            var dataCount = await data.CountAsync();
            if (skipValue >= dataCount)
            {
                skipValue = 0;
                pagination.Page = 1;
            }
            var pages = Convert.ToInt32(Math.Ceiling(dataCount / (float)pagination.PerPage));
            var dataList = await data.Skip(skipValue).Take(pagination.PerPage).Select(x => new BlogVm
            {
                Id = x.Id,
                Title = x.Title,
                ImagePath = x.ImagePath,
                Category = x.BlogCategory.Name,
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

        public async Task<bool> UpdateBlog(BlogUpdateDto input)
        {
            if (input != null)
            {
                var Blog = _mapper.Map<BlogUpdateDto, Blog>(input);
                var oldBlog = await _BlogRepository.FindFirst(x => x.Id == input.Id);
                Blog.ImagePath = input.ImageFile != null ?
                    await _fileService.SaveFile(input.ImageFile, "Images") : oldBlog.ImagePath;

                await _BlogRepository.UpdateAsync(Blog);
                return true;
            }
            return false;
        }
    }
}
