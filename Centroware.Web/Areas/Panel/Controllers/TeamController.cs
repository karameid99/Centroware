using Centroware.Model.Constants;
using Centroware.Model.DTOs.Helpers;
using Centroware.Model.DTOs.Teams;
using Centroware.Model.Entities.Identity;
using Centroware.Service.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Centroware.Web.Areas.Panel.Controllers
{
    public class TeamController : BaseController
    {
        private readonly ITeamService _teamService;
        public TeamController(ITeamService teamService, UserManager<CentrowareUser> userManager) : base(userManager)
        {
            _teamService = teamService;
        }

        [HttpPost]
        public async Task<JsonResult> GetAll(Pagination pagination, Query query)
        {
            var response = await _teamService.GetAll(pagination, query);
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
        public async Task<IActionResult> Create(TeamCreateDto input)
        {
            if (ModelState.IsValid)
            {
                var isCreated = await _teamService.AddTeamMember(input);
                if (isCreated) return Content(Constant.AddSuccessResult());
            }
            return View(input);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var data = await _teamService.Get(id);
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TeamUpdateDto input)
        {
            if (ModelState.IsValid)
            {
                var isUpdated = await _teamService.UpdateTeamMember(input);
                if (isUpdated) return Content(Constant.EditSuccessResult());
            }
            return View(input);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var isDeleted = await _teamService.Delete(id);
            if (isDeleted) return Content(Constant.DeleteSuccessResult());
            return Content(Constant.DeleteFailedResult());
        }
    }
}
