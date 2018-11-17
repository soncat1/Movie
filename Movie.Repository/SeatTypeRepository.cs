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
    public class SeatTypeRepository:ISeatTypeRepository
    {
        private MovieContext db;
        public SeatTypeRepository(MovieContext db)
        {
            this.db = db;
        }
        public void Add(SeatType item)
        {
            db.SeatTypes.Add(item);
        }

        public void Delete(int id)
        {
            var seatType = db.SeatTypes.Find(id);
            if (seatType != null)
            {
                db.SeatTypes.Remove(seatType);
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

        public ICollection<SeatType> GetAll()
        {
            return db.SeatTypes.ToList();
        }

        public SeatType GetObject(object obj)
        {
            return db.SeatTypes.FirstOrDefault(r => r.SeatTypeId == (int)obj);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(SeatType item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
