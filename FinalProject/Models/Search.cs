using System.ComponentModel.DataAnnotations;
namespace FinalProject.Models
{
    public class Search
    {
        [Key]
        public int AppointmentId { get; set; }
        public int PatientId { get; set; }

        public int DoctorId { get; set; }
       
        public string DoctorName { get; set; }
        public string Specialization { get; set; }

        public string TimeSlot { get; set; }

    }
}
