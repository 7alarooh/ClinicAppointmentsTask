using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ClinicAppointmentsTask.Models
{
    [PrimaryKey(nameof(PatientId), nameof(ClinicId), nameof(DateToday))]
    public class Booking
    {
        public DateTime DateToday { get; set; }

        [Required]
        [Range(0, 20, ErrorMessage = "Limit reached for today!")]
        public int slot_Number { get; set; } = 0;

        [ForeignKey(nameof(PatientId))] // Specify the foreign key property (PId)
        [JsonIgnore]
        public virtual Patient Patient { get; set; }

        public int PatientId { get; set; }

        // ForeignKey attribute for Clinic 
        [ForeignKey(nameof(ClinicId))]
        public int ClinicId { get; set; }

        [JsonIgnore]
        public virtual Clinic Clinic { get; set; }
    }
}
