using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ClinicAppointmentsTask.Models
{
    public class Clinic 
    { 
  
        [Key]
        public int ClinicId { get; set; }
        [Required]    
        [StringLength(100, ErrorMessage = "Clinic specialization cannot exceed 100 characters.")]
        public string ClinicSepcialization { get; set; } // Clinic specialization validation
        [Required]
        [Range(0, 20, ErrorMessage = "Limit reached for today!")]
        public int NumberOfSlots { get; set; } = 0; // Validation for number of slots
}
}
