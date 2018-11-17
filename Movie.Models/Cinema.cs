using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
namespace Movie.Models
{
   

    public class Cinema
    {

        public int CinemaId { get; set; }

        [StringLength(10)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Address { get; set; }

        public virtual ICollection<Department> Departments { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
    }
}
