using Centroware.Data.Data;
using Centroware.Model.DTOs.Helpers;
using Centroware.Model.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Centroware.Web.Areas.Panel.Controllers
{

    public class UserController : BaseController
    {
        private readonly CentrowareDbContext _context;
        public UserController(CentrowareDbContext context, UserManager<CentrowareUser> userManager) : base(userManager)
        {
            _context = context;
        }
        public JsonResult AjaxData(Pagination pagination , Query query)
        {
            var data = _context.Users.ToList();
            int totalCount = data.Count();
            var items = data.Select(x => new
            {
                x.Id,
                x.Email,
                x.PhoneNumber,
                x.UserName,

            }).ToList();
            var result =
               new
               {
                   recordsTotal = totalCount,
                   recordsFiltered = totalCount,
                   data = items
               };
            return Json(items);
        }
        public IActionResult Index()
        {
            return View();
        }

    }
}
