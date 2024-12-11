// This code incorporates the use of 3-tier system architecture concepts by structuring models for the DAL (Data Access Layer).
// Validation and scientific terms such as Data Transfer Objects (DTO) are used for clean separation of concerns.
// Repository Pattern and Unit of Work patterns are suitable for implementing the logic for Patient data management.

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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


    }
}
