using AutoMapper;
using Centroware.Model.DTOs;
using Centroware.Model.DTOs.Helpers;
using Centroware.Model.DTOs.Works;
using Centroware.Model.Entities.Works;
using Centroware.Model.ViewModels.Works;
using Centroware.Repository.Interfaces.Generic;
using Centroware.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Centroware.Service.Services
{
    public class WorkService : IWorkService
    {
        private IBaseRepository<Work> _workRepository;
        private IBaseRepository<Article> _articleRepository;
        private IFileService _fileService;
        private IMapper _mapper;

        public WorkService(IFileService fileService, IBaseRepository<Work> workRepository, IBaseRepository<Article> articleRepository, IMapper mapper)
        {
            _workRepository = workRepository;
            _articleRepository = articleRepository;
            _mapper = mapper;
            _fileService = fileService;
        }

        public async Task<Article> AddArticle(CreateArticleDto input)
        {
            if (input == null)
                return null;
            var article = _mapper.Map<CreateArticleDto, Article>(input);
            await _articleRepository.AddAsync(article);
            return article;
        }

        public async Task<CreateWorkDto> AddWork(CreateWorkDto input)
        {
            var work = _mapper.Map<CreateWorkDto, Work>(input);
            if (input.MainImageFile != null)
                work.MainImage =  await _fileService.SaveFile(input.MainImageFile, "Images");
            await _workRepository.AddAsync(work);
            var articles = await _articleRepository.Find(x => x.WorkStringId == input.WorkStringId);
            if (articles != null && articles.Any())
            {
                foreach (var item in articles)
                {
                    item.WorkId = work.Id;
                }
            }
            await _articleRepository.UpdateRangeAsync(articles);
            return input;
        }

        public async Task<bool> Delete(int id)
        {
            if (id > 0)
            {
                var work = await _workRepository.Get(id);
                await _workRepository.DeleteAsync(work);
                return true;
            }
            return false;
        }

        public async Task<UpdateWorkDto> Get(int id)
        {
            var data = await _workRepository.Get(id);
            if (data == null)
                return null;
            var dataDto = _mapper.Map<UpdateWorkDto>(data);
            return dataDto;
        }

        public async Task<ResponseDto> GetAll(Pagination pagination, Query query)
        {
            var skipValue = (pagination.Page - 1) * pagination.PerPage;

            var data = _workRepository.Filter(
                filter: x => string.IsNullOrEmpty(query.GeneralSearch)
                || x.Title.Contains(query.GeneralSearch),
                orderBy: x => x.OrderByDescending(x => x.Id),
                include: x => x.Include(x => x.Category));

            var dataCount = await data.CountAsync();
            if (skipValue >= dataCount) { skipValue = 0; pagination.Page = 1; }
            var pages = Convert.ToInt32(Math.Ceiling(dataCount / (float)pagination.PerPage));
            var dataList = await data.Skip(skipValue).Take(pagination.PerPage).Select(x => new WorkVm
            {
                Id = x.Id,
                Title = x.Title,
                MainImage = x.MainImage,
                Category = x.Category.Name,
                About = x.About,
                CreatedAt = x.CreatedAt.ToString("dd/MM/yyyy"),
                OurPart = x.OurPart,
                SubTitle = x.SubTitle
            }).ToListAsync();
            var response = new ResponseDto
            {
                meta = new Meta
                { page = pagination.Page, perpage = pagination.PerPage, total = dataCount, pages = pages, },
                data = dataList
            };
            return response;
        }

        public async Task<List<Article>> GetAllArticle(int id)
        {
            return await _articleRepository.Find(x => x.WorkId == id);
        }

        public async Task<bool> RemoveArticle(int id)
        {
            var articl = await _articleRepository.Get(id);
            if (articl == null)
                return false;
            await _articleRepository.DeleteAsync(articl);
            return true;
        }

        public async Task<CreateWorkDto> UpdateWork(UpdateWorkDto input)
        {
            var work = await _workRepository.Get(input.Id);
            work.Title = input.Title;
            work.OurPart = input.OurPart;
            work.SubTitle = input.SubTitle;
            work.About = input.About;
            work.CategoryId = input.CategoryId;
            work.MainImage = input.MainImageFile != null ?
                await _fileService.SaveFile(input.MainImageFile, "Images") : work.MainImage;
            await _workRepository.UpdateAsync(work);
            return input;
        }
    }
}
