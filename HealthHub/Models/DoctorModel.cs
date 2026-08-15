using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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

        public bool IsDelete { get; set; }

        public long? SpecialistId { get; set; }

        [ForeignKey("SpecialistId")]
        [JsonIgnore]
        public SpecialistModel Specialist { get; set; }

        public long? HospitalId { get; set; }

        [ForeignKey("HospitalId")]
        [JsonIgnore]
        public HospitalModel hospital { get; set; }
    }
}
