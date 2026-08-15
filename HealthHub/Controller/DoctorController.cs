using HealthHub.Models;
using HealthHub.Service;
using Microsoft.AspNetCore.Mvc;

namespace HealthHub.NewFolder
{
    [Route("api/")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly DoctorService doctorService;

        public DoctorController(DoctorService doctorService)
        {
            this.doctorService = doctorService;
        }


        [Route("Createdoctor")]
        [HttpPost]
        public async Task<ActionResult<DoctorModel>> CreateDoctor(DoctorModel model)
        {
            var createDoctor = await doctorService.CreateDoctorAsync(model);
            return Ok(createDoctor);
        }

        [Route("hardDeleteDoctor")]
        [HttpPost]
        public async Task<ActionResult<bool>> HardDeleteDoctorRecord(long doctorId)
        {
            var createDoctor = await doctorService.HardDeleteDoctorRecordAsync(doctorId);
            return Ok(createDoctor);
        }

        [Route("softDeleteDoctor")]
        [HttpPost]
        public async Task<ActionResult<bool>> SoftDeleteDoctorRecord(long doctorId)
        {
            var createDoctor = await doctorService.SoftDeleteDoctorRecordAsync(doctorId);
            return Ok(createDoctor);
        }

        [Route("Getdoctor")]
        [HttpGet]
        public async Task<ActionResult<DoctorModel>> GetDoctorsbyHospitalId(long hospitalId)
        {
            var doctor = await doctorService.GetDoctorByIdAsync(hospitalId);
            return doctor;
        }

        [Route("doctor")]
        [HttpGet]
        public async Task<ActionResult<DoctorModel>> GetDoctor(long id)
        {
            var doctor = await doctorService.GetDoctorByIdAsync(id);
            return doctor; 
        }
    }
}
