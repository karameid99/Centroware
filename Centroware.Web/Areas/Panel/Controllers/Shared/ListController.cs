using Centroware.Model.Entities.Identity;
using Centroware.Service.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Centroware.Web.Areas.Panel.Controllers.Shared
{
    public class ListController : BaseController
    {
        private readonly IBlogCategoryService _blogCategoryService;


        public ListController(IBlogCategoryService blogCategoryService, UserManager<CentrowareUser> userManager) : base(userManager)
        {
            _blogCategoryService = blogCategoryService;
        }

        public async Task<IActionResult> GetBlogCategory()
        {
            var listData = await _blogCategoryService.List();
            return Json(listData);
        }

    }
}
