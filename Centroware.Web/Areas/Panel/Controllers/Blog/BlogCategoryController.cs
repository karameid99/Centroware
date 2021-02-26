using Centroware.Model.Constants;
using Centroware.Model.DTOs.Blogs;
using Centroware.Model.DTOs.Helpers;
using Centroware.Model.Entities.Identity;
using Centroware.Service.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Centroware.Web.Areas.Panel.Controllers.BlogCategory
{
    public class BlogCategoryController : BaseController
    {
        private readonly IBlogCategoryService _blogCategoryService;
        public BlogCategoryController(IBlogCategoryService BlogCategoryService, UserManager<CentrowareUser> userManager) : base(userManager)
        {
            _blogCategoryService = BlogCategoryService;
        }

        [HttpPost]
        public async Task<JsonResult> GetAll(Pagination pagination, Query query)
        {
            var response = await _blogCategoryService.GetAll(pagination, query);
            return Json(response);
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BlogCategoryCreateDto input)
        {
            if (ModelState.IsValid)
            {
                var isCreated = await _blogCategoryService.AddBlogCategory(input);
                if (isCreated) return Content(Constant.AddSuccessResult());
            }
            return View(input);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var data = await _blogCategoryService.Get(id);
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(BlogCategoryUpdateDto input)
        {
            if (ModelState.IsValid)
            {
                var isUpdated = await _blogCategoryService.UpdateBlogCategory(input);
                if (isUpdated) return Content(Constant.EditSuccessResult());
            }
            return View(input);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var isDeleted = await _blogCategoryService.Delete(id);
            if (isDeleted) return Content(Constant.DeleteSuccessResult());
            return Content(Constant.DeleteFailedResult());
        }
    }
}
