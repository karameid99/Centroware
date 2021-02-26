using Microsoft.AspNetCore.Mvc;
using Centroware.Model.Entities.Identity;
using Microsoft.AspNetCore.Identity;


namespace Centroware.Web.Areas.Panel.Controllers
{
    [Area("Panel")]
    [Route("Panel/[controller]/[action]")]
    [Route("Panel/[controller]/[action]/{id?}")]
    public class BaseController : Controller
    {
        protected readonly UserManager<CentrowareUser> _userManager;

        public BaseController(UserManager<CentrowareUser> userManager)
        {
            _userManager = userManager;
        }
    }
}
