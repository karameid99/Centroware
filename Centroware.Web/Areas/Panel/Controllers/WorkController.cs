using Centroware.Model.Entities.Identity;
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
        public WorkController(UserManager<CentrowareUser> userManager) : base(userManager)
        {
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
