using Movie.Models;
using Movie.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Movie.Presentation.Areas.Admin.Controllers
{
    public class SeatController : BaseController
    {
        private SeatService seatService;
        private RoomService roomService;
        private SeatTypeService seatTypeService;
        public SeatController()
        {
            seatService = new SeatService();
            roomService = new RoomService();
            seatTypeService = new SeatTypeService();
        }
        // GET: Admin/Seat
        public ActionResult Index()
        {
            var result = Authenticate();
            if (result == 1)
            {
                return View(seatService.GetAll());
            }
            else
            {
                return View("Error404");
            }
        }
        public ActionResult Details(int id)
        {
            var result = Authenticate();
            if (result == 1)
            {
                Seat seat = seatService.GetSeat(id);
                if (seat == null)
                {
                    return HttpNotFound();
                }
                return View(seat);
            }
            else
            {
                return View("Error404");
            }
        }
        public ActionResult Create()
        {
            var result = Authenticate();
            if (result == 1)
            {
                ViewBag.Room = roomService.GetAll();
                ViewBag.SeatType = seatTypeService.GetAll();
                return View();
            }
            else
            {
                return View("Error404");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Seat seat)
        {
            try
            {
                var room = roomService.GetRoom(seat.RoomId);
                if (ModelState.IsValid)
                {
                    for (int i = 1; i <= 9; i++)
                    {
                        for (int j = 1; j <= 14; j++)
                        {
                            if(room.Name=="2D")
                            {
                                switch (i)
                                {
                                    case 1:
                                        seat.RowSeat = "A";
                                        seat.ColumnSeat = j.ToString();
                                        seat.Status = 1;
                                        seat.Label = "A" + j;
                                        seat.TypeId = 1;
                                        seatService.Add(seat);
                                        break;
                                    case 2:
                                        seat.RowSeat = "B";
                                        seat.ColumnSeat = j.ToString();
                                        seat.Status = 1;
                                        seat.Label = "B" + j;
                                        seat.TypeId = 1;
                                        seatService.Add(seat);
                                        break;
                                    case 3:
                                        seat.RowSeat = "C";
                                        seat.ColumnSeat = j.ToString();
                                        seat.Status = 1;
                                        seat.Label = "C" + j;
                                        seat.TypeId = 1;
                                        seatService.Add(seat);
                                        break;
                                    case 4:
                                        seat.RowSeat = "D";
                                        seat.ColumnSeat = j.ToString();
                                        seat.Status = 1;
                                        seat.Label = "D" + j;
                                        seat.TypeId = 2;
                                        seatService.Add(seat);
                                        break;
                                    case 5:
                                        seat.RowSeat = "E";
                                        seat.ColumnSeat = j.ToString();
                                        seat.Status = 1;
                                        seat.Label = "E" + j;
                                        seat.TypeId = 2;
                                        seatService.Add(seat);
                                        break;
                                    case 6:
                                        seat.RowSeat = "F";
                                        seat.ColumnSeat = j.ToString();
                                        seat.Status = 1;
                                        seat.Label = "F" + j;
                                        seat.TypeId = 2;
                                        seatService.Add(seat);
                                        break;
                                    case 7:
                                        seat.RowSeat = "G";
                                        seat.ColumnSeat = j.ToString();
                                        seat.Status = 1;
                                        seat.Label = "G" + j;
                                        seat.TypeId = 2;
                                        seatService.Add(seat);
                                        break;
                                    case 8:
                                        seat.RowSeat = "H";
                                        seat.ColumnSeat = j.ToString();
                                        seat.Status = 1;
                                        seat.Label = "H" + j;
                                        seat.TypeId = 2;
                                        seatService.Add(seat);
                                        break;
                                    case 9:
                                        seat.RowSeat = "I";
                                        seat.ColumnSeat = j.ToString();
                                        seat.Status = 1;
                                        seat.Label = "I" + j;
                                        seat.TypeId = 3;
                                        seatService.Add(seat);
                                        break;
                                    default:

                                        break;
                                }
                            }
                            else
                            {
                                switch (i)
                                {
                                    case 1:
                                        seat.RowSeat = "A";
                                        seat.ColumnSeat = j.ToString();
                                        seat.Status = 1;
                                        seat.Label = "A" + j;
                                        seat.TypeId = 4;
                                        seatService.Add(seat);
                                        break;
                                    case 2:
                                        seat.RowSeat = "B";
                                        seat.ColumnSeat = j.ToString();
                                        seat.Status = 1;
                                        seat.Label = "B" + j;
                                        seat.TypeId = 4;
                                        seatService.Add(seat);
                                        break;
                                    case 3:
                                        seat.RowSeat = "C";
                                        seat.ColumnSeat = j.ToString();
                                        seat.Status = 1;
                                        seat.Label = "C" + j;
                                        seat.TypeId = 4;
                                        seatService.Add(seat);
                                        break;
                                    case 4:
                                        seat.RowSeat = "D";
                                        seat.ColumnSeat = j.ToString();
                                        seat.Status = 1;
                                        seat.Label = "D" + j;
                                        seat.TypeId = 5;
                                        seatService.Add(seat);
                                        break;
                                    case 5:
                                        seat.RowSeat = "E";
                                        seat.ColumnSeat = j.ToString();
                                        seat.Status = 1;
                                        seat.Label = "E" + j;
                                        seat.TypeId = 5;
                                        seatService.Add(seat);
                                        break;
                                    case 6:
                                        seat.RowSeat = "F";
                                        seat.ColumnSeat = j.ToString();
                                        seat.Status = 1;
                                        seat.Label = "F" + j;
                                        seat.TypeId = 5;
                                        seatService.Add(seat);
                                        break;
                                    case 7:
                                        seat.RowSeat = "G";
                                        seat.ColumnSeat = j.ToString();
                                        seat.Status = 1;
                                        seat.Label = "G" + j;
                                        seat.TypeId = 5;
                                        seatService.Add(seat);
                                        break;
                                    case 8:
                                        seat.RowSeat = "H";
                                        seat.ColumnSeat = j.ToString();
                                        seat.Status = 1;
                                        seat.Label = "H" + j;
                                        seat.TypeId = 5;
                                        seatService.Add(seat);
                                        break;
                                    case 9:
                                        seat.RowSeat = "I";
                                        seat.ColumnSeat = j.ToString();
                                        seat.Status = 1;
                                        seat.Label = "I" + j;
                                        seat.TypeId = 6;
                                        seatService.Add(seat);
                                        break;
                                    default:

                                        break;
                                }
                            }
                        }
                    }
                    
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {

                ModelState.AddModelError("", "Không thể tạo ghế!");
            }
            return View(seat);

        }
        public ActionResult Edit(int id)
        {
            var result = Authenticate();
            if (result == 1)
            {
                ViewBag.Room = roomService.GetAll();
                ViewBag.SeatType = seatTypeService.GetAll();
                Seat seat = seatService.GetSeat(id);
                return View(seat);
            }
            else
            {
                return View("Error404");
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Seat seat)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    seatService.Update(seat);
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Không thể thay đổi thông tin ghế!");
            }
            return View(seat);
        }

        public ActionResult Delete(int id)
        {
            var result = Authenticate();
            if (result == 1)
            {
                Seat seat = seatService.GetSeat(id);
                return View(seat);
            }
            else
            {
                return View("Error404");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Seat seat)
        {
            try
            {
                seat = seatService.GetSeat(id);
                seatService.Delete(id);
                return RedirectToAction("Index");

            }
            catch (DataException)
            {

                ModelState.AddModelError("", "Không thể xóa ghế");
            }
            return View(seat);
        }
        public int Authenticate()
        {
            var employee = (Employee)Session["Employee"];
            if (employee.Department.Name == "Nhân viên quản lý ghế" || employee.Department.Name == "Tổng giám đốc")
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}