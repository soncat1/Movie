namespace Movie.Presentation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Film",
                c => new
                    {
                        FilmId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 500),
                        Director = c.String(maxLength: 50),
                        Actor = c.String(maxLength: 500),
                        Year = c.Int(),
                        Summary = c.String(maxLength: 500),
                        Description = c.String(maxLength: 500),
                        CategoryId = c.Int(nullable: false),
                        TrailerUrl = c.String(maxLength: 500),
                        Duration = c.Int(),
                        Image = c.String(),
                        Rating = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.FilmId)
                .ForeignKey("dbo.Category", t => t.CategoryId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Showtime",
                c => new
                    {
                        ShowtimeId = c.Int(nullable: false, identity: true),
                        FilmId = c.Int(nullable: false),
                        RoomId = c.Int(nullable: false),
                        ShowDate = c.DateTime(),
                        Queue = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ShowtimeId)
                .ForeignKey("dbo.Film", t => t.FilmId)
                .ForeignKey("dbo.Room", t => t.RoomId)
                .Index(t => t.FilmId)
                .Index(t => t.RoomId);
            
            CreateTable(
                "dbo.Room",
                c => new
                    {
                        RoomId = c.Int(nullable: false, identity: true),
                        CinemaId = c.Int(nullable: false),
                        Name = c.String(maxLength: 50),
                        TypeId = c.Int(nullable: false),
                        SeatCount = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RoomId)
                .ForeignKey("dbo.Cinema", t => t.CinemaId)
                .ForeignKey("dbo.RoomType", t => t.TypeId)
                .Index(t => t.CinemaId)
                .Index(t => t.TypeId);
            
            CreateTable(
                "dbo.Cinema",
                c => new
                    {
                        CinemaId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 10),
                        Address = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.CinemaId);
            
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        CinemaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DepartmentId)
                .ForeignKey("dbo.Cinema", t => t.CinemaId)
                .Index(t => t.CinemaId);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        DateOfBirth = c.DateTime(storeType: "date"),
                        DepartmentId = c.Int(nullable: false),
                        Address = c.String(maxLength: 50),
                        CMT = c.Int(),
                        UserName = c.String(maxLength: 50),
                        Password = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.Department", t => t.DepartmentId)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.RoomType",
                c => new
                    {
                        RoomTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.RoomTypeId);
            
            CreateTable(
                "dbo.Seat",
                c => new
                    {
                        SeatId = c.Int(nullable: false, identity: true),
                        RoomId = c.Int(nullable: false),
                        Label = c.String(maxLength: 10),
                        Status = c.Short(nullable: false),
                        TypeId = c.Short(nullable: false),
                        ColumnSeat = c.String(),
                        RowSeat = c.String(),
                    })
                .PrimaryKey(t => t.SeatId)
                .ForeignKey("dbo.Room", t => t.RoomId)
                .ForeignKey("dbo.SeatType", t => t.TypeId)
                .Index(t => t.RoomId)
                .Index(t => t.TypeId);
            
            CreateTable(
                "dbo.SeatType",
                c => new
                    {
                        SeatTypeId = c.Short(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.SeatTypeId);
            
            CreateTable(
                "dbo.Ticket",
                c => new
                    {
                        TicketId = c.Int(nullable: false, identity: true),
                        ShowtimeId = c.Int(nullable: false),
                        SeatId = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        DateCreate = c.DateTime(nullable: false),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TicketId)
                .ForeignKey("dbo.Customer", t => t.CustomerId)
                .ForeignKey("dbo.Seat", t => t.SeatId)
                .ForeignKey("dbo.Showtime", t => t.ShowtimeId)
                .Index(t => t.ShowtimeId)
                .Index(t => t.SeatId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        DateOfBirth = c.DateTime(storeType: "date"),
                        Password = c.String(maxLength: 50),
                        Email = c.String(maxLength: 50),
                        Address = c.String(maxLength: 50),
                        Type = c.Int(),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.New",
                c => new
                    {
                        NewId = c.Int(nullable: false, identity: true),
                        Image = c.String(maxLength: 255),
                        Description = c.String(),
                        TypeNew = c.String(maxLength: 50),
                        CreateDate = c.DateTime(),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.NewId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Showtime", "RoomId", "dbo.Room");
            DropForeignKey("dbo.Ticket", "ShowtimeId", "dbo.Showtime");
            DropForeignKey("dbo.Ticket", "SeatId", "dbo.Seat");
            DropForeignKey("dbo.Ticket", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.Seat", "TypeId", "dbo.SeatType");
            DropForeignKey("dbo.Seat", "RoomId", "dbo.Room");
            DropForeignKey("dbo.Room", "TypeId", "dbo.RoomType");
            DropForeignKey("dbo.Room", "CinemaId", "dbo.Cinema");
            DropForeignKey("dbo.Employee", "DepartmentId", "dbo.Department");
            DropForeignKey("dbo.Department", "CinemaId", "dbo.Cinema");
            DropForeignKey("dbo.Showtime", "FilmId", "dbo.Film");
            DropForeignKey("dbo.Film", "CategoryId", "dbo.Category");
            DropIndex("dbo.Ticket", new[] { "CustomerId" });
            DropIndex("dbo.Ticket", new[] { "SeatId" });
            DropIndex("dbo.Ticket", new[] { "ShowtimeId" });
            DropIndex("dbo.Seat", new[] { "TypeId" });
            DropIndex("dbo.Seat", new[] { "RoomId" });
            DropIndex("dbo.Employee", new[] { "DepartmentId" });
            DropIndex("dbo.Department", new[] { "CinemaId" });
            DropIndex("dbo.Room", new[] { "TypeId" });
            DropIndex("dbo.Room", new[] { "CinemaId" });
            DropIndex("dbo.Showtime", new[] { "RoomId" });
            DropIndex("dbo.Showtime", new[] { "FilmId" });
            DropIndex("dbo.Film", new[] { "CategoryId" });
            DropTable("dbo.New");
            DropTable("dbo.Customer");
            DropTable("dbo.Ticket");
            DropTable("dbo.SeatType");
            DropTable("dbo.Seat");
            DropTable("dbo.RoomType");
            DropTable("dbo.Employee");
            DropTable("dbo.Department");
            DropTable("dbo.Cinema");
            DropTable("dbo.Room");
            DropTable("dbo.Showtime");
            DropTable("dbo.Film");
            DropTable("dbo.Category");
        }
    }
}
