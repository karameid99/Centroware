using Centroware.Model.ViewModels.HomeVms;
using Centroware.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace Centroware.Web.Controllers
{
    public class BaseController : Controller
    {
        //public readonly IHomeService _homeService;
        //public BaseController(IHomeService homeService)
        //{
        //    _homeService = homeService;
        //}

        //public async override void OnActionExecuting(ActionExecutingContext context)
        //{
        //    base.OnActionExecuting(context);
        //    try
        //    {
        //        var orgSettings = await _homeService.GetMainSettings();
        //         ViewData["Setting"] = orgSettings;
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //    }

        //}
    }
}
