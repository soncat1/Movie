using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Movie.Models
{
    

    public class Room
    {


        public int RoomId { get; set; }

        public int CinemaId { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [ForeignKey("RoomType")]
        public int TypeId { get; set; }
        public int SeatCount { get; set; }
        public int Status { get; set; }
        public virtual Cinema Cinema { get; set; }
        public virtual RoomType RoomType { get; set; }

        public virtual ICollection<Seat> Seats { get; set; }
        public virtual ICollection<Showtime> Showtimes { get; set; }


    }
}
