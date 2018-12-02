using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movie.Models
{


    public class Seat
    {
        public int SeatId { get; set; }

        public int RoomId { get; set; }

        [StringLength(10)]
        public string Label { get; set; }

        public short Status { get; set; }

        [ForeignKey("SeatType")]
        public short TypeId { get; set; }

        public double? Top { get; set; }

        public double? Left { get; set; }
        public string ColumnSeat { get; set; }

        public string RowSeat { get; set; }
        public virtual Room Room { get; set; }

        public virtual SeatType SeatType { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
