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
    public class RoomTypeRepository:IRoomTypeRepository
    {
        private MovieContext db;
        public RoomTypeRepository(MovieContext db)
        {
            this.db = db;
        }
        public void Add(RoomType item)
        {
            db.RoomTypes.Add(item);
        }

        public void Delete(int id)
        {
            var roomType = db.RoomTypes.Find(id);
            if (roomType != null)
            {
                db.RoomTypes.Remove(roomType);
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

        public ICollection<RoomType> GetAll()
        {
            return db.RoomTypes.ToList();
        }

        public RoomType GetObject(object obj)
        {
            return db.RoomTypes.FirstOrDefault(r => r.RoomTypeId == (int)obj);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(RoomType item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
