using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Movie.DAL
{
    public class MovieContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public MovieContext() : base("name=MovieContext")
        {
        }

        public System.Data.Entity.DbSet<Movie.Models.Employee> Employees { get; set; }

        public System.Data.Entity.DbSet<Movie.Models.Department> Departments { get; set; }

        public System.Data.Entity.DbSet<Movie.Models.Cinema> Cinemas { get; set; }

        public System.Data.Entity.DbSet<Movie.Models.Category> Categories { get; set; }

        public System.Data.Entity.DbSet<Movie.Models.Room> Rooms { get; set; }

        public System.Data.Entity.DbSet<Movie.Models.RoomType> RoomTypes { get; set; }

        public System.Data.Entity.DbSet<Movie.Models.SeatType> SeatTypes { get; set; }

        public System.Data.Entity.DbSet<Movie.Models.Seat> Seats { get; set; }

        public System.Data.Entity.DbSet<Movie.Models.Film> Films { get; set; }

        public System.Data.Entity.DbSet<Movie.Models.Showtime> Showtimes { get; set; }

        public System.Data.Entity.DbSet<Movie.Models.Customer> Customers { get; set; }
    }
}
