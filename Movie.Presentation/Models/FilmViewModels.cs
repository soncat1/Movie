using Movie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Movie.Presentation.Models
{
    public class FilmViewModels
    {

        public string FilmName { get; set; }
        public string CategoryName { get; set; }
        public int Duration { get; set; }
        public int Queue { get; set; }
        public int SeatCount { get; set; }
        public string Image { get; set; }
        public DateTime ShowDate { get; set; }
        public List<Film> Films { get; set; }
        public List<Showtime> Showtimes { get; set; }
        public List<Room> Rooms { get; set; }
        public List<Seat> Seats { get; set; }
    }
}