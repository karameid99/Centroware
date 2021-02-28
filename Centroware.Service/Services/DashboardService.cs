using Centroware.Model.Entities.Blogs;
using Centroware.Model.Entities.Contact;
using Centroware.Model.Entities.Teams;
using Centroware.Model.ViewModels;
using Centroware.Model.ViewModels.Blogs;
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
    public class DashboardService : IDashboardService
    {
        private readonly IBaseRepository<Contact> _contactRepository;
        private readonly IBaseRepository<Blog> _blogRepository;
        private readonly IBaseRepository<Team> _teamRepository;

        public DashboardService(IBaseRepository<Contact> contactRepository, IBaseRepository<Blog> blogRepository, IBaseRepository<Team> teamRepository)
        {
            _contactRepository = contactRepository;
            _blogRepository = blogRepository;
            _teamRepository = teamRepository;
        }

        public async Task<DashboardVm> GetDashboard()
        {
            var teams = await _teamRepository.Filter(filter: x => x.Id > 0, 0, 5,
                orderBy: x => x.OrderByDescending(x => x.Id))
                .Select(x => new Model.ViewModels.Teams.TeamVm
                {
                    Name = x.Name,
                    Id = x.Id,
                    Specialization = x.Specialization,
                    StaticImage = x.StaticImage
                }).ToListAsync();
            var blogs = await _blogRepository.Filter(filter: x => x.Id > 0, 0, 5,
                orderBy: x => x.OrderByDescending(x => x.Id),
                include: x => x.Include(x => x.BlogCategory))
                .Select(x => new BlogVm
                {
                    Title = x.Title,
                    Id = x.Id,
                    Category = x.BlogCategory.Name,
                    ImagePath = x.ImagePath
                }).ToListAsync();
            var data = new DashboardVm
            {
                ArticleCount = await _blogRepository.GetCountAsync(null),
                ContactCount = await _contactRepository.GetCountAsync(null),
                TeamsCount = await _teamRepository.GetCountAsync(null),
                Teams =  teams,
                Blogs =  blogs,
            };
            return data;
        }
    }
}
