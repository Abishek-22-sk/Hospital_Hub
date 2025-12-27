using System.ComponentModel.DataAnnotations;

namespace HealthHub.Models
{
    public class DoctorModel
    {
        [Key]
        public long Id { get; set; }

        public string DoctorName  { get; set; }

        public string Specialization { get; set; }

        public string Email { get; set; }

        public long PhoneNumber { get; set; }

        public long SpecialistId { get; set; }

        public SpecialistModel SpecialistModel { get; set; }
    }
}
