using System.ComponentModel.DataAnnotations;

namespace HealthHub.Models
{
    public class SpecialistModel
    {
        [Key]
        public long SpecialistId { get; set; }

        public string SpecialistName { get; set; }

        public string Description { get; set; }

        public bool IsDelete { get; set; }

        public long DoctorId { get; set; }

    }

}
