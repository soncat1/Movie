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
    public class ShowtimeRepository:IShowtimeRepository
    {
        private MovieContext db;
        public ShowtimeRepository(MovieContext db)
        {
            this.db = db;
        }
        public void Add(Showtime item)
        {
            db.Showtimes.Add(item);
        }

        public void Delete(int id)
        {
            var showtime = db.Showtimes.Find(id);
            if (showtime != null)
            {
                db.Showtimes.Remove(showtime);
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

        public ICollection<Showtime> GetAll()
        {
            return db.Showtimes.ToList();
        }

        public Showtime GetObject(object obj)
        {
            return db.Showtimes.FirstOrDefault(r => r.ShowtimeId == (int)obj);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Showtime item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
