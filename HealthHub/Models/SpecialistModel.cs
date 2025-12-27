using System.ComponentModel.DataAnnotations;

namespace HealthHub.Models
{
    public class SpecialistModel
    {
        [Key]
        public long SpecialistId { get; set; }

        public string SpecialistName { get; set; }

        public double  SurgeryCount { get; set; }

    }
}
