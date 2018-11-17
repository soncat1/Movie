using Movie.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.DAL
{
    public class MovieInitializer : DropCreateDatabaseIfModelChanges<MovieContext>
    {
        protected override void Seed(MovieContext context)
        {
            try
            {
                List<Cinema> cinemas = new List<Cinema>()
                 {
                     new Cinema() {Name="Beta",Address="Từ Liêm,Mỹ Đình" }
                 };
                context.Cinemas.AddRange(cinemas);
                context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {

                throw e;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            

            List<Department> departments = new List<Department>()
        {
            new Department () {Name="Nhân viên bán vé",CinemaId=1 }
        };
            context.Departments.AddRange(departments);
            context.SaveChanges();

            List<Employee> employees = new List<Employee>()
            {
                new Employee() {Name="Đỗ Hồng Sơn",DateOfBirth=DateTime.Parse("11/27/1996"),DepartmentId=1,Address="Hà Nội",CMT=123321123,UserName="son1996",Password="1" }
            };
            context.Employees.AddRange(employees);
            context.SaveChanges();

            List<RoomType> roomTypes = new List<RoomType>()
            {
                new RoomType() {Name="3D"}
            };
            context.RoomTypes.AddRange(roomTypes);
            context.SaveChanges();

            List<Room> rooms = new List<Room>()
            {
                new Room() {CinemaId=1,Name="R3D001" ,TypeId=1,SeatCount=10,Status=1}
            };
            context.Rooms.AddRange(rooms);
            context.SaveChanges();

            List<Category> categories = new List<Category>()
            {
                new Category() {Name="Action" }
            };
            context.Categories.AddRange(categories);
            context.SaveChanges();

            List<Film> films = new List<Film>()
            {
                new Film() {Name="Naruto Shippuden",Director="Masashi Kishimoto",Actor="Naruto,Sasuke,Sakura",Year=2018,Summary="",Description="",CategoryId=1,TrailerUrl="",Duration=120,Rating=4.5 }
            };
            context.Films.AddRange(films);
            context.SaveChanges();

            try
            {
                List<Showtime> showtimes = new List<Showtime>()
            { new Showtime() {FilmId=1,RoomId=1,ShowDate=DateTime.Parse("10/21/2018"),Queue=1 }};
                context.Showtimes.AddRange(showtimes);
                context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {

                throw e;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            

            List<SeatType> seatTypes = new List<SeatType>()
            {
                new SeatType() {Name="GOLD" }
            };
            context.SeatTypes.AddRange(seatTypes);
            context.SaveChanges();

            List<Seat> seats = new List<Seat>()
            {
                new Seat() {RoomId=1,Label="A1",Status=1,TypeId=1,Top=100,Left=50 }
            };
            context.Seats.AddRange(seats);
            context.SaveChanges();

            List<Customer> customers = new List<Customer>()
            {
                new Customer() {Name="Rui",DateOfBirth=DateTime.Parse("8/8/1996"), UserName="rui",Password="1",Address="Hà Nội",Type=1 }
            };
            context.Customers.AddRange(customers);
            context.SaveChanges();

            List<Ticket> tickets = new List<Ticket>()
            {
                new Ticket() {ShowtimeId=1,SeatId=1,Price=75000,DateCreate=DateTime.Now,CustomerId=1 }
            };
            context.Tickets.AddRange(tickets);
            context.SaveChanges();
            base.Seed(context);
        }



    }
}
