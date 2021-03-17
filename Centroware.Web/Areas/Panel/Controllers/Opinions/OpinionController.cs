using Centroware.Model.Constants;
using Centroware.Model.DTOs.Blogs;
using Centroware.Model.DTOs.Helpers;
using Centroware.Model.DTOs.Opinions;
using Centroware.Model.Entities.Identity;
using Centroware.Service.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Centroware.Web.Areas.Panel.Controllers.Opinoins
{
    public class OpinionController : BaseController
    {
        private readonly IOpinionService _opinionService;
        public OpinionController(IOpinionService opinionService, UserManager<CentrowareUser> userManager) : base(userManager)
        {
            _opinionService = opinionService;
        }

        [HttpPost]
        public async Task<JsonResult> GetAll(Pagination pagination, Query query)
        {
            var response = await _opinionService.GetAllOpinoins(pagination, query);
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
        public async Task<IActionResult> Create(OpinionDto input)
        {
            if (ModelState.IsValid)
            {
                var isCreated = await _opinionService.AddOpinoin(input);
                if (isCreated) return Content(Constant.AddSuccessResult());
            }
            return View(input);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var data = await _opinionService.Get(id);
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateOpinionDto input)
        {
            if (ModelState.IsValid)
            {
                var isUpdated = await _opinionService.UpdateOpinoin(input);
                if (isUpdated) return Content(Constant.EditSuccessResult());
            }
            return View(input);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var isDeleted = await _opinionService.Delete(id);
            if (isDeleted) return Content(Constant.DeleteSuccessResult());
            return Content(Constant.DeleteFailedResult());
        }
    }
}
