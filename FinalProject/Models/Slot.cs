using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Models
{
  
    public class Slot
    {
        
        public int slotId { get; set; }
       
        public string slotsAvailable { get; set; }
        public int DoctorId { get; set; }
       

    }
}
