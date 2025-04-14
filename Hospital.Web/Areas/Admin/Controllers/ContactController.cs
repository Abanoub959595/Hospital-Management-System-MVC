using Hospital.ViewModels;
using Hospitla.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Execution;

namespace Hospital.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController : Controller
    {
        private readonly IContactService contactService;
        private readonly IHospitalService hospitalService;

        public ContactController(
            IContactService contactService,
            IHospitalService hospitalService)
        {
            this.contactService = contactService;
            this.hospitalService = hospitalService;
        }
        [HttpGet]
        public IActionResult Index(int pageNumber=1, int pageSize=5)
        {
            return View(contactService.GetAll(pageNumber, pageSize));
        }
        [HttpGet]
        public IActionResult Details (int id)
        {
            return View(contactService.GetContactById(id));
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.hospitalData = hospitalService.GetAll();    
            return View();
        }
        [HttpPost]
        public IActionResult Create(ContactViewModel vmContact)
        {
            if (ModelState.IsValid)
            {
                contactService.AddContact(vmContact);
                return RedirectToAction("Index");
            }
            ViewBag.hospitalData = hospitalService.GetAll();
            return View(vmContact);
        }
        [HttpGet]
        public IActionResult Delete (int id)
        {
            contactService.DeleteContact(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit (int id)
        {
            ViewBag.hospitalData = hospitalService.GetAll();
            return View(contactService.GetContactById(id));
        }
        [HttpPost]  
        public IActionResult Edit (ContactViewModel vmContact)
        {
            if (ModelState.IsValid)
            {
                contactService.UpdateContact(vmContact);    
                return RedirectToAction("Index");
            }
            ViewBag.hospitalData = hospitalService.GetAll();

            return View(vmContact);
        }
    }
}
