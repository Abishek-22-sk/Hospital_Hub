using HealthHub.Models;
using HealthHub.Service;
using Microsoft.AspNetCore.Mvc;

namespace HealthHub.Controller
{
    [Route("api/Controller")]
    [ApiController]
    public class HospitalController: ControllerBase
    {
        private readonly HospitalService hospitalService;

        public HospitalController(HospitalService hospitalService)
        {
            this.hospitalService = hospitalService;
        }

        [Route("CreateHospital")]
        [HttpPost]
        public async Task<ActionResult<HospitalModel>> CreateHospital([FromBody]HospitalModel hospitalModel)
        {
            var hospital =await hospitalService.CreateHospitalAsync(hospitalModel);
            return Ok(hospital);
        }

        [Route("GetHospital")]
        [HttpGet]
        public async Task<ActionResult<HospitalModel>> GetHospital([FromQuery] long hospitalId)
        {
            return await hospitalService.GetHospitalAsync(hospitalId);
        }

        [Route("GetHospitals")]
        [HttpGet]
        public async Task<ActionResult<HospitalModel>> GetHospitals()
        {
            var createHospital = await hospitalService.GetHospitalsAsync();
            return Ok(createHospital);
        }

        [Route("DisableHospitals")]
        [HttpPost]
        public async Task<ActionResult<bool>> DisableHospital(long hospitalId)
        {
            var createHospital = await hospitalService.DisableHospitalAsync(hospitalId);
            return Ok(createHospital);
        }


        [Route("SoftDeleteHospitals")]
        [HttpPost]
        public async Task<ActionResult<bool>> MarkHospitalAsDelete(long hospitalId)
        {
            var createHospital = await hospitalService.MarkHospitalAsDeleteAsync(hospitalId);
            return Ok(createHospital);
        }

        [Route("HardDeleteHospitals")]
        [HttpPost]
        public async Task<ActionResult<bool>> HardHospitalAsDelete(long hospitalId)
        {
            var createHospital = await hospitalService.HardDeleteHospitalAsync(hospitalId);
            return Ok(createHospital);
        }
        [Route("EnableHospitals")]
        [HttpPost]
        public async Task<ActionResult<bool>> EnableHospital(long hospitalId)
        {
            var createHospital = await hospitalService.EnableHospitalAsync(hospitalId);
            return Ok(createHospital);
        }
    }
}
