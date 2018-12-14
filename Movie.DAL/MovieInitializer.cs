using Movie.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;

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
            new Department() {Name="Nhân viên quản lý vé",CinemaId=1 },
            new Department() {Name="Nhân viên quản lý phim",CinemaId=1 },
            new Department() {Name="Nhân viên quản lý khách hàng",CinemaId=1 },
            new Department() {Name="Nhân viên quản lý phòng ban",CinemaId=1 },
            new Department() {Name="Nhân viên quản lý phòng chiếu",CinemaId=1 },
            new Department() {Name="Nhân viên quản lý ghế",CinemaId=1 },
            new Department() {Name="Nhân viên quản lý lịch chiếu",CinemaId=1 },
            new Department() {Name="Tổng giám đốc",CinemaId=1 }
        };
            context.Departments.AddRange(departments);
            context.SaveChanges();

            List<Employee> employees = new List<Employee>()
            {
                new Employee() {Name="Đỗ Hồng Sơn",DateOfBirth=DateTime.Parse("11/27/1996"),DepartmentId=8,Address="Hà Nội",CMT=123321123,UserName="son1996",Password="1" },
                new Employee() {Name="Đỗ Hồng Nhung",DateOfBirth=DateTime.Parse("11/28/1996"),DepartmentId=1,Address="Hà Nội",CMT=123321111,UserName="nhung1996",Password="1" },
                new Employee() {Name="Nguyễn Văn Thế",DateOfBirth=DateTime.Parse("11/1/1996"),DepartmentId=2,Address="Hà Nội",CMT=123421123,UserName="the1996",Password="1" },
                new Employee() {Name="Nguyễn Văn Quý",DateOfBirth=DateTime.Parse("11/7/1996"),DepartmentId=3,Address="Hà Nội",CMT=323321123,UserName="quy1996",Password="1" }
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
                new Film() {Name="Naruto Shippuden",Director="Masashi Kishimoto",Actor="Naruto,Sasuke,Sakura",Year=2018,Summary="",Description="",CategoryId=1,TrailerUrl="https://www.youtube.com/embed/Jfrjeg26Cwk",Duration=120,Rating=4.5 }
            };
            context.Films.AddRange(films);
            context.SaveChanges();

            try
            {
                List<Showtime> showtimes = new List<Showtime>()
            { new Showtime() {FilmId=1,RoomId=1,ShowDate=DateTime.Now,Queue=1 }};
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
                new SeatType() {Name="Thường",Description="45000" },
                new SeatType() {Name="VIP(Prime)",Description="60000" },
                new SeatType() {Name="Sweet Box",Description="90000" },
            };
            context.SeatTypes.AddRange(seatTypes);
            context.SaveChanges();

            List<Seat> seats = new List<Seat>()
            {
                new Seat() {RoomId=1,Label="A1",Status=1,TypeId=1,ColumnSeat="1",RowSeat="A" }
            };
            context.Seats.AddRange(seats);
            context.SaveChanges();

            List<Customer> customers = new List<Customer>()
            {
                new Customer() {Name="Rui",DateOfBirth=DateTime.Parse("8/8/1996"),Password="1",Address="Hà Nội",Type=1,Email="rui@gmail.com" }
            };
            context.Customers.AddRange(customers);
            context.SaveChanges();

            List<Ticket> tickets = new List<Ticket>()
            {
                new Ticket() {ShowtimeId=1,SeatId=1,Price=45000,DateCreate=DateTime.Now,CustomerId=1 }
            };
            context.Tickets.AddRange(tickets);
            context.SaveChanges();

            List<New> news = new List<New>()
            {
                new New() {Image="/Images/beta1.png",Description="[123Phim] Một Vé Hai ba",TypeNew="KM",CreateDate=DateTime.Now,IsDelete = false },
                new New() {Image="/Images/beta2.jpg",Description="THÀNH VIÊN BETA - ĐỒNG GIÁ 45K",TypeNew="KM",CreateDate=DateTime.Now,IsDelete = false },
                new New() {Image="/Images/beta3.jpg",Description="CÀI APP BETA, NHẬN QUÀ BAO LA",TypeNew="KM",CreateDate=DateTime.Now,IsDelete = false },
                new New() {Image="/Images/beta4.jpg",Description="THỨ BA VUI VẺ",TypeNew="KM",CreateDate=DateTime.Now,IsDelete = false },
                new New() {Image="/Images/beta5.jpg",Description="GIẢM NGAY 5K/COMBO KHI MUA COMBO BỎNG NƯỚC",TypeNew="KM",CreateDate=DateTime.Now,IsDelete = false },
                new New() {Image="/Images/beta6.jpg",Description="GIÁ VÉ ƯU ĐÃI CHO HỌC SINH, SINH VIÊN",TypeNew="KM",CreateDate=DateTime.Now,IsDelete = false },
                new New() {Image="/Images/beta7.jpg",Description="Aquaman được khen là ‘phim Marvel hay nhất do DC sản xuất’ trước thềm công chiếu",TypeNew="BL",CreateDate=DateTime.Now,IsDelete = false },
                new New() {Image="/Images/beta8.jpg",Description="Điểm mặt những kẻ thù của Bumblebee trong phần ngoại truyện",TypeNew="BL",CreateDate=DateTime.Now,IsDelete = false },
                new New() {Image="/Images/beta9.jpg",Description="10 tình tiết quan trọng được hé lộ trong trailer mới của Captain Marvel",TypeNew="BL",CreateDate=DateTime.Now,IsDelete = false },
                new New() {Image="/Images/beta10.jpg",Description="Trailer Avengers: Endgame có lượt xem cao nhất lịch sử",TypeNew="BL",CreateDate=DateTime.Now,IsDelete = false },
                new New() {Image="/Images/beta11.jpg",Description="[Review] Mortal Engines – Cuộc chiến khốc liệt với cỗ máy tử thần",TypeNew="BL",CreateDate=DateTime.Now,IsDelete = false },
                new New() {Image="/Images/beta12.jpg",Description="Người Nhện Vũ Trụ Mới được khen nức nở là phim siêu anh hùng hay nhất năm",TypeNew="BL",CreateDate=DateTime.Now,IsDelete = false }
            };
            context.News.AddRange(news);
            context.SaveChanges();

            base.Seed(context);
        }



    }
}
