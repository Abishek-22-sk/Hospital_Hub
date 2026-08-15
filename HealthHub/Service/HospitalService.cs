using System.Text.RegularExpressions;
using System.Transactions;
using HealthHub.Component;
using HealthHub.Models;
using HealthHub.Models.ReturnModel;
using HealthHub.Repository;

namespace HealthHub.Service
{
    public class HospitalService
    {
        private readonly HospitalRepository hospitalRepository;
        private readonly CommonRegex commonRegex1;
        public HospitalService(HospitalRepository hospitalRepository, CommonRegex commonRegex)
        {
            this.commonRegex1 = commonRegex;
            this.hospitalRepository = hospitalRepository;
        }

        public async Task<HospitalModel> CreateHospitalAsync(HospitalModel model)
        {
            var validation = await ValidationMethodAsync(model);
             if (validation != null)
            {
                throw new Exception($"{validation.Message}");
            }
            model.IsDelete = false;
            model.IsActive = true;
                var result = await hospitalRepository.CreateHosptialAsync(model);
                return result;
        }

        public async Task<HospitalModel> GetHospitalAsync(long hospitalId)
        {
            var result = await hospitalRepository.GetHosptialAsync(hospitalId);
            if (result == null)
            {
                throw new ArgumentException("This id record not found");
            }
            return result;
        }

        public async Task<List<HospitalModel>> GetHospitalsAsync()
        {
            var result = await hospitalRepository.GetHospitalsAsync();
            return result;
        }

        public async Task<bool> DisableHospitalAsync(long hospitalId)
        {
            var result = await hospitalRepository.DisableHospitalAsync(hospitalId);
            return result;
        }

        public async Task<bool> MarkHospitalAsDeleteAsync(long hospitalId)
        {
            var result = await hospitalRepository.MarkHospitalAsDeleteAsync(hospitalId);
            return result;
        }

        public async Task<bool> HardDeleteHospitalAsync(long hospitalId)
        {
            var result = await hospitalRepository.HardDeleteHospitalAsync(hospitalId);
            return result;
        }
        public async Task<bool> EnableHospitalAsync(long hospitalId)
        {
            var result = await hospitalRepository.EnableHospitalAsync(hospitalId);
            return result;
        }

        #region helper method
        public async Task<ReturnModel<HospitalModel>> ValidationMethodAsync(HospitalModel model) 
        {

            if (model == null)
            {
                return new ReturnModel<HospitalModel> { Message = "Hospital model cannot be null." };
            }
            var result = new List<string>();
            if(model.TotalBeds < model.AvailableBeds)
            {
                return new ReturnModel<HospitalModel> { Message = "AvailableBeds Can't be greater then TotalBeds" };
            }

            if(await hospitalRepository.IsHospitalnameExist(model.HospitalName))
            {
                return new ReturnModel<HospitalModel> { Message = "Unable To create Hospital " };
            }

            if (!Regex.IsMatch(model.Email, commonRegex1.email))
            {
                return new ReturnModel<HospitalModel> { Message = "Email Not Valid" };
            }
            return null;
        }
        #endregion
    }
}
