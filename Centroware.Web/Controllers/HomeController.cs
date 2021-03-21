using Centroware.Model.ViewModels.Contacts;
using Centroware.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Centroware.Web.Controllers
{
    public class HomeController : BaseController
    {
        public readonly IHomeService _homeService;
        public HomeController(IHomeService homeService)
        {
            _homeService = homeService;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _homeService.GetHomePage();
            return View(response);
        }

        public async Task<IActionResult> GetServices()
        {
            var response = await _homeService.GetServices();
            return Json(response);
        }
        public async Task<IActionResult> About()
        {
            var response = await _homeService.GetAboutPage();
            return View(response);
        } 
        public async Task<IActionResult> Work()
        {
            var response = await _homeService.GetWorksPage();
            return View(response);
        }
        public async Task<string> CreateContact(ContactVm contact)
        {
            if (ModelState.IsValid)
            {
                var response = await _homeService.CreateContact(contact);
                if (response != null)
                {
                    return "success";
                }
            }
            return "error";
        }
        public IActionResult Contact()
        {
            return View();
        }

    }
}
