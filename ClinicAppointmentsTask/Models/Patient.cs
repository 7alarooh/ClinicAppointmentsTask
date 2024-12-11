using System.ComponentModel.DataAnnotations;

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
        public string PatientName { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        [EnumDataType(typeof(Gender), ErrorMessage = "Invalid gender.")]
        public Gender Gender { get; set; } // Gender of the user (e.g., Male, Female)


    }
}
