using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
namespace Movie.Models
{
    

    public class Film
    {

        public int FilmId { get; set; }

        [StringLength(500)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Director { get; set; }

        [StringLength(500)]
        public string Actor { get; set; }

        public int? Year { get; set; }

        [StringLength(500)]
        public string Summary { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public int CategoryId { get; set; }

        [StringLength(500)]
        public string TrailerUrl { get; set; }

        public int? Duration { get; set; }
        public string Image { get; set; }

        [Range(1,5)]
        public double Rating { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Showtime> ShowTimes { get; set; }
    }
}
