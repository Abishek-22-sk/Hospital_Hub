using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
using System.Text.Json.Serialization;

namespace HealthHub.Models
{
    public class HospitalModel
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [StringLength(100)]
        public string HospitalName { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        public long PhoneNumber { get; set; }

        public long TotalBeds { get; set; }

        public bool IsActive { get; set; }

        public bool IsDelete { get; set; }

        public long AvailableBeds { get; set; }

        public long UserId  { get; set; }

        [StringLength(50)]
        public string RegistrationNumber { get; set; }

    }
}
