using Hospital.ViewModels;
using Hospitla.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hospital.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoomController : Controller
    {
        private readonly IRoomService roomService;
        private readonly IHospitalService hospitalService;

        public RoomController(
            IRoomService roomService,
            IHospitalService hospitalService)
        {
            this.roomService = roomService;
            this.hospitalService = hospitalService;
        }
        public IActionResult Index(int pageNumber=1, int pageSize=5)
        {
            return View(roomService.GetAllRooms(pageNumber, pageSize));
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.hospitalData = hospitalService.GetAll();
            return View();
        }
        [HttpPost]
        public IActionResult Create (RoomViewModel room)
        {
            if (ModelState.IsValid)
            {
                roomService.AddRoom(room);
                return RedirectToAction("Index");
            }
            ViewBag.hospitalData = hospitalService.GetAll();
            return View(room);
        }
        [HttpGet]
        public IActionResult Edit (int id)
        {
            ViewBag.hospitalData = hospitalService.GetAll();
            return View (roomService.GetRoomById(id));
        }
        [HttpPost]
        public IActionResult Edit (RoomViewModel room)
        {
            if (ModelState.IsValid)
            {
                roomService.UpdateRoom(room);
                return RedirectToAction("Index");
            }
            ViewBag.hospitalData = hospitalService.GetAll();
            return View(room);
        }
        [HttpGet]
        public IActionResult Delete (int id)
        {
            roomService.RemoveRoom(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(roomService.GetRoomById(id));
        }
    }
}
