using HealthHub.Models;
using HealthHub.Service;
using Microsoft.AspNetCore.Mvc;

namespace HealthHub.NewFolder
{
    [Route("api/")]
    [ApiController]
    public class DoctorController : Controller
    {
        private readonly DoctorService doctorService;
        public DoctorController(DoctorService doctorService)
        {
            this.doctorService = doctorService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult<DoctorModel>> CreateDoctor(DoctorModel model)
        {
            var createDoctor = await doctorService.CreateDoctorAsync(model);
            return View(createDoctor);
        }

        [HttpGet]
        public Task<DoctorModel> GetDoctor(long id)
        {
            return doctorService.GetDoctorByIdAsync(id);
        }
    }
}
