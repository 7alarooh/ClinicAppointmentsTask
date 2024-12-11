// This code incorporates the use of 3-tier system architecture concepts by structuring models for the DAL (Data Access Layer).
// Validation and scientific terms such as Data Transfer Objects (DTO) are used for clean separation of concerns.
// Repository Pattern and Unit of Work patterns are suitable for implementing the logic for Patient data management.
// Middleware and dependency injection can be leveraged for managing Booking logic within the middleware pipeline.
// AppSettings.json can be used for configurable limits such as the maximum number of slots.


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ClinicAppointmentsTask.Models
{
    public enum Gender
    {
        Male,
        Female
    }
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Patient name cannot exceed 100 characters.")]
        [RegularExpression("^[a-zA-Z\\s]*$", ErrorMessage = "Patient name must contain only letters and spaces.")]
        public string PatientName { get; set; }
        [Required]
        [Range(0, 120, ErrorMessage = "Age must be between 0 and 120.")]
        public int Age { get; set; }
        [Required]
        [EnumDataType(typeof(Gender), ErrorMessage = "Invalid gender.")]
        public Gender Gender { get; set; } // Gender of the user (e.g., Male, Female)
        [JsonIgnore]
        public virtual ICollection<Booking>? Booking { get; set; } // Relationship for many-to-many with Booking.

    }
}
