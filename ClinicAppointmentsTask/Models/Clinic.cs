using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ClinicAppointmentsTask.Models
{
    public class Clinic
    {
        [Key]
        public int ClinicId { get; set; }
        [Required]
        public string ClinicSepcialization { get; set; }
        [Required]

        [Range(0, 20, ErrorMessage = "Limit reached for today!")]
        public int numberOfSlots { get; set; } = 0;
 }
}
