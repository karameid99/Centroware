using Centroware.Model.Entities.Identity;
using Centroware.Service.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Centroware.Web.Areas.Panel.Controllers.Dashboard
{
    public class DashboardController : BaseController
    {
        private readonly IDashboardService _dashboardService;
        public DashboardController(IDashboardService dashboardService, UserManager<CentrowareUser> userManager) : base(userManager)
        {
            _dashboardService = dashboardService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _dashboardService.GetDashboard();
            return View(result);
        }
    }
}
