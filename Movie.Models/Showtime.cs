using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Movie.Models
{
    public class Showtime
    {

        public int ShowtimeId { get; set; }

        public int FilmId { get; set; }
        public int RoomId { get; set; }

        public DateTime? ShowDate { get; set; }

        [Range(1,5)]
        public int Queue { get; set; }

        public virtual Film Film { get; set; }
        public virtual Room Room { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
