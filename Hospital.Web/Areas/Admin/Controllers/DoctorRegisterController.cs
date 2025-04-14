using Hospital.ViewModels;
using Hospitla.Services.Implementation;
using Hospitla.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DoctorRegisterController : Controller
    {
        private readonly IDoctorAuthenticationService doctorAuthenticationService;

        public DoctorRegisterController(
            IDoctorAuthenticationService doctorAuthenticationService)
        {
            this.doctorAuthenticationService = doctorAuthenticationService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignUp (DoctorViewModel model)
        {
            if (ModelState.IsValid)
            {
                doctorAuthenticationService.SignUp(model);
                return View("Hospital/Index");
            }
            return View(model);
        }

    }
}
