using System;
using System.ComponentModel.DataAnnotations;

namespace Movie.Models
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public int ShowtimeId { get; set; }
        public int SeatId { get; set; }
        [Display(Name = "Giá vé")]
        public double Price { get; set; }
        [Display(Name = "Ngày tạo")]
        public DateTime DateCreate { get; set; }
        public int CustomerId { get; set; }
        public virtual Showtime Showtime { get; set; }
        public virtual Seat Seat { get; set; }
        public virtual Customer Customer { get; set; }

    }
}