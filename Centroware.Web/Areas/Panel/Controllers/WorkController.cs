using Centroware.Model.Constants;
using Centroware.Model.DTOs.Works;
using Centroware.Model.Entities.Identity;
using Centroware.Service.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Centroware.Web.Areas.Panel.Controllers
{
    public class WorkController : BaseController
    {
        private readonly IWorkService _workService;
        public WorkController(IWorkService workService, UserManager<CentrowareUser> userManager) : base(userManager)
        {
            _workService = workService;
        }

        public IActionResult Create()
        {
            ViewBag.WorkStringId = Guid.NewGuid();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateArticle([FromForm] CreateArticleDto input)
        {
            var isCreated = await _workService.AddArticle(input);
            if (isCreated)
                return Content(Constant.AddSuccessResult());
            return Content(Constant.AddFuilerResult());
        }
    }
}
