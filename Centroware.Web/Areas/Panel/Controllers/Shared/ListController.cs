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
        private readonly ICategoryService _categoryService;


        public ListController(IBlogCategoryService blogCategoryService, ICategoryService categoryService, UserManager<CentrowareUser> userManager) : base(userManager)
        {
            _blogCategoryService = blogCategoryService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> GetBlogCategory()
        {
            var listData = await _blogCategoryService.List();
            return Json(listData);
        }
        public async Task<IActionResult> GetCategory()
        {
            var listData = await _categoryService.List();
            return Json(listData);
        }
    }
}
