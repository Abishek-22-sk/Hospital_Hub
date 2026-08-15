using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HealthHub.Models.ReturnModel
{
    public class UserModel
    {
        [Key]
        public long UserId { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public long? HospitalId { get; set; }

        [ForeignKey("HospitalId")]
        [JsonIgnore]
        public HospitalModel hospital { get; set; }
    }
}
