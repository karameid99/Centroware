using Centroware.Model.Constants;
using Centroware.Model.DTOs.Helpers;
using Centroware.Model.DTOs.Services;
using Centroware.Model.Entities.Identity;
using Centroware.Service.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Centroware.Web.Areas.Panel.Controllers.Services
{
    public class ServiceController : BaseController
    {
        private readonly IServiceService _serviceService;
        public ServiceController(IServiceService ServiceService, UserManager<CentrowareUser> userManager) : base(userManager)
        {
            _serviceService = ServiceService;
        }

        [HttpPost]
        public async Task<JsonResult> GetAll(Pagination pagination, Query query)
        {
            var response = await _serviceService.GetAll(pagination, query);
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
        public async Task<IActionResult> Create(ServiceCreateDto input)
        {
            if (ModelState.IsValid)
            {
                var isCreated = await _serviceService.AddService(input);
                if (isCreated) return Content(Constant.AddSuccessResult());
            }
            return View(input);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var data = await _serviceService.Get(id);
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ServiceUpdateDto input)
        {
            if (ModelState.IsValid)
            {
                var isUpdated = await _serviceService.UpdateService(input);
                if (isUpdated) return Content(Constant.EditSuccessResult());
            }
            return View(input);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var isDeleted = await _serviceService.Delete(id);
            if (isDeleted) return Content(Constant.DeleteSuccessResult());
            return Content(Constant.DeleteFailedResult());
        }
    }
}
