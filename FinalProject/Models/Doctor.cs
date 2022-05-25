using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Models
{
    public class Doctor
    {
      
        public int DoctorId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        public string FullName { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Specialization { get; set; }
        [Required]
        public DateTime? FromTime { get; set; }
        [Required]
        public DateTime? ToTime { get; set; }

        public virtual ICollection<Slot> slots { get; set; }

    }
}
