using System.ComponentModel.DataAnnotations;

namespace Bus_Management_System.Models
{
    public class LeadDetailsEntity
    {
         
        [Key]
        public int LeadId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
    }

}
    