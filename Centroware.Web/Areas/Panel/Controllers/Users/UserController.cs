using Centroware.Model.Constants;
using Centroware.Model.DTOs.Helpers;
using Centroware.Model.DTOs.Users;
using Centroware.Model.Entities.Identity;
using Centroware.Service.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Centroware.Web.Areas.Panel.Controllers.Users
{
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService, UserManager<CentrowareUser> userManager) : base(userManager)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<JsonResult> GetAll(Pagination pagination, Query query)
        {
            var response = await _userService.GetAll(pagination, query);
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
        public async Task<IActionResult> Create(CreateUserDto input)
        {
            if (ModelState.IsValid)
            {
                var isCreated = await _userService.CreateUser(input);
                if (isCreated) return Content(Constant.AddSuccessResult());
            }
            return View(input);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var data = await _userService.GetUser(id);
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateUserDto input)
        {
            if (ModelState.IsValid)
            {
                var isUpdated = await _userService.UpdateUser(input);
                if (isUpdated) return Content(Constant.EditSuccessResult());
            }
            return View(input);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var isDeleted = await _userService.DeleteUser(id);
            if (isDeleted) return Content(Constant.DeleteSuccessResult());
            return Content(Constant.DeleteFailedResult());
        }
    }
}
