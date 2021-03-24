using Centroware.Model.Constants;
using Centroware.Model.DTOs.Helpers;
using Centroware.Model.DTOs.Works;
using Centroware.Model.Entities.Identity;
using Centroware.Service.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Centroware.Web.Areas.Panel.Controllers.Work
{
    public class WorkController : BaseController
    {
        private readonly IWorkService _workService;
        public WorkController(IWorkService workService, UserManager<CentrowareUser> userManager) : base(userManager)
        {
            _workService = workService;
        }

        [HttpGet]
        public async Task<JsonResult> GetAllArticle(int id)
        {
            var response = await _workService.GetAllArticle(id);
            return Json(response);
        }

        [HttpPost]
        public async Task<JsonResult> GetAll(Pagination pagination, Query query)
        {
            var response = await _workService.GetAll(pagination, query);
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
            ViewBag.WorkStringId = Guid.NewGuid();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateWorkDto input)
        {
            if (ModelState.IsValid)
            {
                var result = await _workService.AddWork(input);
                if (result != null)
                    return RedirectToAction("Index");
                ViewBag.WorkStringId = Guid.NewGuid();
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var data = await _workService.Get(id);
            if (data == null)
            {
                return NotFound();
            }
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(UpdateWorkDto input)
        {
            if (ModelState.IsValid)
            {
                var result = await _workService.UpdateWork(input);
                if (result != null)
                    return RedirectToAction("Index");
            }
            return View(input);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var isDeleted = await _workService.Delete(id);
            if (isDeleted) return Content(Constant.DeleteSuccessResult());
            return Content(Constant.DeleteFailedResult());
        }
        [HttpPost]
        public async Task<IActionResult> CreateArticle([FromForm] CreateArticleDto input)
        {
            var isCreated = await _workService.AddArticle(input);
            if (isCreated != null)
                return Ok(new
                {
                    message = Constant.AddSuccessResult(),
                    data = isCreated,
                });
            return Content(Constant.AddFuilerResult());
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteArticle(int id)
        {
            var isDeleted = await _workService.RemoveArticle(id);
            if (isDeleted)
                return Content(Constant.DeleteSuccessResult());
            return Content(Constant.AddFuilerResult());
        }

    }
}
