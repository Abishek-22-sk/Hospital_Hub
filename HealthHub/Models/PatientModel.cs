using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HealthHub.Models
{
    public class PatientModel
    {
        [Key]
        public long PatientId { get; set; }

        public string Name { get; set; }

        public long HospitalId { get; set; }

        [ForeignKey(nameof(HospitalId))]
        [JsonIgnore]
        public HospitalModel Hospital { get; set; }

        public long DoctorId { get; set; }

        [ForeignKey(nameof(DoctorId))]
        [JsonIgnore]
        public DoctorModel Doctor { get; set; }
    }
}
