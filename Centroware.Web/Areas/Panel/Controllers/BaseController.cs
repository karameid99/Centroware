using Microsoft.AspNetCore.Mvc;
using Centroware.Model.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace Centroware.Web.Areas.Panel.Controllers
{
    [Area("Panel")]
    [Route("Panel/[controller]/[action]")]
    [Route("Panel/[controller]/[action]/{id?}")]
    [Authorize]
    public class BaseController : Controller
    {
        protected readonly UserManager<CentrowareUser> _userManager;
        protected string UserId;
        protected string UserName;
        public BaseController(UserManager<CentrowareUser> userManager)
        {
            _userManager = userManager;
        }
      
        public  override void OnActionExecuting(ActionExecutingContext context)
        {
            if (User.Identity.IsAuthenticated)
            {
                base.OnActionExecuting(context);
                try
                {
                    
                    UserId = _userManager.GetUserId(HttpContext.User);
                    var user =  _userManager.GetUserName(HttpContext.User);
                    ViewBag.UserId = UserId;
                    ViewBag.Email = user;
                    ViewBag.UserName = UserName;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
        }

    }
}
