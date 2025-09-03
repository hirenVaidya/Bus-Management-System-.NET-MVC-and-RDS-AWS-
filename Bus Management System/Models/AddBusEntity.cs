using System.ComponentModel.DataAnnotations;

namespace Bus_Management_System.Models
{

    public class AddBusEntity
    {
        [Key]
        public required int BusNo { get; set; }
        public string? BusName { get; set; }
        public string? Bustype { get; set; }
        public int? SeatColumns { get; set; }
        public int? SeatRow { get; set; }
        public string? Origin { get; set; }
        public string? Destination { get; set; }
    }
}





