using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs
{
   public record ShareLocationDto
    {
        [Required(ErrorMessage = "Location is a required field.")]
        public string location { get; set; }
        
        public double? Distance { get; set; }
        public DateTime date { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "TrainNumber is a required field.")]
        public int? TrainNumber { get; set; }

        [Required(ErrorMessage = "TicketId is a required field.")]
        public int? TicketNumber { get; set; }

    }
    public record locationDto(int Id , string location, double? Distance, DateTime date, int? TrainNumber, int? TicketNumber);
    public record UpdateLocationDto : ShareLocationDto;

}
