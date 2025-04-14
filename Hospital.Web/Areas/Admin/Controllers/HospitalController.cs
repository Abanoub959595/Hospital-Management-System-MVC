using Hospital.ViewModels;
using Hospitla.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HospitalController : Controller
    {
        private readonly IHospitalService hospitalService;

        public HospitalController(IHospitalService hospitalService)
        {
            this.hospitalService = hospitalService;
        }
        public IActionResult Index(int pageNumber=1, int pageSize = 10)
        {
            return View(hospitalService.GetAll(pageNumber, pageSize));
        }
        [HttpGet]
        public IActionResult Edit (int id)
        {
            var vm = hospitalService.GetHospitalById(id);
            return View(vm);
        }
        [HttpPost]
        public IActionResult Edit (HospitalViewModel hospitalViewModel)
        {
            if (ModelState.IsValid)
            {
                hospitalService.UpdateHospital(hospitalViewModel);
                return RedirectToAction("Index");
            }
            return View(hospitalViewModel);
        }
        public IActionResult Delete(int id)
        {
            hospitalService.DeleteHospital(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Create (HospitalViewModel hospitalViewModel)
        {
            if (ModelState.IsValid)
            {
                hospitalService.InsertHospital(hospitalViewModel);
                return RedirectToAction("Index");
            }
            return View(hospitalViewModel);
        }
        [HttpGet]
        public IActionResult Details (int id)
        {
            var model = hospitalService.GetHospitalById(id);
            return View(model);
        }
    }
}
