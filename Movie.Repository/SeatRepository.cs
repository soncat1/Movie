using Movie.DAL;
using Movie.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Repository
{
    public class SeatRepository:ISeatRepository
    {
        private MovieContext db;
        public SeatRepository(MovieContext db)
        {
            this.db = db;
        }
        public void Add(Seat item)
        {
            db.Seats.Add(item);
        }

        public void Delete(int id)
        {
            var seat = db.Seats.Find(id);
            if (seat != null)
            {
                db.Seats.Remove(seat);
            }

        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public ICollection<Seat> GetAll()
        {
            return db.Seats.ToList();
        }

        public Seat GetObject(object obj)
        {
            return db.Seats.FirstOrDefault(r => r.SeatId == (int)obj);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Seat item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
