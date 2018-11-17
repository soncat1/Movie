using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
namespace Movie.Models
{
    public class SeatType
    {

        public short SeatTypeId { get; set; }

        [StringLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Seat> Seats { get; set; }
    }
}
