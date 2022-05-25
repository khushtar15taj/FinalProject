using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class Patient
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public int  Age { get; set; }
        [Required]
        public DateTime? DOB { get; set; }
        
    }
}
