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
    public class RoomRepository:IRoomRepository
    {
        private MovieContext db;
        public RoomRepository(MovieContext db)
        {
            this.db = db;
        }
        public void Add(Room item)
        {
            db.Rooms.Add(item);
        }

        public void Delete(int id)
        {
            var room = db.Rooms.Find(id);
            if (room != null)
            {
                db.Rooms.Remove(room);
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

        public ICollection<Room> GetAll()
        {
            return db.Rooms.ToList();
        }

        public Room GetObject(object obj)
        {
            return db.Rooms.FirstOrDefault(r => r.RoomId == (int)obj);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Room item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
