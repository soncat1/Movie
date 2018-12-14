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
        [Display(Name = "Nhãn ghế")]
        public string Label { get; set; }
        [Display(Name = "Trạng thái")]
        public short Status { get; set; }

        [ForeignKey("SeatType")]
        public short TypeId { get; set; }
        [Display(Name = "Cột ghế")]
        public string ColumnSeat { get; set; }
        [Display(Name = "Hàng ghế")]
        public string RowSeat { get; set; }
        public virtual Room Room { get; set; }

        public virtual SeatType SeatType { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
