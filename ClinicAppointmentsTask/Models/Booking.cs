// This code incorporates the use of 3-tier system architecture concepts by structuring models for the DAL (Data Access Layer).
// Validation and scientific terms such as Data Transfer Objects (DTO) are used for clean separation of concerns.
// Repository Pattern and Unit of Work patterns are suitable for implementing the logic for Patient and Booking data management.
// Middleware and dependency injection can be leveraged for managing Booking logic within the middleware pipeline.
// AppSettings.json can be used for configurable limits such as the maximum number of slots.

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ClinicAppointmentsTask.Models
{
    [PrimaryKey(nameof(PatientId), nameof(ClinicId), nameof(DateToday))]
    public class Booking
    {
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateToday { get; set; } // Date for the booking, validated to ensure proper format.

        [Required]
        [Range(0, 20, ErrorMessage = "Limit reached for today!")]
        public int SlotNumber { get; set; } = 0; // Validation for slot numbers within the defined range.

        [ForeignKey(nameof(PatientId))] // Specify the foreign key property (PId)
        [JsonIgnore]
        public virtual Patient Patient { get; set; } // Relationship to Patient for bookings.

        [Required]
        public int PatientId { get; set; } // Validation to ensure a valid Patient ID.

        [ForeignKey(nameof(ClinicId))] // Specify the foreign key property for Clinic.
        [Required]
        public int ClinicId { get; set; } // Validation to ensure a valid Clinic ID.

        [JsonIgnore]
        public virtual Clinic Clinic { get; set; } // Relationship to Clinic for bookings.
    }
}